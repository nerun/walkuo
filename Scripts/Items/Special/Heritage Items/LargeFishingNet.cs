/* ***************************************************************************
 * LargeFishingNet.cs
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
	[Flipable( 0x3D8E, 0x3D8F )]
	public class LargeFishingNetComponent : AddonComponent
	{
		public override int LabelNumber { get { return 1076285; } } // Large Fish Net

		public LargeFishingNetComponent() : base( 0x3D8E )
		{
		}

		public LargeFishingNetComponent( Serial serial ) : base( serial )
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

	public class LargeFishingNetAddon : BaseAddon
	{
		public override BaseAddonDeed Deed { get { return new LargeFishingNetDeed(); } }

		[Constructable]
		public LargeFishingNetAddon() : base()
		{
			AddComponent( new LargeFishingNetComponent(), 0, 0, 0 );
		}

		public LargeFishingNetAddon( Serial serial ) : base( serial )
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

	public class LargeFishingNetDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new LargeFishingNetAddon(); } }
		public override int LabelNumber { get { return 1076285; } } // Large Fish Net

		[Constructable]
		public LargeFishingNetDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public LargeFishingNetDeed( Serial serial ) : base( serial )
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
