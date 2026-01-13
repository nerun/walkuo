/* ***************************************************************************
 * FactionItemDefinition.cs
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
using Server.Items;
using Server.Mobiles;

namespace Server.Factions
{
    public class FactionItemDefinition
    {
        private int m_SilverCost;
        private Type m_VendorType;

        public int SilverCost{ get{ return m_SilverCost; } }
        public Type VendorType{ get{ return m_VendorType; } }

        public FactionItemDefinition( int silverCost, Type vendorType )
        {
            m_SilverCost = silverCost;
            m_VendorType = vendorType;
        }

        private static FactionItemDefinition m_MetalArmor    = new FactionItemDefinition( 1000, typeof( Blacksmith ) );
        private static FactionItemDefinition m_Weapon        = new FactionItemDefinition( 1000, typeof( Blacksmith ) );
        private static FactionItemDefinition m_RangedWeapon    = new FactionItemDefinition( 1000, typeof( Bowyer ) );
        private static FactionItemDefinition m_LeatherArmor    = new FactionItemDefinition(  750, typeof( Tailor ) );
        private static FactionItemDefinition m_Clothing        = new FactionItemDefinition(  200, typeof( Tailor ) );
        private static FactionItemDefinition m_Scroll        = new FactionItemDefinition(  500, typeof( Mage ) );

        public static FactionItemDefinition Identify( Item item )
        {
            if ( item is BaseArmor )
            {
                if ( CraftResources.GetType( ((BaseArmor)item).Resource ) == CraftResourceType.Leather )
                    return m_LeatherArmor;

                return m_MetalArmor;
            }

            if ( item is BaseRanged )
                return m_RangedWeapon;
            else if ( item is BaseWeapon )
                return m_Weapon;
            else if ( item is BaseClothing )
                return m_Clothing;
            else if ( item is SpellScroll )
                return m_Scroll;

            return null;
        }
    }
}
