/* ***************************************************************************
 * ElvenStoveSouthAddon.cs
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
	public class ElvenStoveSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new ElvenStoveSouthDeed(); } }

		[Constructable]
		public ElvenStoveSouthAddon()
		{
			AddComponent( new AddonComponent( 0x2DDC ), 0, 0, 0 );
		}

		public ElvenStoveSouthAddon( Serial serial ) : base( serial )
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

	public class ElvenStoveSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new ElvenStoveSouthAddon(); } }
		public override int LabelNumber{ get{ return 1073394; } } // elven oven (south)

		[Constructable]
		public ElvenStoveSouthDeed()
		{
		}

		public ElvenStoveSouthDeed( Serial serial ) : base( serial )
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
