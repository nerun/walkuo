/* ***************************************************************************
 * RewardNoticeGump.cs
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

namespace Server.Engines.VeteranRewards
{
    public class RewardNoticeGump : Gump
    {
        private Mobile m_From;

        public RewardNoticeGump( Mobile from ) : base( 0, 0 )
        {
            m_From = from;

            from.CloseGump( typeof( RewardNoticeGump ) );

            AddPage( 0 );

            AddBackground( 10, 10, 500, 135, 2600 );

            /* You have reward items available.
             * Click 'ok' below to get the selection menu or 'cancel' to be prompted upon your next login.
             */
            AddHtmlLocalized( 52, 35, 420, 55, 1006046, true, true );

            AddButton( 60, 95, 4005, 4007, 1, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 95, 96, 150, 35, 1006044, false, false ); // Ok

            AddButton( 285, 95, 4017, 4019, 0, GumpButtonType.Reply, 0 );
            AddHtmlLocalized( 320, 96, 150, 35, 1006045, false, false ); // Cancel
        }

        public override void OnResponse( NetState sender, RelayInfo info )
        {
            if ( info.ButtonID == 1 )
                m_From.SendGump( new RewardChoiceGump( m_From ) );
        }
    }
}
