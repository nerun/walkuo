/* ***************************************************************************
 * PartyMemberInfo.cs
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
using Server;

namespace Server.Engines.PartySystem
{
    public class PartyMemberInfo
    {
        private Mobile m_Mobile;
        private bool m_CanLoot;

        public Mobile Mobile{ get{ return m_Mobile; } }
        public bool CanLoot{ get{ return m_CanLoot; } set{ m_CanLoot = value; } }

        public PartyMemberInfo( Mobile m )
        {
            m_Mobile = m;
            m_CanLoot = !Core.ML;
        }
    }
}
