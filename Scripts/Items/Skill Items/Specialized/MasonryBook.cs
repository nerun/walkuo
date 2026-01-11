/* ***************************************************************************
 * MasonryBook.cs
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
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class MasonryBook : Item
	{
		public override string DefaultName
		{
			get { return "Making Valuables With Stonecrafting"; }
		}

		[Constructable]
		public MasonryBook() : base( 0xFBE )
		{
			Weight = 1.0;
		}

		public MasonryBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else if ( pm == null || from.Skills[SkillName.Carpentry].Base < 100.0 )
			{
				pm.SendMessage( "Only a Grandmaster Carpenter can learn from this book." );
			}
			else if ( pm.Masonry )
			{
				pm.SendMessage( "You have already learned this information." );
			}
			else
			{
				pm.Masonry = true;
				pm.SendMessage( "You have learned to make items from stone. You will need miners to gather stones for you to make these items." );
				Delete();
			}
		}
	}
}
