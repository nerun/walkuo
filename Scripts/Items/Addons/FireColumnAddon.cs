/* ***************************************************************************
 * FireColumnAddon.cs
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
using System.Text;
using System.Net;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class FireColumnAddon : BaseAddon
	{
		public override bool ShareHue
		{
			get { return false; }
		}

		[Constructable]
		public FireColumnAddon()
			: this( false )
		{
		}

		[Constructable]
		public FireColumnAddon( bool bloody )
		{
			AddComponent( new AddonComponent( 0x3A5 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 0x3A5 ), 0, 0, 5 );
			AddComponent( new AddonComponent( 0x3A5 ), 0, 0, 10 );
			AddComponent( new AddonComponent( 0x3A5 ), 0, 0, 15 );

			AddComponent( new AddonComponent( 0x19BB ), 0, 0, 21 );
			AddComponent( new AddonComponent( 0x19AB ), 0, 0, 23 );

			if ( bloody )
			{
				AddComponent( new AddonComponent( 0x122B ), -2, 0, 0 );
				AddComponent( new AddonComponent( 0x122E ), 0, -2, 0 );
				AddComponent( new AddonComponent( 0x122D ), -1, 1, 0 );
				AddComponent( new AddonComponent( 0x122F ), 1, -1, 0 );
				AddComponent( new AddonComponent( 0x122D ), 0, 1, 0 );
				AddComponent( new AddonComponent( 0x122A ), 1, 0, 0 );
				AddComponent( new AddonComponent( 0x122B ), 2, -1, 0 );
				AddComponent( new AddonComponent( 0x122B ), 0, 2, 0 );
				AddComponent( new AddonComponent( 0x122E ), 1, 1, 0 );
			}
		}

		public FireColumnAddon( Serial serial )
			: base( serial )
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
