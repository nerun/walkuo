/* ***************************************************************************
 * GumpTooltip.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C) 2002  The RunUO Software Team
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
using Server.Network;

namespace Server.Gumps
{
    public class GumpTooltip : GumpEntry
    {
        private int m_Number;

        public GumpTooltip( int number )
        {
            m_Number = number;
        }

        public int Number
        {
            get
            {
                return m_Number;
            }
            set
            {
                Delta( ref m_Number, value );
            }
        }

        public override string Compile()
        {
            return String.Format( "{{ tooltip {0} }}", m_Number );
        }

        private static byte[] m_LayoutName = Gump.StringToBuffer( "tooltip" );

        public override void AppendTo( IGumpWriter disp )
        {
            disp.AppendLayout( m_LayoutName );
            disp.AppendLayout( m_Number );
        }
    }
}
