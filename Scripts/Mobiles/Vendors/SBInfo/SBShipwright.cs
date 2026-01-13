/* ***************************************************************************
 * SBShipwright.cs
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
using Server.Multis;

namespace Server.Mobiles
{
    public class SBShipwright : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBShipwright()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( "1041205", typeof( SmallBoatDeed ), 10177, 20, 0x14F2, 0 ) );
                Add( new GenericBuyInfo( "1041206", typeof( SmallDragonBoatDeed ), 10177, 20, 0x14F2, 0 ) );
                Add( new GenericBuyInfo( "1041207", typeof( MediumBoatDeed ), 11552, 20, 0x14F2, 0 ) );
                Add( new GenericBuyInfo( "1041208", typeof( MediumDragonBoatDeed ), 11552, 20, 0x14F2, 0 ) );
                Add( new GenericBuyInfo( "1041209", typeof( LargeBoatDeed ), 12927, 20, 0x14F2, 0 ) );
                Add( new GenericBuyInfo( "1041210", typeof( LargeDragonBoatDeed ), 12927, 20, 0x14F2, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                //You technically CAN sell them back, *BUT* the vendors do not carry enough money to buy with
            }
        }
    }
}
