/* ***************************************************************************
 * ShrinkTable.cs
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
using System.IO;

namespace Server
{
    public class ShrinkTable
    {
        public const int DefaultItemID = 0x1870; // Yellow virtue stone

        private static int[] m_Table;

        public static int Lookup( Mobile m )
        {
            return Lookup( m.Body.BodyID, DefaultItemID );
        }

        public static int Lookup( int body )
        {
            return Lookup( body, DefaultItemID );
        }

        public static int Lookup( Mobile m, int defaultValue )
        {
            return Lookup( m.Body.BodyID, defaultValue );
        }

        public static int Lookup( int body, int defaultValue )
        {
            if ( m_Table == null )
                Load();

            int val = 0;

            if ( body >= 0 && body < m_Table.Length )
                val = m_Table[body];

            if ( val == 0 )
                val = defaultValue;

            return val;
        }

        private static void Load()
        {
            string path = Path.Combine( Core.BaseDirectory, "Data/shrink.cfg" );

            if ( !File.Exists( path ) )
            {
                m_Table = new int[0];
                return;
            }

            m_Table = new int[1000];

            using ( StreamReader ip = new StreamReader( path ) )
            {
                string line;

                while ( (line = ip.ReadLine()) != null )
                {
                    line = line.Trim();

                    if ( line.Length == 0 || line.StartsWith( "#" ) )
                        continue;

                    try
                    {
                        string[] split = line.Split( '\t' );

                        if ( split.Length >= 2 )
                        {
                            int body = Utility.ToInt32( split[0] );
                            int item = Utility.ToInt32( split[1] );

                            if ( body >= 0 && body < m_Table.Length )
                                m_Table[body] = item;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
