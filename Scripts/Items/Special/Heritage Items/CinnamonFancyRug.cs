/* ***************************************************************************
 * CinnamonFancyRug.cs
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
	public class CinnamonFancyRugAddon : BaseAddon
	{
		public override BaseAddonDeed Deed { get { return new CinnamonFancyRugDeed(); } }

		[Constructable]
		public CinnamonFancyRugAddon() : base()
		{
			AddComponent( new LocalizedAddonComponent( 0xAE3, 1076587 ), 1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE4, 1076587 ), -1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE5, 1076587 ), -1, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE6, 1076587 ), 1, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE7, 1076587 ), -1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE8, 1076587 ), 0, -1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAE9, 1076587 ), 1, 0, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAEA, 1076587 ), 0, 1, 0 );
			AddComponent( new LocalizedAddonComponent( 0xAEB, 1076587 ), 0, 0, 0 );
		}

		public CinnamonFancyRugAddon( Serial serial ) : base( serial )
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

	public class CinnamonFancyRugDeed : BaseAddonDeed
	{
		public override BaseAddon Addon { get { return new CinnamonFancyRugAddon(); } }
		public override int LabelNumber { get { return 1076587; } } // Cinnamon fancy rug

		[Constructable]
		public CinnamonFancyRugDeed() : base()
		{
			LootType = LootType.Blessed;
		}

		public CinnamonFancyRugDeed( Serial serial ) : base( serial )
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
