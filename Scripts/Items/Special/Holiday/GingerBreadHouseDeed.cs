/* ***************************************************************************
 * GingerBreadHouseDeed.cs
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
    public class GingerBreadHouseAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new GingerBreadHouseDeed(); } }

        public GingerBreadHouseAddon()
        {
            for( int i=0x2be5; i<0x2be8; i++ )
            {
                LocalizedAddonComponent laoc = new LocalizedAddonComponent( i, 1077395 ); // Gingerbread House
                laoc.Light = LightType.SouthSmall;
                AddComponent( laoc, (i==0x2be5) ? -1 : 0, (i==0x2be7) ? -1 : 0, 0 ); 
            }
        }

        public GingerBreadHouseAddon( Serial serial ) : base( serial )
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

    public class GingerBreadHouseDeed : BaseAddonDeed
    {
        public override int LabelNumber{ get{ return 1077394; } } //a Gingerbread House Deed
        public override BaseAddon Addon{ get{ return new GingerBreadHouseAddon(); } }

        [Constructable]
        public GingerBreadHouseDeed() 
        {
            Weight = 1.0;
            LootType = LootType.Blessed;
        }

        public GingerBreadHouseDeed( Serial serial ) : base( serial )
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

