/* ***************************************************************************
 * Scarecrow.cs
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

namespace Server.Items
{
    [Flipable( 0x1E34, 0x1E35 )]
    public class ScarecrowComponent : AddonComponent
    {
        public override int LabelNumber { get { return 1076608; } } // Scarecrow

        public ScarecrowComponent() : base( 0x1E34 )
        {
        }

        public ScarecrowComponent( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }

    public class ScarecrowAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new ScarecrowDeed(); } }

        [Constructable]
        public ScarecrowAddon() : base()
        {
            AddComponent( new ScarecrowComponent(), 0, 0, 0 );
        }

        public ScarecrowAddon( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }

    public class ScarecrowDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new ScarecrowAddon(); } }
        public override int LabelNumber { get { return 1076608; } } // Scarecrow

        [Constructable]
        public ScarecrowDeed() : base()
        {
            LootType = LootType.Blessed;
        }

        public ScarecrowDeed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
