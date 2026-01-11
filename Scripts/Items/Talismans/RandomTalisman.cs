/* ***************************************************************************
 * RandomTalisman.cs
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
using Server.Items;

namespace Server.Items
{
	public class RandomTalisman : BaseTalisman
	{
		[Constructable]
		public RandomTalisman() : base( GetRandomItemID() )
		{
			Summoner = BaseTalisman.GetRandomSummoner();

			if ( Summoner.IsEmpty )
			{
				Removal = BaseTalisman.GetRandomRemoval();

				if ( Removal != TalismanRemoval.None )
				{
					MaxCharges = BaseTalisman.GetRandomCharges();
					MaxChargeTime = 1200;
				}
			}
			else
			{
				MaxCharges = Utility.RandomMinMax( 10, 50 );

				if ( Summoner.IsItem )
					MaxChargeTime = 60;
				else
					MaxChargeTime = 1800;
			}

			Blessed = BaseTalisman.GetRandomBlessed();
			Slayer = BaseTalisman.GetRandomSlayer();
			Protection = BaseTalisman.GetRandomProtection();
			Killer = BaseTalisman.GetRandomKiller();
			Skill = BaseTalisman.GetRandomSkill();
			ExceptionalBonus = BaseTalisman.GetRandomExceptional();
			SuccessBonus = BaseTalisman.GetRandomSuccessful();
			Charges = MaxCharges;
		}

		public RandomTalisman( Serial serial ) :  base( serial )
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
