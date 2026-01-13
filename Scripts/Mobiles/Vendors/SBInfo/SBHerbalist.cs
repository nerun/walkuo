/* ***************************************************************************
 * SBHerbalist.cs
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
    public class SBHerbalist : SBInfo 
    { 
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
        private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

        public SBHerbalist() 
        { 
        } 

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

        public class InternalBuyInfo : List<GenericBuyInfo> 
        { 
            public InternalBuyInfo() 
            { 
                Add( new GenericBuyInfo( typeof( Ginseng ), 3, 20, 0xF85, 0 ) ); 
                Add( new GenericBuyInfo( typeof( Garlic ), 3, 20, 0xF84, 0 ) ); 
                Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 20, 0xF86, 0 ) ); 
                Add( new GenericBuyInfo( typeof( Nightshade ), 3, 20, 0xF88, 0 ) ); 
                Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 20, 0xF7B, 0 ) ); 
                Add( new GenericBuyInfo( typeof( MortarPestle ), 8, 20, 0xE9B, 0 ) );
                Add( new GenericBuyInfo( typeof( Bottle ), 5, 20, 0xF0E, 0 ) );
            } 
        } 

        public class InternalSellInfo : GenericSellInfo 
        { 
            public InternalSellInfo() 
            { 
                Add( typeof( Bloodmoss ), 3 ); 
                Add( typeof( MandrakeRoot ), 2 ); 
                Add( typeof( Garlic ), 2 ); 
                Add( typeof( Ginseng ), 2 ); 
                Add( typeof( Nightshade ), 2 ); 
                Add( typeof( Bottle ), 3 ); 
                Add( typeof( MortarPestle ), 4 ); 
            } 
        } 
    } 
}
