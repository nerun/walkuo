/* ***************************************************************************
 * TreasuresOfTokunoPersistance.cs
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
using System.Collections.Generic;

namespace Server.Misc
{
	public class TreasuresOfTokunoPersistance : Item
	{
		private static TreasuresOfTokunoPersistance m_Instance;

		public static TreasuresOfTokunoPersistance Instance{ get{ return m_Instance; } }

		public override string DefaultName
		{
			get { return "TreasuresOfTokuno Persistance - Internal"; }
		}

		public static void Initialize()
		{
			if ( m_Instance == null )
				new TreasuresOfTokunoPersistance();
		}

		public TreasuresOfTokunoPersistance() : base( 1 )
		{
			Movable = false;

			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}

		public TreasuresOfTokunoPersistance( Serial serial ) : base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int)TreasuresOfTokuno.RewardEra );
			writer.WriteEncodedInt( (int)TreasuresOfTokuno.DropEra );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					TreasuresOfTokuno.RewardEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();
					TreasuresOfTokuno.DropEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();
					
					break;
				}
			}
		}

		public override void Delete()
		{
		}
	}
}
