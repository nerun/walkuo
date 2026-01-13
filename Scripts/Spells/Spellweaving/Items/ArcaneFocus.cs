/* ***************************************************************************
 * ArcaneFocus.cs
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
    public class ArcaneFocus : TransientItem
    {
        public override int LabelNumber { get { return 1032629; } } // Arcane Focus

        private int m_StrengthBonus;

        [CommandProperty( AccessLevel.GameMaster )]
        public int StrengthBonus
        {
            get { return m_StrengthBonus; }
            set { m_StrengthBonus = value; }
        }

        [Constructable]
        public ArcaneFocus()
            : this( TimeSpan.FromHours( 1 ), 1 )
        {
        }

        [Constructable]
        public ArcaneFocus( int lifeSpan, int strengthBonus )
            : this( TimeSpan.FromSeconds( lifeSpan ), strengthBonus )
        {
        }

        public ArcaneFocus( TimeSpan lifeSpan, int strengthBonus ) : base( 0x3155, lifeSpan )
        {
            LootType = LootType.Blessed;
            m_StrengthBonus = strengthBonus;
        }

        public ArcaneFocus( Serial serial ) : base( serial )
        {
        }
        
        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            list.Add( 1060485, m_StrengthBonus.ToString() ); // strength bonus ~1_val~
        }

        public override TextDefinition InvalidTransferMessage{ get { return 1073480; } } // Your arcane focus disappears.
        public override bool Nontransferable { get { return true; } }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );

            writer.Write( m_StrengthBonus );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();

            m_StrengthBonus = reader.ReadInt();
        }
    }
}
