/* ***************************************************************************
 * ConfirmDryDockGump.cs
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

namespace Server.Multis
{
    public class ConfirmDryDockGump : Gump
    {
        private Mobile m_From;
        private BaseBoat m_Boat;

        public ConfirmDryDockGump( Mobile from, BaseBoat boat ) : base( 150, 200 )
        {
            m_From = from;
            m_Boat = boat;

            m_From.CloseGump( typeof( ConfirmDryDockGump ) );

            AddPage( 0 );

            AddBackground( 0, 0, 220, 170, 5054 );
            AddBackground( 10, 10, 200, 150, 3000 );

            AddHtmlLocalized( 20, 20, 180, 80, 1018319, true, false ); // Do you wish to dry dock this boat?

            AddHtmlLocalized( 55, 100, 140, 25, 1011011, false, false ); // CONTINUE
            AddButton( 20, 100, 4005, 4007, 2, GumpButtonType.Reply, 0 );

            AddHtmlLocalized( 55, 125, 140, 25, 1011012, false, false ); // CANCEL
            AddButton( 20, 125, 4005, 4007, 1, GumpButtonType.Reply, 0 );
        }

        public override void OnResponse( NetState state, RelayInfo info )
        {
            if ( info.ButtonID == 2 )
                m_Boat.EndDryDock( m_From );
        }
    }
}
