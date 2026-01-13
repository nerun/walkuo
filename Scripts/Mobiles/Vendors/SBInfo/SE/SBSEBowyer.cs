/* ***************************************************************************
 * SBSEBowyer.cs
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
    public class SBSEBowyer: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSEBowyer()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( Yumi ), 53, 20, 0x27A5, 0 ) );
                Add( new GenericBuyInfo( typeof( Fukiya ), 20, 20, 0x27AA, 0 ) );
                Add( new GenericBuyInfo( typeof( Nunchaku ), 35, 20, 0x27AE, 0 ) );
                Add( new GenericBuyInfo( typeof( FukiyaDarts ), 3, 20, 0x2806, 0 ) );
                Add( new GenericBuyInfo( typeof( Bokuto ), 21, 20, 0x27A8, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( Yumi ), 26 );
                Add( typeof( Fukiya ), 10 );
                Add( typeof( Nunchaku ), 17 );
                Add( typeof( FukiyaDarts ), 1 );
                Add( typeof( Bokuto ), 10 );
            }
        }
    }
}
