/* ***************************************************************************
 * ArcanistStatueEastAddon.cs
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
    public class ArcanistStatueEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new ArcanistStatueEastDeed(); } }

        [Constructable]
        public ArcanistStatueEastAddon()
        {
            AddComponent( new AddonComponent( 0x2D0E ), 0, 0, 0 );
        }

        public ArcanistStatueEastAddon( Serial serial ) : base( serial )
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

    public class ArcanistStatueEastDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new ArcanistStatueEastAddon(); } }
        public override int LabelNumber{ get{ return 1072886; } } // arcanist statue (east)

        [Constructable]
        public ArcanistStatueEastDeed()
        {
        }

        public ArcanistStatueEastDeed( Serial serial ) : base( serial )
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
