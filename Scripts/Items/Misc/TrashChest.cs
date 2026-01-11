/* ***************************************************************************
 * TrashChest.cs
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

namespace Server.Items
{
	[FlipableAttribute( 0xE41, 0xE40 )]
	public class TrashChest : Container
	{
		public override int DefaultMaxWeight{ get{ return 0; } } // A value of 0 signals unlimited weight

		public override bool IsDecoContainer
		{
			get{ return false; }
		}

		[Constructable]
		public TrashChest() : base( 0xE41 )
		{
			Movable = false;
		}

		public TrashChest( Serial serial ) : base( serial )
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

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( !base.OnDragDrop( from, dropped ) )
				return false;

			PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, Utility.Random( 1042891, 8 ) );
			dropped.Delete();

			return true;
		}

		public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
		{
			if ( !base.OnDragDropInto( from, item, p ) )
				return false;

			PublicOverheadMessage( Network.MessageType.Regular, 0x3B2, Utility.Random( 1042891, 8 ) );
			item.Delete();

			return true;
		}
	}
}
