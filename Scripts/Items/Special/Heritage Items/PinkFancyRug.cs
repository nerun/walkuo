/* ***************************************************************************
 * PinkFancyRug.cs
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
	public class PinkFancyRugAddon : BaseAddon
	{
		public override BaseAddonDeed Deed { get { return new PinkFancyRugDeed(); } }

		[Constructable]
		public PinkFancyRugAddon() : base()
		{
			AddComponent( new LocalizedAddonComponent( 0xAEE, 1076590 ), 1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAEF, 1076590 ), -1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF0, 1076590 ), -1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF1, 1076590 ), 1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF2, 1076590 ), -1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF3, 1076590 ), 0, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF4, 1076590 ), 1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAF5, 1076590 ), 0, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAEC, 1076590 ), 0, 0, 0 );
		}

		public PinkFancyRugAddon( Serial serial ) : base( serial )
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

	public class PinkFancyRugDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new PinkFancyRugAddon(); } }
		public override int LabelNumber { get { return 1076590; } } // Pink fancy rug

		[Constructable]
		public PinkFancyRugDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public PinkFancyRugDeed( Serial serial ) : base( serial )
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
