/* ***************************************************************************
 * StandingBrokenChair.cs
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
    [Flipable( 0xC1B, 0xC1C, 0xC1E, 0xC1D )]
    public class StandingBrokenChairComponent : AddonComponent
    {
        public override int LabelNumber { get { return 1076259; } } // Standing Broken Chair

        public StandingBrokenChairComponent() : base( 0xC1B )
        {
        }

        public StandingBrokenChairComponent( Serial serial ) : base( serial )
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

    public class StandingBrokenChairAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new StandingBrokenChairDeed(); } }

        [Constructable]
        public StandingBrokenChairAddon() : base()
        {
            AddComponent( new StandingBrokenChairComponent(), 0, 0, 0 );
        }

        public StandingBrokenChairAddon( Serial serial ) : base( serial )
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

    public class StandingBrokenChairDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new StandingBrokenChairAddon(); } }
        public override int LabelNumber { get { return 1076259; } } // Standing Broken Chair

        [Constructable]
        public StandingBrokenChairDeed() : base()
        {
            LootType = LootType.Blessed;
        }

        public StandingBrokenChairDeed( Serial serial ) : base( serial )
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
