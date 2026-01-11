/* ***************************************************************************
 * SnowPiles.cs
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
﻿namespace Server.Items
{
	public class SnowPileDeco : Item
	{
		public override string DefaultName{ get { return "Snow Pile"; } }
		public override double DefaultWeight{ get { return 2.0; } }

		private static readonly int[] m_Types = new int[] { 0x8E2, 0x8E0, 0x8E6, 0x8E5, 0x8E3 };

		[Constructable]
		public SnowPileDeco()
			: this(m_Types[Utility.Random(m_Types.Length)])
		{
		}

		[Constructable]
		public SnowPileDeco( int itemid )
			: base(itemid)
		{
			Hue = 0x481;
		}

		public SnowPileDeco(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
