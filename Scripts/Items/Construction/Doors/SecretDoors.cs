/* ***************************************************************************
 * SecretDoors.cs
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
	public class SecretStoneDoor1 : BaseDoor
	{
		[Constructable]
		public SecretStoneDoor1( DoorFacing facing ) : base( 0xE8 + (2 * (int)facing), 0xE9 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretStoneDoor1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SecretDungeonDoor : BaseDoor
	{
		[Constructable]
		public SecretDungeonDoor( DoorFacing facing ) : base( 0x314 + (2 * (int)facing), 0x315 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretDungeonDoor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SecretStoneDoor2 : BaseDoor
	{
		[Constructable]
		public SecretStoneDoor2( DoorFacing facing ) : base( 0x324 + (2 * (int)facing), 0x325 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretStoneDoor2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SecretWoodenDoor : BaseDoor
	{
		[Constructable]
		public SecretWoodenDoor( DoorFacing facing ) : base( 0x334 + (2 * (int)facing), 0x335 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretWoodenDoor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SecretLightWoodDoor : BaseDoor
	{
		[Constructable]
		public SecretLightWoodDoor( DoorFacing facing ) : base( 0x344 + (2 * (int)facing), 0x345 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretLightWoodDoor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SecretStoneDoor3 : BaseDoor
	{
		[Constructable]
		public SecretStoneDoor3( DoorFacing facing ) : base( 0x354 + (2 * (int)facing), 0x355 + (2 * (int)facing), 0xED, 0xF4, BaseDoor.GetOffset( facing ) )
		{
		}

		public SecretStoneDoor3( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer ) // Default Serialize method
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader ) // Default Deserialize method
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
