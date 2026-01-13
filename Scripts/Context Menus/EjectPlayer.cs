/* ***************************************************************************
 * EjectPlayer.cs
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
using Server.Multis;

namespace Server.ContextMenus
{
    public class EjectPlayerEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private Mobile m_Target;
        private BaseHouse m_TargetHouse;
        
        public EjectPlayerEntry( Mobile from, Mobile target ) : base( 6206, 12 )
        {
            m_From = from;
            m_Target = target;
            m_TargetHouse = BaseHouse.FindHouseAt( m_Target );
        }

        public override void OnClick()
        {            
            if ( !m_From.Alive || m_TargetHouse.Deleted || !m_TargetHouse.IsFriend( m_From ) )
                return;

            if ( m_Target is Mobile )
            {
                m_TargetHouse.Kick( m_From, (Mobile)m_Target );
            }
        }
    }
}
