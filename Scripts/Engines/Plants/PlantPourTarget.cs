/* ***************************************************************************
 * PlantPourTarget.cs
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
using Server.Targeting;

namespace Server.Engines.Plants
{
    public class PlantPourTarget : Target
    {
        private PlantItem m_Plant;

        public PlantPourTarget( PlantItem plant ) : base( 3, true, TargetFlags.None )
        {
            m_Plant = plant;
        }

        protected override void OnTarget( Mobile from, object targeted )
        {
            if ( !m_Plant.Deleted && from.InRange( m_Plant.GetWorldLocation(), 3 ) && targeted is Item )
            {
                m_Plant.Pour( from, (Item)targeted );
            }
        }

        protected override void OnTargetFinish( Mobile from )
        {
            if ( !m_Plant.Deleted && m_Plant.PlantStatus < PlantStatus.DecorativePlant && from.InRange( m_Plant.GetWorldLocation(), 3 ) && m_Plant.IsUsableBy( from ) )
            {
                if ( from.HasGump( typeof( MainPlantGump ) ) )
                    from.CloseGump( typeof( MainPlantGump ) );

                from.SendGump( new MainPlantGump( m_Plant ) );
            }
        }
    }
}
