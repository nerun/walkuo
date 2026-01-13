/* ***************************************************************************
 * Power.cs
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

namespace Server.Ethics
{
    public abstract class Power
    {
        protected PowerDefinition m_Definition;

        public PowerDefinition Definition { get { return m_Definition; } }

        public virtual bool CheckInvoke( Player from )
        {
            if ( !from.Mobile.CheckAlive() )
                return false;

            if ( from.Power < m_Definition.Power )
            {
                from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You lack the power to invoke this ability." );
                return false;
            }

            return true;
        }

        public abstract void BeginInvoke( Player from );

        public virtual void FinishInvoke( Player from )
        {
            from.Power -= m_Definition.Power;
        }
    }
}
