/* ***************************************************************************
 * HeritageToken.cs
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
﻿using System;
using Server;
using Server.Gumps;

namespace Server.Items
{
	public interface ITokunoDyable
	{
	}

	public class HeritageToken : Item
	{
		public override int LabelNumber { get { return 1076596; } } // A Heritage Token

		[Constructable]
		public HeritageToken() : base( 0x367A )
		{
			LootType = LootType.Blessed;
			Weight = 5.0;
		}

		public HeritageToken( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.CloseGump( typeof( HeritageTokenGump ) );
				from.SendGump( new HeritageTokenGump( this ) );
			}
			else
				from.SendLocalizedMessage( 1062334 ); // This item must be in your backpack to be used.
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1070998, String.Format( "#{0}", 1076595 ) );  // Use this to redeem<br>Your Heritage Items
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
