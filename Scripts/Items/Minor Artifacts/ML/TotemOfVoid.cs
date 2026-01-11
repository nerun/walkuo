/* ***************************************************************************
 * TotemOfVoid.cs
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
using Server.Mobiles;

namespace Server.Items
{
	public class TotemOfVoid : BaseTalisman
	{
		public override int LabelNumber{ get{ return 1075035; } } // Totem of the Void
		public override bool ForceShowName{ get{ return true; } }

		[Constructable]
		public TotemOfVoid() : base( 0x2F5B )
		{
			Hue = 0x2D0;
			MaxChargeTime = 1800;

			Blessed = GetRandomBlessed();
			Protection = GetRandomProtection( false );

			Attributes.RegenHits = 2;
			Attributes.LowerManaCost = 10;
		}

		public TotemOfVoid( Serial serial ) :  base( serial )
		{
		}

		public override Type GetSummoner()
		{
			return Utility.RandomBool() ? typeof( SummonedSkeletalKnight ) : typeof( SummonedSheep );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version == 0 && ( Protection == null || Protection.IsEmpty ) )
				Protection = GetRandomProtection( false );
		}
	}
}
