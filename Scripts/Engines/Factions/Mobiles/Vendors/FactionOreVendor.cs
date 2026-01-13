/* ***************************************************************************
 * FactionOreVendor.cs
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
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Factions
{
    public class FactionOreVendor : BaseFactionVendor
    {
        public FactionOreVendor( Town town, Faction faction ) : base( town, faction, "the Ore Man" )
        {
            // NOTE: Skills verified
            SetSkill( SkillName.Carpentry, 85.0, 100.0 );
            SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
        }

        public override void InitSBInfo()
        {
            SBInfos.Add( new SBFactionOre() );
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem( new HalfApron() );
        }

        public FactionOreVendor( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }

    public class SBFactionOre : SBInfo
    {
        private static readonly object[] m_FixedSizeArgs = { true };

        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBFactionOre()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                for ( int i = 0; i < 5; ++i )
                    Add( new GenericBuyInfo( typeof( IronOre ), 16, 20, 0x19B8, 0, m_FixedSizeArgs ) );
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
