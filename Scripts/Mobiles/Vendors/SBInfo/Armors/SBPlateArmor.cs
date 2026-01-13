/* ***************************************************************************
 * SBPlateArmor.cs
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
    public class SBPlateArmor: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBPlateArmor()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( PlateGorget ), 104, 20, 0x1413, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateChest ), 243, 20, 0x1415, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateLegs ), 218, 20, 0x1411, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateArms ), 188, 20, 0x1410, 0 ) );
                Add( new GenericBuyInfo( typeof( PlateGloves ), 155, 20, 0x1414, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( PlateArms ), 94 );
                Add( typeof( PlateChest ), 121 );
                Add( typeof( PlateGloves ), 72 );
                Add( typeof( PlateGorget ), 52 );
                Add( typeof( PlateLegs ), 109 );

                Add( typeof( FemalePlateChest ), 113 );

            }
        }
    }
}
