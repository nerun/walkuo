/* ***************************************************************************
 * SBLeatherWorker.cs
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
    public class SBLeatherWorker: SBInfo 
    { 
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
        private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

        public SBLeatherWorker() 
        { 
        } 

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

        public class InternalBuyInfo : List<GenericBuyInfo> 
        { 
            public InternalBuyInfo() 
            { 
                Add( new GenericBuyInfo( typeof( Hides ), 4, 999, 0x1078, 0 ) ); 
                Add( new GenericBuyInfo( typeof( ThighBoots ), 56, 10, 0x1711, 0 ) ); 
            } 
        } 

        public class InternalSellInfo : GenericSellInfo 
        { 
            public InternalSellInfo() 
            { 
                Add( typeof( Hides ), 2 ); 
                Add( typeof( ThighBoots ), 28 ); 
            } 
        } 
    } 
} 
