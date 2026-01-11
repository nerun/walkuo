/* ***************************************************************************
 * WhiteClothDyeTub.cs
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
using Server;
using System;

namespace Server.Items /* High seas, loot from merchant ship's hold, also a "uncommon" loot item */
{
	public class WhiteClothDyeTub : DyeTub
	{
		public override int LabelNumber { get { return 1149984; } } // White Cloth Dye Tub

		public override bool Redyable { get { return false; } }

		[Constructable]
		public WhiteClothDyeTub()
		{
			DyedHue = Hue = 0x9C2;
		}

		public WhiteClothDyeTub( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
