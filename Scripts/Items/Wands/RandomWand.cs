/* ***************************************************************************
 * RandomWand.cs
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
	public class RandomWand
	{
		public static BaseWand CreateWand()
		{
			return CreateRandomWand();
		}

		public static BaseWand CreateRandomWand()
		{
			return Loot.RandomWand();

			/*
			switch ( Utility.Random( 11 ) )
			{
				default:
				case  0: return new ClumsyWand();
				case  1: return new FeebleWand();
				case  2: return new FireballWand();
				case  3: return new GreaterHealWand();
				case  4: return new HarmWand();
				case  5: return new HealWand();
				case  6: return new IDWand();
				case  7: return new LightningWand();
				case  8: return new MagicArrowWand();
				case  9: return new ManaDrainWand();
				case 10: return new WeaknessWand();
			}
			*/
		}
	}
}
