/* ***************************************************************************
 * SBSEFood.cs
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
    public class SBSEFood: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSEFood()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( Wasabi ), 2, 20, 0x24E8, 0 ) );
                Add( new GenericBuyInfo( typeof( Wasabi ), 2, 20, 0x24E9, 0 ) );
                Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2836, 0 ) );
                Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2837, 0 ) );
                Add( new GenericBuyInfo( typeof( GreenTeaBasket ), 2, 20, 0x284B, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( Wasabi ), 1 );
                Add( typeof( BentoBox ), 3 );
                Add( typeof( GreenTeaBasket ), 1 );
            }
        }
    }
}
