/* ***************************************************************************
 * QuiverOfInfinity.cs
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
﻿using System;

namespace Server.Items
{
	public class QuiverOfInfinity : BaseQuiver, ITokunoDyable
	{
		public override int LabelNumber { get { return 1075201; } } // Quiver of Infinity

		[Constructable]
		public QuiverOfInfinity() : base( 0x2B02 )
		{
			LootType = LootType.Blessed;
			Weight = 8.0;

			WeightReduction = 30;
			LowerAmmoCost = 20;

			Attributes.DefendChance = 5;
		}

		public QuiverOfInfinity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 2 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			if ( version < 1 && DamageIncrease == 0 )
				DamageIncrease = 10;

			if ( version < 2 && Attributes.WeaponDamage == 10 )
				Attributes.WeaponDamage = 0;
		}
	}
}
