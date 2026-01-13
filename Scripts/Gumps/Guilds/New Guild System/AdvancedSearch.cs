/* ***************************************************************************
 * AdvancedSearch.cs
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
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Guilds
{
    public delegate void SearchSelectionCallback( GuildDisplayType display );

    public class GuildAdvancedSearchGump : BaseGuildGump
    {
        private GuildDisplayType m_Display;
        private SearchSelectionCallback m_Callback;

        public GuildAdvancedSearchGump( PlayerMobile pm, Guild g, GuildDisplayType display, SearchSelectionCallback callback ) : base( pm, g )
        {
            m_Callback = callback;
            m_Display = display;
            PopulateGump();
        }

        public override void PopulateGump()
        {
            base.PopulateGump();

            AddHtmlLocalized( 431, 43, 110, 26, 1062978, 0xF, false, false ); // Diplomacy

            AddHtmlLocalized( 65, 80, 480, 26, 1063124, 0xF, true, false ); // <i>Advanced Search Options</i>

            AddHtmlLocalized( 65, 110, 480, 26, 1063136 + (int)m_Display, 0xF, false, false ); // Showing All Guilds/w/Relation/Waiting Relation

            AddGroup( 1 );
            AddRadio( 75, 140, 0xD2, 0xD3, false, 2 );
            AddHtmlLocalized( 105, 140, 200, 26, 1063006, 0x0, false, false ); // Show Guilds with Relationship
            AddRadio( 75, 170, 0xD2, 0xD3, false, 1 );
            AddHtmlLocalized( 105, 170, 200, 26, 1063005, 0x0, false, false ); // Show Guilds Awaiting Action
            AddRadio( 75, 200, 0xD2, 0xD3, false, 0 );
            AddHtmlLocalized( 105, 200, 200, 26, 1063007, 0x0, false, false ); // Show All Guilds

            AddBackground( 450, 370, 100, 26, 0x2486 );
            AddButton( 455, 375, 0x845, 0x846, 5, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 480, 373, 60, 26, 1006044, 0x0, false, false ); // OK
            AddBackground( 340, 370, 100, 26, 0x2486 );
            AddButton( 345, 375, 0x845, 0x846, 0, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 370, 373, 60, 26, 1006045, 0x0, false, false ); // Cancel
        }


        public override void OnResponse( NetState sender, RelayInfo info )
        {
            base.OnResponse( sender, info );

            PlayerMobile pm = sender.Mobile as PlayerMobile;

            if( pm == null || !IsMember( pm, guild ) )
                return;

            GuildDisplayType display = m_Display;

            if( info.ButtonID == 5 )
            {
                for( int i = 0; i < 3; i++ )
                {
                    if( info.IsSwitched( i ) )
                    {
                        display = (GuildDisplayType)i;
                        m_Callback( display );
                        break;
                    }
                }
            }
        }
    }
}
