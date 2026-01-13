/* ***************************************************************************
 * DreadSpiderSilk.cs
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
    public class DreadSpiderSilk : Item
    {
        public override int LabelNumber{ get{ return 1075319; } } // Dread Spider Silk

        public override bool Nontransferable { get { return true; } }

        public override void AddNameProperties( ObjectPropertyList list )
        {
            base.AddNameProperties( list );
            AddQuestItemProperty( list );
        }

        [Constructable]
        public DreadSpiderSilk() : base( 0xDF8 )
        {
            LootType = LootType.Blessed;
            Hue = 0x481;
        }

        public DreadSpiderSilk( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // Version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
