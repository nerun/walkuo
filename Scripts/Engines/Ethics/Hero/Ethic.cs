/* ***************************************************************************
 * Ethic.cs
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
using System.Text;
using Server.Factions;

namespace Server.Ethics.Hero
{
	public sealed class HeroEthic : Ethic
	{
		public HeroEthic()
		{
			m_Definition = new EthicDefinition(
					0x482,
					"Hero", "(Hero)",
					"I will defend the virtues",
					new Power[]
					{
						new HolySense(),
						new HolyItem(),
						new SummonFamiliar(),
						new HolyBlade(),
						new Bless(),
						new HolyShield(),
						new HolySteed(),
						new HolyWord()
					}
				);
		}

		public override bool IsEligible( Mobile mob )
		{
			if ( mob.Kills >= 5 )
				return false;

			Faction fac = Faction.Find( mob );

			return ( fac is TrueBritannians || fac is CouncilOfMages );
		}
	}
}
