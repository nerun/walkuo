/* ***************************************************************************
 * CraftSkillCol.cs
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

namespace Server.Engines.Craft
{
    public class CraftSkillCol : System.Collections.CollectionBase
    {
        public CraftSkillCol()
        {
        }

        public void Add( CraftSkill craftSkill )
        {
            List.Add( craftSkill );
        }

        public void Remove( int index )
        {
            if ( index > Count - 1 || index < 0 )
            {
            }
            else
            {
                List.RemoveAt( index );
            }
        }

        public CraftSkill GetAt( int index )
        {
            return ( CraftSkill ) List[index];
        }
    }
}
