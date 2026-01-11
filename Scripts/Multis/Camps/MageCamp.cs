/* ***************************************************************************
 * MageCamp.cs
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
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class MageCamp : BaseCamp
	{
		[Constructable]
		public MageCamp() : base( 0x1F5 )
		{
		}

		public override void AddComponents()
		{
			BaseDoor west, east;

			AddItem( west = new LightWoodGate( DoorFacing.WestCW ), -4, 4, 7 );
			AddItem( east = new LightWoodGate( DoorFacing.EastCCW ), -3, 4, 7 );

			west.Link = east;
			east.Link = west;

			AddItem( new Sign( SignType.Mage, SignFacing.West ), -5, 5, -4 );

			AddMobile( new Mage(), 4, -4,  3, 7 );
			AddMobile( new Mage(), 5,  4, -2, 0 );
		}

		public MageCamp( Serial serial ) : base( serial )
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
