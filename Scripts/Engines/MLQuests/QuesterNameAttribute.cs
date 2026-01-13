/* ***************************************************************************
 * QuesterNameAttribute.cs
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
using System.Collections.Generic;
using Server;

namespace Server.Engines.MLQuests
{
    [AttributeUsage( AttributeTargets.Class )]
    public class QuesterNameAttribute : Attribute
    {
        private string m_QuesterName;

        public string QuesterName { get { return m_QuesterName; } }

        public QuesterNameAttribute( string questerName )
        {
            m_QuesterName = questerName;
        }

        private static readonly Type m_Type = typeof( QuesterNameAttribute );
        private static readonly Dictionary<Type, string> m_Cache = new Dictionary<Type, string>();

        public static string GetQuesterNameFor( Type t )
        {
            if ( t == null )
                return "";

            string result;

            if ( m_Cache.TryGetValue( t, out result ) )
                return result;

            object[] attributes = t.GetCustomAttributes( m_Type, false );

            if ( attributes.Length != 0 )
                result = ( (QuesterNameAttribute)attributes[0] ).QuesterName;
            else
                result = t.Name;

            return ( m_Cache[t] = result );
        }
    }
}
