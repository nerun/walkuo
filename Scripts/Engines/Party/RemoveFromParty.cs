/* ***************************************************************************
 * RemoveFromParty.cs
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
    public class RemoveFromPartyEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private Mobile m_Target;
        
        public RemoveFromPartyEntry( Mobile from, Mobile target ) : base( 0198, 12 )
        {
            m_From = from;
            m_Target = target;
        }

        public override void OnClick()
        {            
            Party p = Party.Get( m_From );

            if ( p == null || p.Leader != m_From || !p.Contains( m_Target ) )
                return;

            if ( m_From == m_Target )
                m_From.SendLocalizedMessage( 1005446 ); // You may only remove yourself from a party if you are not the leader.
            else
                p.Remove( m_Target );
        }
    }
}
