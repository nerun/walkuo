/* ***************************************************************************
 * AIControlMobileTarget.cs
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
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Targets
{
    public class AIControlMobileTarget : Target
    {
        private List<BaseAI> m_List;
        private OrderType m_Order;

        public OrderType Order {
            get {
                return m_Order;
            }
        }

        public AIControlMobileTarget( BaseAI ai, OrderType order ) : base( -1, false, ( order == OrderType.Attack ? TargetFlags.Harmful : TargetFlags.None ) )
        {
            m_List = new List<BaseAI>();
            m_Order = order;

            AddAI( ai );
        }

        public void AddAI( BaseAI ai )
        {
            if ( !m_List.Contains( ai ) )
                m_List.Add( ai );
        }

        protected override void OnTarget( Mobile from, object o )
        {
            if ( o is Mobile ) {
                Mobile m = (Mobile)o;
                for ( int i = 0; i < m_List.Count; ++i )
                    m_List[i].EndPickTarget( from, m, m_Order );
            }
        }
    }
}
