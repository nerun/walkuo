/* ***************************************************************************
 * Portcullis.cs
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
	public class PortcullisNS : BaseDoor
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public PortcullisNS() : base( 0x6F5, 0x6F5, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public PortcullisNS( Serial serial ) : base( serial )
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

	public class PortcullisEW : BaseDoor
	{
		public override bool UseChainedFunctionality{ get{ return true; } }

		[Constructable]
		public PortcullisEW() : base( 0x6F6, 0x6F6, 0xF0, 0xEF, new Point3D( 0, 0, 20 ) )
		{
		}

		public PortcullisEW( Serial serial ) : base( serial )
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
