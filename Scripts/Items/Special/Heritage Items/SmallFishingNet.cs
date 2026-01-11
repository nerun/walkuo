/* ***************************************************************************
 * SmallFishingNet.cs
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
	[Flipable( 0x1EA3, 0x1EA4 )]
	public class SmallFishingNetComponent : AddonComponent
	{
		public override int LabelNumber { get { return 1076286; } } // Small Fish Net

		public SmallFishingNetComponent() : base( 0x1EA3 )
		{
		}

		public SmallFishingNetComponent( Serial serial ) : base( serial )
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

	public class SmallFishingNetAddon : BaseAddon
	{
		public override BaseAddonDeed Deed { get { return new SmallFishingNetDeed(); } }

		[Constructable]
		public SmallFishingNetAddon() : base()
		{
			AddComponent( new SmallFishingNetComponent(), 0, 0, 0 );
		}

		public SmallFishingNetAddon( Serial serial ) : base( serial )
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

	public class SmallFishingNetDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new SmallFishingNetAddon(); } }
		public override int LabelNumber { get { return 1076286; } } // Small Fish Net

		[Constructable]
		public SmallFishingNetDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public SmallFishingNetDeed( Serial serial ) : base( serial )
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
