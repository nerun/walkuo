/* ***************************************************************************
 * Screens.cs
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
	[Furniture]
	[Flipable( 0x24D0, 0x24D1, 0x24D2, 0x24D3, 0x24D4 )]
	public class BambooScreen : Item
	{
		[Constructable]
		public BambooScreen() : base(0x24D0)
		{
			Weight = 20.0;
		}

		public BambooScreen(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

	[Furniture]
	[Flipable( 0x24CB, 0x24CC, 0x24CD, 0x24CE, 0x24CF )]
	public class ShojiScreen : Item
	{
		[Constructable]
		public ShojiScreen() : base(0x24CB)
		{
			Weight = 20.0;
		}

		public ShojiScreen(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}

}
