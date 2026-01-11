/* ***************************************************************************
 * Tables.cs
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
	public class ElegantLowTable : Item
	{
		[Constructable]
		public ElegantLowTable() : base(0x2819)
		{
			Weight = 1.0;
		}

		public ElegantLowTable(Serial serial) : base(serial)
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
	public class PlainLowTable : Item
	{
		[Constructable]
		public PlainLowTable() : base(0x281A)
		{
			Weight = 1.0;
		}

		public PlainLowTable(Serial serial) : base(serial)
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
	[Flipable(0xB90,0xB7D)]
	public class LargeTable : Item
	{
		[Constructable]
		public LargeTable() : base(0xB90)
		{
			Weight = 1.0;
		}

		public LargeTable(Serial serial) : base(serial)
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

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	[Furniture]
	[Flipable(0xB35,0xB34)]
	public class Nightstand : Item
	{
		[Constructable]
		public Nightstand() : base(0xB35)
		{
			Weight = 1.0;
		}

		public Nightstand(Serial serial) : base(serial)
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

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}

	[Furniture]
	[Flipable(0xB8F,0xB7C)]
	public class YewWoodTable : Item
	{
		[Constructable]
		public YewWoodTable() : base(0xB8F)
		{
			Weight = 1.0;
		}

		public YewWoodTable(Serial serial) : base(serial)
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

			if ( Weight == 4.0 )
				Weight = 1.0;
		}
	}
}
