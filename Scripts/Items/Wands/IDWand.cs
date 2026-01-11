/* ***************************************************************************
 * IDWand.cs
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
using Server.Targeting;

namespace Server.Items
{
	public class IDWand : BaseWand
	{
		public override TimeSpan GetUseDelay{ get{ return TimeSpan.Zero; } }

		[Constructable]
		public IDWand() : base( WandEffect.Identification, 25, 175 )
		{
		}

		public IDWand( Serial serial ) : base( serial )
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

		public override bool OnWandTarget( Mobile from, object o )
		{
			if ( o is BaseWeapon )
				((BaseWeapon)o).Identified = true;
			else if ( o is BaseArmor )
				((BaseArmor)o).Identified = true;

			if ( !Core.AOS && o is Item )
				((Item)o).OnSingleClick( from );

			return ( o is Item );
		}
	}
}
