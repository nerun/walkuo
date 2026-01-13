/* ***************************************************************************
 * PumpkinPatch.cs
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
using Server.Items;
using Server.Events.Halloween;

namespace Server.Engines.Events
{
    public class PumpkinPatchSpawner
    {
        private static Timer m_Timer;

        private static Rectangle2D[] m_PumpkinFields =
        {
                  new Rectangle2D( 4557, 1471, 20, 10 ),
                  new Rectangle2D( 796, 2152, 36, 24 ),
                  new Rectangle2D( 816, 2251, 16, 8 ),
                  new Rectangle2D( 816, 2261, 16, 8 ),
                  new Rectangle2D( 816, 2271, 16, 8 ),
                  new Rectangle2D( 816, 2281, 16, 8 ),
                  new Rectangle2D( 835, 2344, 16, 16 ),
                  new Rectangle2D( 816, 2344, 16, 24 )
        };

        public static void Initialize()
        {
            DateTime now = DateTime.UtcNow;

            if( DateTime.UtcNow >= HolidaySettings.StartHalloween && DateTime.UtcNow <= HolidaySettings.FinishHalloween )
            {
                m_Timer = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromMinutes( .50 ), 0, new TimerCallback( PumpkinPatchSpawnerCallback ));
            }
        }

        protected static void PumpkinPatchSpawnerCallback()
        {
            AddPumpkin( Map.Felucca );
            AddPumpkin( Map.Trammel );
        }

        private static void AddPumpkin( Map map )
        {
            for( int i = 0; i < m_PumpkinFields.Length; i++ )
            {
                Rectangle2D rect = m_PumpkinFields[ i ];

                int spawncount = ( ( rect.Height * rect.Width ) / 20 );
                int pumpkins = 0;

                foreach( Item item in map.GetItemsInBounds( rect ) )
                {
                    if( item is HalloweenPumpkin )
                    {
                        pumpkins++;
                    }
                }

                if( spawncount > pumpkins )
                {
                    Item item = new HalloweenPumpkin();

                    item.MoveToWorld( RandomPointIn( rect, map ), map );
                }
            }
        }

        private static Point3D RandomPointIn( Rectangle2D rect, Map map )
        {
            int x = Utility.Random( rect.X, rect.Width );
            int y = Utility.Random( rect.Y, rect.Height );
            int z = map.GetAverageZ( x, y );

            return new Point3D( x, y, z );
        }
    }
}
