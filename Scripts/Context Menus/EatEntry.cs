/* ***************************************************************************
 * EatEntry.cs
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
using Server.Items;

namespace Server.ContextMenus
{
    public class EatEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private Food m_Food;

        public EatEntry( Mobile from, Food food ) : base( 6135, 1 )
        {
            m_From = from;
            m_Food = food;
        }

        public override void OnClick()
        {
            if ( m_Food.Deleted || !m_Food.Movable || !m_From.CheckAlive() || !m_Food.CheckItemUse( m_From ) )
                return;

            m_Food.Eat( m_From );
        }
    }
}
