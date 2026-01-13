/* ***************************************************************************
 * GuildRejectWarGump.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C)  The RunUO Software Team
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, see <https://www.gnu.org/licenses/>.
 ***************************************************************************/
using System;
using Server;
using Server.Guilds;
using Server.Network;

namespace Server.Gumps
{
    public class GuildRejectWarGump : GuildListGump
    {
        public GuildRejectWarGump( Mobile from, Guild guild ) : base( from, guild, true, guild.WarInvitations )
        {
        }

        protected override void Design()
        {
            AddHtmlLocalized( 20, 10, 400, 35, 1011148, false, false ); // Select the guild to reject their invitations: 

            AddButton( 20, 400, 4005, 4007, 1, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 55, 400, 245, 30, 1011101, false, false );  // Reject war invitations.

            AddButton( 300, 400, 4005, 4007, 2, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 335, 400, 100, 35, 1011012, false, false ); // CANCEL
        }

        public override void OnResponse( NetState state, RelayInfo info )
        {
            if ( GuildGump.BadLeader( m_Mobile, m_Guild ) )
                return;

            if ( info.ButtonID == 1 )
            {
                int[] switches = info.Switches;

                if ( switches.Length > 0 )
                {
                    int index = switches[0];

                    if ( index >= 0 && index < m_List.Count )
                    {
                        Guild g = (Guild)m_List[index];

                        if ( g != null )
                        {
                            m_Guild.WarInvitations.Remove( g );
                            g.WarDeclarations.Remove( m_Guild );

                            GuildGump.EnsureClosed( m_Mobile );

                            if ( m_Guild.WarInvitations.Count > 0 )
                                m_Mobile.SendGump( new GuildRejectWarGump( m_Mobile, m_Guild ) );
                            else
                                m_Mobile.SendGump( new GuildmasterGump( m_Mobile, m_Guild ) );
                        }
                    }
                }
            }
            else if ( info.ButtonID == 2 )
            {
                GuildGump.EnsureClosed( m_Mobile );
                m_Mobile.SendGump( new GuildmasterGump( m_Mobile, m_Guild ) );
            }
        }
    }
}
