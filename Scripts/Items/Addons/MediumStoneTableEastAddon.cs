/* ***************************************************************************
 * MediumStoneTableEastAddon.cs
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
    public class MediumStoneTableEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new MediumStoneTableEastDeed(); } }

        public override bool RetainDeedHue{ get{ return true; } }

        [Constructable]
        public MediumStoneTableEastAddon() : this( 0 )
        {
        }

        [Constructable]
        public MediumStoneTableEastAddon( int hue )
        {
            AddComponent( new AddonComponent( 0x1202 ), 0, 0, 0 );
            AddComponent( new AddonComponent( 0x1201 ), 0, 1, 0 );
            Hue = hue;
        }

        public MediumStoneTableEastAddon( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }

    public class MediumStoneTableEastDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new MediumStoneTableEastAddon( this.Hue ); } }
        public override int LabelNumber{ get{ return 1044508; } } // stone table (east)

        [Constructable]
        public MediumStoneTableEastDeed()
        {
        }

        public MediumStoneTableEastDeed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
