/* ***************************************************************************
 * Reflector.cs
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
using System.Reflection;
using System.Collections;
using Server;
using System.Collections.Generic;

namespace Server.Factions
{
    public class Reflector
    {
        private static List<Town> m_Towns;

        public static List<Town> Towns
        {
            get
            {
                if ( m_Towns == null )
                    ProcessTypes();

                return m_Towns;
            }
        }

        private static List<Faction> m_Factions;

        public static List<Faction> Factions
        {
            get
            {
                if ( m_Factions == null )
                    Reflector.ProcessTypes();

                return m_Factions;
            }
        }

        private static object Construct( Type type )
        {
            try{ return Activator.CreateInstance( type ); }
            catch{ return null; }
        }

        private static void ProcessTypes()
        {
            m_Factions = new List<Faction>();
            m_Towns = new List<Town>();

            Assembly[] asms = ScriptCompiler.Assemblies;

            for ( int i = 0; i < asms.Length; ++i )
            {
                Assembly asm = asms[i];
                TypeCache tc = ScriptCompiler.GetTypeCache( asm );
                Type[] types = tc.Types;

                for ( int j = 0; j < types.Length; ++j )
                {
                    Type type = types[j];

                    if ( type.IsSubclassOf( typeof( Faction ) ) )
                    {
                        Faction faction = Construct( type ) as Faction;

                        if ( faction != null )
                            Faction.Factions.Add( faction );
                    }
                    else if ( type.IsSubclassOf( typeof( Town ) ) )
                    {
                        Town town = Construct( type ) as Town;

                        if ( town != null )
                            Town.Towns.Add( town );
                    }
                }
            }
        }
    }
}
