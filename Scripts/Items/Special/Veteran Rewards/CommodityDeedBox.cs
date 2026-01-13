/* ***************************************************************************
 * CommodityDeedBox.cs
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
using Server;
using Server.Engines.VeteranRewards;

namespace Server.Items
{    
    [Furniture]
    public class CommodityDeedBox : BaseContainer, IRewardItem
    {
        public override int LabelNumber{ get { return 1080523; } } // Commodity Deed Box
        public override int DefaultGumpID{ get{ return 0x43; } }

        private bool m_IsRewardItem;

        [CommandProperty( AccessLevel.GameMaster )]
        public bool IsRewardItem
        {
            get{ return m_IsRewardItem; }
            set{ m_IsRewardItem = value; InvalidateProperties(); }
        }

        [Constructable]
        public CommodityDeedBox() : base( 0x9AA )
        {
            Hue = 0x47;
            Weight = 4.0;
        }

        public CommodityDeedBox( Serial serial ) : base( serial )
        {
        }
        
        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );
            
            if ( m_IsRewardItem )
                list.Add( 1076217 ); // 1st Year Veteran Reward        
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version

            writer.Write( (bool) m_IsRewardItem );
        }
            
        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            m_IsRewardItem = reader.ReadBool();
        }

        public static CommodityDeedBox Find( Item deed )
        {
            Item parent = deed;

            while ( parent != null && !( parent is CommodityDeedBox ) )
                parent = parent.Parent as Item;

            return parent as CommodityDeedBox;
        }
    }    
}
