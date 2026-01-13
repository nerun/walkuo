/* ***************************************************************************
 * SBAnimalTrainer.cs
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
    public class SBAnimalTrainer : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBAnimalTrainer()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add( new AnimalBuyInfo( 1, typeof( Cat ), 132, 10, 201, 0 ) );
                Add( new AnimalBuyInfo( 1, typeof( Dog ), 170, 10, 217, 0 ) );
                Add( new AnimalBuyInfo( 1, typeof( Horse ), 550, 10, 204, 0 ) );
                Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 631, 10, 291, 0 ) );
                Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 565, 10, 292, 0 ) );
                Add( new AnimalBuyInfo( 1, typeof( Rabbit ), 106, 10, 205, 0 ) );

                if( !Core.AOS )
                {
                    Add( new AnimalBuyInfo( 1, typeof( Eagle ), 402, 10, 5, 0 ) );
                    Add( new AnimalBuyInfo( 1, typeof( BrownBear ), 855, 10, 167, 0 ) );
                    Add( new AnimalBuyInfo( 1, typeof( GrizzlyBear ), 1767, 10, 212, 0 ) );
                    Add( new AnimalBuyInfo( 1, typeof( Panther ), 1271, 10, 214, 0 ) );
                    Add( new AnimalBuyInfo( 1, typeof( TimberWolf ), 768, 10, 225, 0 ) );
                    Add( new AnimalBuyInfo( 1, typeof( Rat ), 107, 10, 238, 0 ) );
                }

            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
            }
        }
    }
}
