/* ***************************************************************************
 * ThinStoneWall.cs
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
	public enum ThinStoneWallTypes
	{
		Corner,
		EastWall,
		SouthWall,
		CornerPost,
		EastDoorFrame,
		SouthDoorFrame,
		NorthDoorFrame,
		WestDoorFrame,
		SouthWindow,
		EastWindow,
		CornerMedium,
		SouthWallMedium,
		EastWallMedium,
		CornerPostMedium,
		CornerArch,
		EastArch,
		SouthArch,
		NorthArch,
		WestArch,
		CornerShort,
		EastWallShort,
		SouthWallShort,
		CornerPostShort,
		SouthWallShort2,
		EastWallShort2
	}

	public class ThinStoneWall : BaseWall
	{
		[Constructable]
		public ThinStoneWall( ThinStoneWallTypes type ) : base( 0x001A + (int)type )
		{
		}

		public ThinStoneWall( Serial serial ) : base( serial )
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
