/* ***************************************************************************
 * SpawnPersistence.cs
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
using Server;

namespace Server.Regions
{
    public class SpawnPersistence : Item
    {
        private static SpawnPersistence m_Instance;

        public SpawnPersistence Instance{ get{ return m_Instance; } }

        public static void EnsureExistence()
        {
            if ( m_Instance == null )
                m_Instance = new SpawnPersistence();
        }

        public override string DefaultName
        {
            get { return "Region spawn persistence - Internal"; }
        }

        private SpawnPersistence() : base( 1 )
        {
            Movable = false;
        }

        public SpawnPersistence( Serial serial ) : base( serial )
        {
            m_Instance = this;
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version

            writer.Write( (int) SpawnEntry.Table.Values.Count );
            foreach ( SpawnEntry entry in SpawnEntry.Table.Values )
            {
                writer.Write( (int) entry.ID );

                entry.Serialize( writer );
            }
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            int count = reader.ReadInt();
            for ( int i = 0; i < count; i++ )
            {
                int id = reader.ReadInt();

                SpawnEntry entry = (SpawnEntry) SpawnEntry.Table[id];

                if ( entry != null )
                    entry.Deserialize( reader, version );
                else
                    SpawnEntry.Remove( reader, version );
            }
        }
    }
}
