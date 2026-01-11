/* ***************************************************************************
 * ArcaneCircleAddon.cs
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
using System.Collections.Generic;
using Server;

namespace Server.Items
{
	public class ArcaneCircleAddon : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new ArcaneCircleDeed(); } }

		[Constructable]
		public ArcaneCircleAddon()
		{
			AddComponent( new AddonComponent( 0x3083 ), -1, -1, 0 );
			AddComponent( new AddonComponent( 0x3080 ), -1,  0, 0 );
			AddComponent( new AddonComponent( 0x3082 ),  0, -1, 0 );
			AddComponent( new AddonComponent( 0x3081 ),  1, -1, 0 );
			AddComponent( new AddonComponent( 0x307D ), -1,  1, 0 );
			AddComponent( new AddonComponent( 0x307F ),  0,  0, 0 );
			AddComponent( new AddonComponent( 0x307E ),  1,  0, 0 );
			AddComponent( new AddonComponent( 0x307C ),  0,  1, 0 );
			AddComponent( new AddonComponent( 0x307B ),  1,  1, 0 );
		}

		public ArcaneCircleAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			if ( version == 0 )
				ValidationQueue<ArcaneCircleAddon>.Add( this );
		}

		public void Validate()
		{
			foreach ( AddonComponent c in Components )
			{
				if ( c.ItemID == 0x3083 )
				{
					c.Offset = new Point3D( -1, -1, 0 );
					c.MoveToWorld( new Point3D( X + c.Offset.X, Y + c.Offset.Y, Z + c.Offset.Z ), Map );
				}
			}
		}
	}

	public class ArcaneCircleDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new ArcaneCircleAddon(); } }
		public override int LabelNumber{ get{ return 1072703; } } // arcane circle

		[Constructable]
		public ArcaneCircleDeed()
		{
		}

		public ArcaneCircleDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
