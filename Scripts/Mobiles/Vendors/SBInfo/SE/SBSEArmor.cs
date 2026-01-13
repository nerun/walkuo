/* ***************************************************************************
 * SBSEArmor.cs
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
    public class SBSEArmor: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSEArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( PlateHatsuburi ), 76, 20, 0x2775, 0 ) );
                Add( new GenericBuyInfo( typeof( HeavyPlateJingasa ), 76, 20, 0x2777, 0 ) );
                Add( new GenericBuyInfo( typeof( DecorativePlateKabuto ), 95, 20, 0x2778, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateDo ), 310, 20, 0x277D, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateHiroSode ), 222, 20, 0x2780, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateSuneate ), 224, 20, 0x2788, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateHaidate ), 235, 20, 0x278D, 0 ) );
                Add( new GenericBuyInfo( typeof( ChainHatsuburi ), 76, 20, 0x2774, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( PlateHatsuburi ), 38 );
                Add( typeof( HeavyPlateJingasa ), 38 );
                Add( typeof( DecorativePlateKabuto ), 47 );
                Add( typeof( PlateDo ), 155 );
                Add( typeof( PlateHiroSode ), 111 );
                Add( typeof( PlateSuneate ), 112 );
                Add( typeof( PlateHaidate), 117 );
                Add( typeof( ChainHatsuburi ), 38 );

            }
        }
    }
}
