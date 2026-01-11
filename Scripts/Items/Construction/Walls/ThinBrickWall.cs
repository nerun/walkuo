/* ***************************************************************************
 * ThinBrickWall.cs
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
	public enum ThinBrickWallTypes
	{
		Corner,
		SouthWall,
		EastWall,
		CornerPost,
		EastDoorFrame,
		SouthDoorFrame,
		WestDoorFrame,
		NorthDoorFrame,
		SouthWindow,
		EastWindow,
		CornerMedium,
		SouthWallMedium,
		EastWallMedium,
		CornerPostMedium,
		CornerShort,
		SouthWallShort,
		EastWallShort,
		CornerPostShort,
		CornerArch,
		SouthArch,
		WestArch,
		EastArch,
		NorthArch,
		SouthCenterArchTall,
		EastCenterArchTall,
		EastCornerArchTall,
		SouthCornerArchTall,
		SouthCornerArch,
		EastCornerArch,
		SouthCenterArch,
		EastCenterArch,
		CornerVVShort,
		SouthWallVVShort,
		EastWallVVShort,
		SouthWallVShort,
		EastWallVShort
	};

	public class ThinBrickWall : BaseWall
	{
		[Constructable]
		public ThinBrickWall( ThinBrickWallTypes type ) : base( 0x0033 + (int)type )
		{
		}

		public ThinBrickWall( Serial serial ) : base( serial )
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
