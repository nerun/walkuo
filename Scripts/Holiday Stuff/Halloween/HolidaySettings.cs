/* ***************************************************************************
 * HolidaySettings.cs
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
﻿using System;
using System.Collections.Generic;
using System.Text;
using Server.Items;

namespace Server.Events.Halloween
{
    class HolidaySettings
    {
        public static DateTime StartHalloween { get { return new DateTime( 2012, 10, 24 ); } } // YY MM DD
        public static DateTime FinishHalloween { get { return new DateTime( 2012, 11, 15 ); } }

        public static Item RandomGMBeggerItem { get { return ( Item )Activator.CreateInstance( m_GMBeggarTreats[ Utility.Random( m_GMBeggarTreats.Length ) ] ); } }
        public static Item RandomTreat { get { return (Item)Activator.CreateInstance ( m_Treats[ Utility.Random( m_Treats.Length ) ]) ; } }

        private static Type[] m_GMBeggarTreats =
        {
                  typeof( CreepyCake ),
                  typeof( PumpkinPizza ),
                  typeof( GrimWarning ),
                  typeof( HarvestWine ),
                  typeof( MurkyMilk ),
                  typeof( MrPlainsCookies ),
                  typeof( SkullsOnPike ),
                  typeof( ChairInAGhostCostume ),
                  typeof( ExcellentIronMaiden ),
                  typeof( HalloweenGuillotine ),
                  typeof( ColoredSmallWebs )
        };

        private static Type[] m_Treats =
        {
                  typeof( Lollipops ),
                  typeof( WrappedCandy ),
                  typeof( JellyBeans ),
                  typeof( Taffy ),
                  typeof( NougatSwirl )
        };
    }
}
