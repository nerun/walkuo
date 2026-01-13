/* ***************************************************************************
 * AnimalBuy.cs
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
using Server.Items;

namespace Server.Mobiles
{
    public class AnimalBuyInfo : GenericBuyInfo
    {
        private int m_ControlSlots;

        public AnimalBuyInfo( int controlSlots, Type type, int price, int amount, int itemID, int hue ) : this( controlSlots, null, type, price, amount, itemID, hue )
        {
        }

        public AnimalBuyInfo( int controlSlots, string name, Type type, int price, int amount, int itemID, int hue ) : base( name, type, price, amount, itemID, hue )
        {
            m_ControlSlots = controlSlots;
        }

        public override int ControlSlots
        {
            get
            {
                return m_ControlSlots;
            }
        }
    }
}
