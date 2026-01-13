/* ***************************************************************************
 * SBLeatherArmor.cs
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
using Server.Items;

namespace Server.Mobiles
{
    public class SBLeatherArmor: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBLeatherArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( LeatherArms ), 80, 20, 0x13CD, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherChest ), 101, 20, 0x13CC, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherGloves ), 60, 20, 0x13C6, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherGorget ), 74, 20, 0x13C7, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherLegs ), 80, 20, 0x13cb, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherCap ), 10, 20, 0x1DB9, 0 ) );
                Add( new GenericBuyInfo( typeof( FemaleLeatherChest ), 116, 20, 0x1C06, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherBustierArms ), 97, 20, 0x1C0A, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherShorts ), 86, 20, 0x1C00, 0 ) );
                Add( new GenericBuyInfo( typeof( LeatherSkirt ), 87, 20, 0x1C08, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( LeatherArms ), 40 );
                Add( typeof( LeatherChest ), 52 );
                Add( typeof( LeatherGloves ), 30 );
                Add( typeof( LeatherGorget ), 37 );
                Add( typeof( LeatherLegs ), 40 );
                Add( typeof( LeatherCap ), 5 );

                Add( typeof( FemaleLeatherChest ), 18 );
                Add( typeof( FemaleStuddedChest ), 25 );
                Add( typeof( LeatherShorts ), 14 );
                Add( typeof( LeatherSkirt ), 11 );
                Add( typeof( LeatherBustierArms ), 11 );
                Add( typeof( StuddedBustierArms ), 27 );
            }
        }
    }
}
