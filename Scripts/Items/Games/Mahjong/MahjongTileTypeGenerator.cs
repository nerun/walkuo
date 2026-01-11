/* ***************************************************************************
 * MahjongTileTypeGenerator.cs
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
using System.Collections;
using Server;

namespace Server.Engines.Mahjong
{
	public class MahjongTileTypeGenerator
	{
		private ArrayList m_LeftTileTypes;

		public ArrayList LeftTileTypes { get { return m_LeftTileTypes; } }

		public MahjongTileTypeGenerator( int count )
		{
			m_LeftTileTypes = new ArrayList( 34 * count );

			for ( int i = 1; i <= 34; i++ )
			{
				for ( int j = 0; j < count; j++ )
				{
					m_LeftTileTypes.Add( (MahjongTileType)i );
				}
			}
		}

		public MahjongTileType Next()
		{
			int random = Utility.Random( m_LeftTileTypes.Count );
			MahjongTileType next = (MahjongTileType)m_LeftTileTypes[random];
			m_LeftTileTypes.RemoveAt( random );

			return next;
		}
	}
}
