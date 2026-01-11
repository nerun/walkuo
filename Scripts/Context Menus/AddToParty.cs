/* ***************************************************************************
 * AddToParty.cs
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
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.ContextMenus
{
	public class AddToPartyEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private Mobile m_Target;
		
		public AddToPartyEntry( Mobile from, Mobile target ) : base( 0197, 12 )
		{
			m_From = from;
			m_Target = target;
		}

		public override void OnClick()
		{			
			Party p = Party.Get( m_From );
			Party mp = Party.Get( m_Target );

			if ( m_From == m_Target )
				m_From.SendLocalizedMessage( 1005439 ); // You cannot add yourself to a party.
			else if ( p != null && p.Leader != m_From )
				m_From.SendLocalizedMessage( 1005453 ); // You may only add members to the party if you are the leader.
			else if ( p != null && (p.Members.Count + p.Candidates.Count) >= Party.Capacity )
				m_From.SendLocalizedMessage( 1008095 ); // You may only have 10 in your party (this includes candidates).
			else if ( !m_Target.Player )
				m_From.SendLocalizedMessage( 1005444 ); // The creature ignores your offer.
			else if ( mp != null && mp == p )
				m_From.SendLocalizedMessage( 1005440 ); // This person is already in your party!
			else if ( mp != null )
				m_From.SendLocalizedMessage( 1005441 ); // This person is already in a party!
			else
				Party.Invite( m_From, m_Target );
		}
	}
}
