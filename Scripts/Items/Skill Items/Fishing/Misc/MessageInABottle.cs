/* ***************************************************************************
 * MessageInABottle.cs
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
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class MessageInABottle : Item
	{
		public static int GetRandomLevel()
		{
			if ( Core.AOS && 1 > Utility.Random( 25 ) )
				return 4; // ancient

			return Utility.RandomMinMax( 1, 3 );
		}

		public override int LabelNumber{ get{ return 1041080; } } // a message in a bottle

		private Map m_TargetMap;
		private int m_Level;

		[CommandProperty( AccessLevel.GameMaster )]
		public Map TargetMap
		{
			get{ return m_TargetMap; }
			set{ m_TargetMap = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level
		{
			get{ return m_Level; }
			set{ m_Level = Math.Max( 1, Math.Min( value, 4 ) ); }
		}

		[Constructable]
		public MessageInABottle() : this( Map.Trammel )
		{
		}

		public MessageInABottle( Map map ) : this( map, GetRandomLevel() )
		{
		}

		[Constructable]
		public MessageInABottle( Map map, int level ) : base( 0x099F )
		{
			Weight = 1.0;
			m_TargetMap = map;
			m_Level = level;
		}

		public MessageInABottle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 3 ); // version

			writer.Write( (int) m_Level );

			writer.Write( m_TargetMap );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				case 2:
				{
					m_Level = reader.ReadInt();
					goto case 1;
				}
				case 1:
				{
					m_TargetMap = reader.ReadMap();
					break;
				}
				case 0:
				{
					m_TargetMap = Map.Trammel;
					break;
				}
			}

			if ( version < 2 )
				m_Level = GetRandomLevel();

			if( version < 3 && m_TargetMap == Map.Tokuno )
				m_TargetMap = Map.Trammel;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				ReplaceWith( new SOS( m_TargetMap, m_Level ) );
				from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 501891 ); // You extract the message from the bottle.
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
	}
}
