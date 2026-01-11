/* ***************************************************************************
 * LargeBedSouthAddon.cs
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
	public class LargeBedSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new LargeBedSouthDeed(); } }

		[Constructable]
		public LargeBedSouthAddon()
		{
			AddComponent( new AddonComponent( 0xA83 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 0xA7F ), 0, 1, 0 );
			AddComponent( new AddonComponent( 0xA82 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 0xA7E ), 1, 1, 0 );
		}

		public LargeBedSouthAddon( Serial serial ) : base( serial )
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

	public class LargeBedSouthDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new LargeBedSouthAddon(); } }
		public override int LabelNumber{ get{ return 1044323; } } // large bed (south)

		[Constructable]
		public LargeBedSouthDeed()
		{
		}

		public LargeBedSouthDeed( Serial serial ) : base( serial )
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
