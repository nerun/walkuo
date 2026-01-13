/* ***************************************************************************
 * SquirrelStatueEastAddon.cs
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
    public class SquirrelStatueEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new SquirrelStatueEastDeed(); } }

        [Constructable]
        public SquirrelStatueEastAddon()
        {
            AddComponent( new AddonComponent( 0x2D10 ), 0, 0, 0 );
        }

        public SquirrelStatueEastAddon( Serial serial ) : base( serial )
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

    public class SquirrelStatueEastDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new SquirrelStatueEastAddon(); } }
        public override int LabelNumber{ get{ return 1073398; } } // squirrel statue (east)

        [Constructable]
        public SquirrelStatueEastDeed()
        {
        }

        public SquirrelStatueEastDeed( Serial serial ) : base( serial )
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
