/* ***************************************************************************
 * SBMaceWeapon.cs
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
    public class SBMaceWeapon: SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBMaceWeapon()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new GenericBuyInfo( typeof( HammerPick ), 26, 20, 0x143D, 0 ) );
                Add( new GenericBuyInfo( typeof( Club ), 16, 20, 0x13B4, 0 ) );
                Add( new GenericBuyInfo( typeof( Mace ), 28, 20, 0xF5C, 0 ) );
                Add( new GenericBuyInfo( typeof( Maul ), 21, 20, 0x143B, 0 ) );
                Add( new GenericBuyInfo( typeof( WarHammer ), 25, 20, 0x1439, 0 ) );
                Add( new GenericBuyInfo( typeof( WarMace ), 31, 20, 0x1407, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add( typeof( Club ), 8 );
                Add( typeof( HammerPick ), 13 );
                Add( typeof( Mace ), 14 );
                Add( typeof( Maul ), 10 );
                Add( typeof( WarHammer ), 12 );
                Add( typeof( WarMace ), 15 );
            }
        }
    }
}
