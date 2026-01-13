/* ***************************************************************************
 * StrongholdDefintion.cs
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
    public class StrongholdDefinition
    {
        private Rectangle2D[] m_Area;
        private Point3D m_JoinStone;
        private Point3D m_FactionStone;
        private Point3D[] m_Monoliths;

        public Rectangle2D[] Area{ get{ return m_Area; } }

        public Point3D JoinStone{ get{ return m_JoinStone; } }
        public Point3D FactionStone{ get{ return m_FactionStone; } }

        public Point3D[] Monoliths{ get{ return m_Monoliths; } }

        public StrongholdDefinition( Rectangle2D[] area, Point3D joinStone, Point3D factionStone, Point3D[] monoliths )
        {
            m_Area = area;
            m_JoinStone = joinStone;
            m_FactionStone = factionStone;
            m_Monoliths = monoliths;
        }
    }
}
