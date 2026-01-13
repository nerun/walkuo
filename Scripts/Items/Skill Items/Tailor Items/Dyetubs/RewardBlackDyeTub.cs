/* ***************************************************************************
 * RewardBlackDyeTub.cs
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

namespace Server.Items
{
    public class RewardBlackDyeTub : DyeTub, Engines.VeteranRewards.IRewardItem
    {
        public override int LabelNumber{ get{ return 1006008; } } // Black Dye Tub

        private bool m_IsRewardItem;

        [CommandProperty( AccessLevel.GameMaster )]
        public bool IsRewardItem
        {
            get{ return m_IsRewardItem; }
            set{ m_IsRewardItem = value; }
        }

        [Constructable]
        public RewardBlackDyeTub()
        {
            Hue = DyedHue = 0x0001;
            Redyable = false;
            LootType = LootType.Blessed;
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( m_IsRewardItem && !Engines.VeteranRewards.RewardSystem.CheckIsUsableBy( from, this, null ) )
                return;

            base.OnDoubleClick( from );
        }

        public RewardBlackDyeTub( Serial serial ) : base( serial )
        {
        }

        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            if ( Core.ML && m_IsRewardItem )
                list.Add( 1076217 ); // 1st Year Veteran Reward
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version

            writer.Write( (bool) m_IsRewardItem );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            switch ( version )
            {
                case 1:
                {
                    m_IsRewardItem = reader.ReadBool();
                    break;
                }
            }
        }
    }
}
