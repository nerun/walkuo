/* ***************************************************************************
 * MahjongDices.cs
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
	public class MahjongDices
	{
		private MahjongGame m_Game;
		private int m_First;
		private int m_Second;

		public MahjongGame Game { get { return m_Game; } }
		public int First { get { return m_First; } }
		public int Second { get { return m_Second; } }

		public MahjongDices( MahjongGame game )
		{
			m_Game = game;
			m_First = Utility.Random( 1, 6 );
			m_Second = Utility.Random( 1, 6 );
		}

		public void RollDices( Mobile from )
		{
			m_First = Utility.Random( 1, 6 );
			m_Second = Utility.Random( 1, 6 );

			m_Game.Players.SendGeneralPacket( true, true );

			if ( from != null )
				m_Game.Players.SendLocalizedMessage( 1062695, string.Format( "{0}\t{1}\t{2}", from.Name, m_First, m_Second ) ); // ~1_name~ rolls the dice and gets a ~2_number~ and a ~3_number~!
		}

		public void Save( GenericWriter writer )
		{
			writer.Write( (int) 0 ); // version

			writer.Write( m_First );
			writer.Write( m_Second );
		}

		public MahjongDices( MahjongGame game, GenericReader reader )
		{
			m_Game = game;

			int version = reader.ReadInt();

			m_First = reader.ReadInt();
			m_Second = reader.ReadInt();
		}
	}
}
