/* ***************************************************************************
 * MahjongEnums.cs
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

namespace Server.Engines.Mahjong
{
	public enum MahjongPieceDirection
	{
		Up,
		Left,
		Down,
		Right
	}

	public enum MahjongWind
	{
		North,
		East,
		South,
		West
	}

	public enum MahjongTileType
	{
		Dagger1 = 1,
		Dagger2,
		Dagger3,
		Dagger4,
		Dagger5,
		Dagger6,
		Dagger7,
		Dagger8,
		Dagger9,
		Gem1,
		Gem2,
		Gem3,
		Gem4,
		Gem5,
		Gem6,
		Gem7,
		Gem8,
		Gem9,
		Number1,
		Number2,
		Number3,
		Number4,
		Number5,
		Number6,
		Number7,
		Number8,
		Number9,
		North,
		East,
		South,
		West,
		Green,
		Red,
		White
	}
}
