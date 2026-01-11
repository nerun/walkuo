/* ***************************************************************************
 * HarvestBank.cs
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
	public class HarvestBank
	{
		private int m_Current;
		private int m_Maximum;
		private DateTime m_NextRespawn;
		private HarvestVein m_Vein, m_DefaultVein;

		HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get { return m_Definition; }
		}

		public int Current
		{
			get
			{
				CheckRespawn();
				return m_Current;
			}
		}

		public HarvestVein Vein
		{
			get
			{
				CheckRespawn();
				return m_Vein;
			}
			set
			{
				m_Vein = value;
			}
		}

		public HarvestVein DefaultVein
		{
			get
			{
				CheckRespawn();
				return m_DefaultVein;
			}
		}

		public void CheckRespawn()
		{
			if ( m_Current == m_Maximum || m_NextRespawn > DateTime.UtcNow )
				return;

			m_Current = m_Maximum;

			if ( m_Definition.RandomizeVeins )
			{
				m_DefaultVein = m_Definition.GetVeinFrom( Utility.RandomDouble() );
			}

			m_Vein = m_DefaultVein;
		}

		public void Consume( int amount, Mobile from )
		{
			CheckRespawn();

			if ( m_Current == m_Maximum )
			{
				double min = m_Definition.MinRespawn.TotalMinutes;
				double max = m_Definition.MaxRespawn.TotalMinutes;
				double rnd = Utility.RandomDouble();

				m_Current = m_Maximum - amount;

				double minutes = min + (rnd * (max - min));
				if ( m_Definition.RaceBonus && from.Race == Race.Elf )	//def.RaceBonus = Core.ML
					minutes *= .75;	//25% off the time.  

				m_NextRespawn = DateTime.UtcNow + TimeSpan.FromMinutes( minutes );
			}
			else
			{
				m_Current -= amount;
			}

			if ( m_Current < 0 )
				m_Current = 0;
		}

		public HarvestBank( HarvestDefinition def, HarvestVein defaultVein )
		{
			m_Maximum = Utility.RandomMinMax( def.MinTotal, def.MaxTotal );
			m_Current = m_Maximum;
			m_DefaultVein = defaultVein;
			m_Vein = m_DefaultVein;

			m_Definition = def;
		}
	}
}
