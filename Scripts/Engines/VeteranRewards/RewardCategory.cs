/* ***************************************************************************
 * RewardCategory.cs
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
using System.Collections;
using System.Collections.Generic;

namespace Server.Engines.VeteranRewards
{
    public class RewardCategory
    {
        private int m_Name;
        private string m_NameString;
        private List<RewardEntry> m_Entries;

        public int Name{ get{ return m_Name; } }
        public string NameString{ get{ return m_NameString; } }
        public List<RewardEntry> Entries { get { return m_Entries; } }

        public RewardCategory( int name )
        {
            m_Name = name;
            m_Entries = new List<RewardEntry>();
        }

        public RewardCategory( string name )
        {
            m_NameString = name;
            m_Entries = new List<RewardEntry>();
        }
    }
}
