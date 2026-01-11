/* ***************************************************************************
 * ShrineOfWisdomAddon.cs
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
	public class ShrineOfWisdomAddon : BaseAddon
	{
		[Constructable]
		public ShrineOfWisdomAddon()
		{
			AddComponent( new ShrineOfWisdomComponent( 0x14C3 ), 0, 0, 0 );
			AddComponent( new ShrineOfWisdomComponent( 0x14C6 ), 1, 0, 0 );
			AddComponent( new ShrineOfWisdomComponent( 0x14D4 ), 0, 1, 0 );
			AddComponent( new ShrineOfWisdomComponent( 0x14D5 ), 1, 1, 0 );
			Hue = 0x47E;
		}

		public ShrineOfWisdomAddon( Serial serial ) : base( serial )
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

	[Server.Engines.Craft.Forge]
	public class ShrineOfWisdomComponent : AddonComponent
	{
		public override int LabelNumber{ get{ return 1062046; } } // Shrine of Wisdom

		[Constructable]
		public ShrineOfWisdomComponent( int itemID ) : base( itemID )
		{
		}

		public ShrineOfWisdomComponent( Serial serial ) : base( serial )
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
