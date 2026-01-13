/* ***************************************************************************
 * DawnsMusicInfo.cs
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
﻿using System;

namespace Server.Items
{
    public enum DawnsMusicRarity
    {
        Common,
        Uncommon,
        Rare,
    }

    public class DawnsMusicInfo
    {
        private int m_Name;

        public int Name
        {
            get { return m_Name; }
        }

        private DawnsMusicRarity m_Rarity;

        public DawnsMusicRarity Rarity
        {
            get { return m_Rarity; }
        }

        public DawnsMusicInfo( int name, DawnsMusicRarity rarity )
        {
            m_Name = name;
            m_Rarity = rarity;
        }
    }
}
