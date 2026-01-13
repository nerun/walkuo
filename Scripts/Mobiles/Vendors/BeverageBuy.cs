/* ***************************************************************************
 * BeverageBuy.cs
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
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
    public class BeverageBuyInfo : GenericBuyInfo
    {
        private BeverageType m_Content;

        public override bool CanCacheDisplay{ get{ return false; } }

        public BeverageBuyInfo( Type type, BeverageType content, int price, int amount, int itemID, int hue ) : this( null, type, content, price, amount, itemID, hue )
        {
        }

        public BeverageBuyInfo( string name, Type type, BeverageType content, int price, int amount, int itemID, int hue ) : base( name, type, price, amount, itemID, hue )
        {
            m_Content = content;

            if ( type == typeof( Pitcher ) )
                Name = (1048128 + (int)content).ToString();
            else if ( type == typeof( BeverageBottle ) )
                Name = (1042959 + (int)content).ToString();
            else if ( type == typeof( Jug ) )
                Name = (1042965 + (int)content).ToString();
        }

        public override IEntity GetEntity()
        {
            return (IEntity)Activator.CreateInstance( Type, new object[]{ m_Content } );
        }
    }
}
