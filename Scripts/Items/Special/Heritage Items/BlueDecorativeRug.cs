/* ***************************************************************************
 * BlueDecorativeRug.cs
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
	public class BlueDecorativeRugAddon : BaseAddon
	{
		public override BaseAddonDeed Deed { get { return new BlueDecorativeRugDeed(); } }
		
		[Constructable]
		public BlueDecorativeRugAddon() : base()
		{
			AddComponent( new LocalizedAddonComponent( 0xAD2, 1076589 ), 1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD3, 1076589 ), -1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD4, 1076589 ), -1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD5, 1076589 ), 1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD6, 1076589 ), -1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD7, 1076589 ), 0, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD8, 1076589 ), 1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD9, 1076589 ), 0, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAD1, 1076589 ), 0, 0, 0 );
		}

		public BlueDecorativeRugAddon( Serial serial ) : base( serial )
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

	public class BlueDecorativeRugDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new BlueDecorativeRugAddon(); } }
		public override int LabelNumber { get { return 1076589; } } // Blue decorative rug

		[Constructable]
		public BlueDecorativeRugDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public BlueDecorativeRugDeed( Serial serial ) : base( serial )
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
