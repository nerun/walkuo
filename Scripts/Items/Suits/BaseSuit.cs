/* ***************************************************************************
 * BaseSuit.cs
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

namespace Server.Items
{
    public abstract class BaseSuit : Item
    {
        private AccessLevel m_AccessLevel;

        [CommandProperty( AccessLevel.Administrator )]
        public AccessLevel AccessLevel{ get{ return m_AccessLevel; } set{ m_AccessLevel = value; } }

        public BaseSuit( AccessLevel level, int hue, int itemID ) : base( itemID )
        {
            Hue = hue;
            Weight = 1.0;
            Movable = false;
            LootType = LootType.Newbied;
            Layer = Layer.OuterTorso;

            m_AccessLevel = level;
        }

        public BaseSuit( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version

            writer.Write( (int) m_AccessLevel );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                {
                    m_AccessLevel = (AccessLevel)reader.ReadInt();
                    break;
                }
            }
        }

        public bool Validate()
        {
            object root = RootParent;

            if ( root is Mobile && ((Mobile)root).AccessLevel < m_AccessLevel )
            {
                Delete();
                return false;
            }

            return true;
        }

        public override void OnSingleClick( Mobile from )
        {
            if ( Validate() )
                base.OnSingleClick( from );
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( Validate() )
                base.OnDoubleClick( from );
        }

        public override bool VerifyMove( Mobile from )
        {
            return ( from.AccessLevel >= m_AccessLevel );
        }

        public override bool OnEquip( Mobile from )
        {
            if ( from.AccessLevel < m_AccessLevel )
                from.SendMessage( "You may not wear this." );

            return ( from.AccessLevel >= m_AccessLevel );
        }
    }
}
