/* ***************************************************************************
 * RewardList.cs
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

namespace Server.Engines.VeteranRewards
{
	public class RewardList
	{
		private TimeSpan m_Age;
		private RewardEntry[] m_Entries;

		public TimeSpan Age{ get{ return m_Age; } }
		public RewardEntry[] Entries{ get{ return m_Entries; } }

		public RewardList( TimeSpan interval, int index, RewardEntry[] entries )
		{
			m_Age = TimeSpan.FromDays( interval.TotalDays * index );
			m_Entries = entries;

			for ( int i = 0; i < entries.Length; ++i )
				entries[i].List = this;
		}
	}
}
