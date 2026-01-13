/* ***************************************************************************
 * ElvenLoveseatEastAddon.cs
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
    public class ElvenLoveseatEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new ElvenLoveseatEastDeed(); } }

        [Constructable]
        public ElvenLoveseatEastAddon()
        {
            AddComponent( new AddonComponent( 0x3089 ), 0, 0, 0 );
            AddComponent( new AddonComponent( 0x3088 ), 1, 0, 0 );
        }

        public ElvenLoveseatEastAddon( Serial serial ) : base( serial )
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

    public class ElvenLoveseatEastDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new ElvenLoveseatEastAddon(); } }
        public override int LabelNumber{ get{ return 1073372; } } // elven loveseat (east)

        [Constructable]
        public ElvenLoveseatEastDeed()
        {
        }

        public ElvenLoveseatEastDeed( Serial serial ) : base( serial )
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
