/* ***************************************************************************
 * ScribeStone.cs
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

namespace Server.Items
{
	public class ScribeStone : Item
	{
		public override string DefaultName
		{
			get { return "a Scribe Supply Stone"; }
		}

		[Constructable]
		public ScribeStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 0x105;
		}

		public override void OnDoubleClick( Mobile from )
		{
			ScribeBag scribeBag = new ScribeBag();

			if ( !from.AddToBackpack( scribeBag ) )
				scribeBag.Delete();
		}

		public ScribeStone( Serial serial ) : base( serial )
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
	}
}
