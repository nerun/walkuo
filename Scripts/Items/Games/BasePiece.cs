/* ***************************************************************************
 * BasePiece.cs
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
	public class BasePiece : Item
	{
		private BaseBoard m_Board;

		public BaseBoard Board
		{
			get { return m_Board; }
			set { m_Board = value; }
		}

		public override bool IsVirtualItem{ get{ return true; } }

		public BasePiece( int itemID, BaseBoard board ) : base( itemID )
		{
			m_Board = board;
		}

		public BasePiece( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( m_Board );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Board = (BaseBoard)reader.ReadItem();

					if ( m_Board == null || Parent == null )
						Delete();

					break;
				}
			}
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( m_Board == null || m_Board.Deleted )
				Delete();
			else if ( !IsChildOf( m_Board ) )
				m_Board.DropItem( this );
			else
				base.OnSingleClick( from );
		}

		public override bool OnDragLift( Mobile from )
		{
			if ( m_Board == null || m_Board.Deleted )
			{
				Delete();
				return false;
			}
			else if ( !IsChildOf( m_Board ) )
			{
				m_Board.DropItem( this );
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool CanTarget{ get{ return false; } }

		public override bool DropToMobile( Mobile from, Mobile target, Point3D p )
		{
			return false;
		}

		public override bool DropToItem( Mobile from, Item target, Point3D p )
		{
			return ( target == m_Board && p.X != -1 && p.Y != -1 && base.DropToItem( from, target, p ) );
		}

		public override bool DropToWorld( Mobile from, Point3D p )
		{
			return false;
		}

		public override int GetLiftSound( Mobile from )
		{
			return -1;
		}
	}
}
