/* ***************************************************************************
 * SBThief.cs
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
    public class SBThief : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBThief()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( Backpack ), 15, 20, 0x9B2, 0 ) );
                Add( new GenericBuyInfo( typeof( Pouch ), 6, 20, 0xE79, 0 ) );
                Add( new GenericBuyInfo( typeof( Torch ), 8, 20, 0xF6B, 0 ) );
                Add( new GenericBuyInfo( typeof( Lantern ), 2, 20, 0xA25, 0 ) );
                //Add( new GenericBuyInfo( typeof( OilFlask ), 8, 20, 0x####, 0 ) );
                Add( new GenericBuyInfo( typeof( Lockpick ), 12, 20, 0x14FC, 0 ) );
                Add( new GenericBuyInfo( typeof( WoodenBox ), 14, 20, 0x9AA, 0 ) );
                Add( new GenericBuyInfo( typeof( Key ), 2, 20, 0x100E, 0 ) );
                Add( new GenericBuyInfo( typeof( HairDye ), 37, 20, 0xEFF, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( Backpack ), 7 );
                Add( typeof( Pouch ), 3 );
                Add( typeof( Torch ), 3 );
                Add( typeof( Lantern ), 1 );
                //Add( typeof( OilFlask ), 4 );
                Add( typeof( Lockpick ), 6 );
                Add( typeof( WoodenBox ), 7 );
                Add( typeof( HairDye ), 19 );
            }
        }
    }
}
