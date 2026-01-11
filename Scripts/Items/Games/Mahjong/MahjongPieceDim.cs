/* ***************************************************************************
 * MahjongPieceDim.cs
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

namespace Server.Engines.Mahjong
{
	public struct MahjongPieceDim
	{
		private Point2D m_Position;
		private int m_Width;
		private int m_Height;

		public Point2D Position { get { return m_Position; } }
		public int Width { get { return m_Width; } }
		public int Height { get { return m_Height; } }

		public MahjongPieceDim( Point2D position, int width, int height )
		{
			m_Position = position;
			m_Width = width;
			m_Height = height;
		}

		public bool IsValid()
		{
			return m_Position.X >= 0 && m_Position.Y >= 0 && m_Position.X + m_Width <= 670 && m_Position.Y + m_Height <= 670;
		}

		public bool IsOverlapping( MahjongPieceDim dim )
		{
			return m_Position.X < dim.m_Position.X + dim.m_Width && m_Position.Y < dim.m_Position.Y + dim.m_Height && m_Position.X + m_Width > dim.m_Position.X && m_Position.Y + m_Height > dim.m_Position.Y;
		}

		public int GetHandArea()
		{
			if ( m_Position.X + m_Width > 150 && m_Position.X < 520 && m_Position.Y < 35 )
				return 0;

			if ( m_Position.X + m_Width > 635 && m_Position.Y + m_Height > 150 && m_Position.Y < 520 )
				return 1;

			if ( m_Position.X + m_Width > 150 && m_Position.X < 520 && m_Position.Y + m_Height > 635 )
				return 2;

			if ( m_Position.X < 35 && m_Position.Y + m_Height > 150 && m_Position.Y < 520 )
				return 3;

			return -1;
		}
	}
}
