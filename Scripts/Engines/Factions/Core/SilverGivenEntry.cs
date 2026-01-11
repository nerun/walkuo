/* ***************************************************************************
 * SilverGivenEntry.cs
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

namespace Server.Factions
{
	public class SilverGivenEntry
	{
		public static readonly TimeSpan ExpirePeriod = TimeSpan.FromHours( 3.0 );

		private Mobile m_GivenTo;
		private DateTime m_TimeOfGift;

		public Mobile GivenTo{ get{ return m_GivenTo; } }
		public DateTime TimeOfGift{ get{ return m_TimeOfGift; } }

		public bool IsExpired{ get{ return ( m_TimeOfGift + ExpirePeriod ) < DateTime.UtcNow; } }

		public SilverGivenEntry( Mobile givenTo )
		{
			m_GivenTo = givenTo;
			m_TimeOfGift = DateTime.UtcNow;
		}
	}
}
