/* ***************************************************************************
 * SBSECook.cs
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
    public class SBSECook: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSECook()
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
                Add( new GenericBuyInfo( typeof( SushiRolls ), 3, 20, 0x283E, 0 ) );
                Add( new GenericBuyInfo( typeof( SushiPlatter ), 3, 20, 0x2840, 0 ) );
                Add( new GenericBuyInfo( typeof( GreenTea ), 3, 20, 0x284C, 0 ) );
                Add( new GenericBuyInfo( typeof( MisoSoup ), 3, 20, 0x284D, 0 ) );
                Add( new GenericBuyInfo( typeof( WhiteMisoSoup ), 3, 20, 0x284E, 0 ) );
                Add( new GenericBuyInfo( typeof( RedMisoSoup ), 3, 20, 0x284F, 0 ) );
                Add( new GenericBuyInfo( typeof( AwaseMisoSoup ), 3, 20, 0x2850, 0 ) );
                Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2836, 0 ) );
                Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2837, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( Wasabi ), 1 );
                Add( typeof( BentoBox ), 3 );
                Add( typeof( GreenTea ), 1 );
                Add( typeof( SushiRolls ), 1 );
                Add( typeof( SushiPlatter ), 2 );
                Add( typeof( MisoSoup ), 1 );
                Add( typeof( RedMisoSoup ), 1 );
                Add( typeof( WhiteMisoSoup ), 1 );
                Add( typeof( AwaseMisoSoup ), 1 );
            }
        }
    }
}
