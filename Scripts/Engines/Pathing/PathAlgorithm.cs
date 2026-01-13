/* ***************************************************************************
 * PathAlgorithm.cs
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

namespace Server.PathAlgorithms
{
    public abstract class PathAlgorithm
    {
        public abstract bool CheckCondition( Mobile m, Map map, Point3D start, Point3D goal );
        public abstract Direction[] Find( Mobile m, Map map, Point3D start, Point3D goal );

        private static Direction[] m_CalcDirections = new Direction[9]
            {
                Direction.Up,
                Direction.North,
                Direction.Right,
                Direction.West,
                Direction.North,
                Direction.East,
                Direction.Left,
                Direction.South,
                Direction.Down
            };

        public Direction GetDirection( int xSource, int ySource, int xDest, int yDest )
        {
            int x = xDest + 1 - xSource;
            int y = yDest + 1 - ySource;
            int v = (y * 3) + x;

            if ( v < 0 || v >= 9 )
                return Direction.North;

            return m_CalcDirections[v];
        }
    }
}
