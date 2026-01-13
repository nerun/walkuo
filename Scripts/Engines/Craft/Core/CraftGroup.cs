/* ***************************************************************************
 * CraftGroup.cs
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
    public class CraftGroup
    {
        private CraftItemCol m_arCraftItem;

        private string m_NameString;
        private int m_NameNumber;

        public CraftGroup( TextDefinition groupName )
        {
            m_NameNumber = groupName;
            m_NameString = groupName;
            m_arCraftItem = new CraftItemCol();
        }

        public void AddCraftItem( CraftItem craftItem )
        {
            m_arCraftItem.Add( craftItem );
        }

        public CraftItemCol CraftItems
        {
            get { return m_arCraftItem; }
        }

        public string NameString
        {
            get { return m_NameString; }
        }

        public int NameNumber
        {
            get { return m_NameNumber; }
        }
    }
}
