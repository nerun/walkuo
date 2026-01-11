/* ***************************************************************************
 * HarvestVein.cs
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

namespace Server.Engines.Harvest
{
	public class HarvestVein
	{
		private double m_VeinChance;
		private double m_ChanceToFallback;
		private HarvestResource m_PrimaryResource;
		private HarvestResource m_FallbackResource;

		public double VeinChance{ get{ return m_VeinChance; } set{ m_VeinChance = value; } }
		public double ChanceToFallback{ get{ return m_ChanceToFallback; } set{ m_ChanceToFallback = value; } }
		public HarvestResource PrimaryResource{ get{ return m_PrimaryResource; } set{ m_PrimaryResource = value; } }
		public HarvestResource FallbackResource{ get{ return m_FallbackResource; } set{ m_FallbackResource = value; } }

		public HarvestVein( double veinChance, double chanceToFallback, HarvestResource primaryResource, HarvestResource fallbackResource )
		{
			m_VeinChance = veinChance;
			m_ChanceToFallback = chanceToFallback;
			m_PrimaryResource = primaryResource;
			m_FallbackResource = fallbackResource;
		}
	}
}
