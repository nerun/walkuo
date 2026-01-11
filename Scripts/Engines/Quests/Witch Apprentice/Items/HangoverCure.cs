/* ***************************************************************************
 * HangoverCure.cs
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

namespace Server.Engines.Quests.Hag
{
	public class HangoverCure : Item
	{
		private int m_Uses;

		public override int LabelNumber{ get{ return 1055060; } } // Grizelda's Extra Strength Hangover Cure

		[CommandProperty( AccessLevel.GameMaster )]
		public int Uses
		{
			get{ return m_Uses; }
			set{ m_Uses = value; }
		}

		[Constructable]
		public HangoverCure() : base( 0xE2B )
		{
			Weight = 1.0;
			Hue = 0x2D;

			m_Uses = 20;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				SendLocalizedMessageTo( from, 1042038 ); // You must have the object in your backpack to use it.
				return;
			}

			if ( m_Uses > 0 )
			{
				from.PlaySound( 0x2D6 );
				from.SendLocalizedMessage( 501206 ); // An awful taste fills your mouth.

				if ( from.BAC > 0 )
				{
					from.BAC = 0;
					from.SendLocalizedMessage( 501204 ); // You are now sober!
				}

				m_Uses--;
			}
			else
			{
				Delete();
				from.SendLocalizedMessage( 501201 ); // There wasn't enough left to have any effect.
			}
		}

		public HangoverCure( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.WriteEncodedInt( m_Uses );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Uses = reader.ReadEncodedInt();
					break;
				}
				case 0:
				{
					m_Uses = 20;
					break;
				}
			}
		}
	}
}
