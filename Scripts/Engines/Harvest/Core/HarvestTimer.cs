/* ***************************************************************************
 * HarvestTimer.cs
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
	public class HarvestTimer : Timer
	{
		private Mobile m_From;
		private Item m_Tool;
		private HarvestSystem m_System;
		private HarvestDefinition m_Definition;
		private object m_ToHarvest, m_Locked;
		private int m_Index, m_Count;

		public HarvestTimer( Mobile from, Item tool, HarvestSystem system, HarvestDefinition def, object toHarvest, object locked ) : base( TimeSpan.Zero, def.EffectDelay )
		{
			m_From = from;
			m_Tool = tool;
			m_System = system;
			m_Definition = def;
			m_ToHarvest = toHarvest;
			m_Locked = locked;
			m_Count = Utility.RandomList( def.EffectCounts );
		}

		protected override void OnTick()
		{
			if ( !m_System.OnHarvesting( m_From, m_Tool, m_Definition, m_ToHarvest, m_Locked, ++m_Index == m_Count ) )
				Stop();
		}
	}
}
