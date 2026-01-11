/* ***************************************************************************
 * DeclineTimer.cs
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
using System.Collections;
using Server;

namespace Server.Engines.PartySystem
{
	public class DeclineTimer : Timer
	{
		private Mobile m_Mobile, m_Leader;

		private static Hashtable m_Table = new Hashtable();

		public static void Start( Mobile m, Mobile leader )
		{
			DeclineTimer t = (DeclineTimer)m_Table[m];

			if ( t != null )
				t.Stop();

			m_Table[m] = t = new DeclineTimer( m, leader );
			t.Start();
		}

		private DeclineTimer( Mobile m, Mobile leader ) : base( TimeSpan.FromSeconds( 30.0 ) )
		{
			m_Mobile = m;
			m_Leader = leader;
		}

		protected override void OnTick()
		{
			m_Table.Remove( m_Mobile );

			if ( m_Mobile.Party == m_Leader && PartyCommands.Handler != null )
				PartyCommands.Handler.OnDecline( m_Mobile, m_Leader );
		}
	}
}
