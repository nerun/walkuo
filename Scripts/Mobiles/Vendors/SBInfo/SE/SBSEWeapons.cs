/* ***************************************************************************
 * SBSEWeapons.cs
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
    public class SBSEWeapons: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBSEWeapons()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( NoDachi ), 82, 20, 0x27A2, 0 ) );
                Add( new GenericBuyInfo( typeof( Tessen ), 83, 20, 0x27A3, 0 ) );
                Add( new GenericBuyInfo( typeof( Wakizashi ), 38, 20, 0x27A4, 0 ) );
                Add( new GenericBuyInfo( typeof( Tetsubo ), 43, 20, 0x27A6, 0 ) );
                Add( new GenericBuyInfo( typeof( Lajatang ), 108, 20, 0x27A7, 0 ) );
                Add( new GenericBuyInfo( typeof( Daisho ), 66, 20, 0x27A9, 0 ) );
                Add( new GenericBuyInfo( typeof( Tekagi ), 55, 20, 0x27AB, 0 ) );
                Add( new GenericBuyInfo( typeof( Shuriken ), 18, 20, 0x27AC, 0 ) );
                Add( new GenericBuyInfo( typeof( Kama ), 61, 20, 0x27AD, 0 ) );
                Add( new GenericBuyInfo( typeof( Sai ), 56, 20, 0x27AF, 0 ) );        

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( NoDachi ), 41 );
                Add( typeof( Tessen ), 41 );
                Add( typeof( Wakizashi ), 19 );
                Add( typeof( Tetsubo ), 21 );
                Add( typeof( Lajatang ), 54 );
                Add( typeof( Daisho ), 33 );
                Add( typeof( Tekagi ), 22 );
                Add( typeof( Shuriken), 9 );
                Add( typeof( Kama ), 30 );
                Add( typeof( Sai ), 28 );
            }
        }
    }
}
