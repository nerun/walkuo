/* ***************************************************************************
 * LimitExtension.cs
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
using System.Collections;
using System.Text;

namespace Server.Commands.Generic
{
    public sealed class LimitExtension : BaseExtension
    {
        public static ExtensionInfo ExtInfo = new ExtensionInfo( 80, "Limit", 1, delegate() { return new LimitExtension(); } );

        public static void Initialize()
        {
            ExtensionInfo.Register( ExtInfo );
        }

        public override ExtensionInfo Info
        {
            get { return ExtInfo; }
        }

        private int m_Limit;

        public int Limit
        {
            get { return m_Limit; }
        }

        public LimitExtension()
        {
        }

        public override void Parse( Mobile from, string[] arguments, int offset, int size )
        {
            m_Limit = Utility.ToInt32( arguments[offset] );

            if ( m_Limit < 0 )
                throw new Exception( "Limit cannot be less than zero." );
        }

        public override void Filter( ArrayList list )
        {
            if ( list.Count > m_Limit )
                list.RemoveRange( m_Limit, list.Count - m_Limit );
        }
    }
}
