/* ***************************************************************************
 * Compassion.cs
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
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server
{
    public class CompassionVirtue
    {
        private static TimeSpan LossDelay = TimeSpan.FromDays( 7.0 );
        private const int LossAmount = 500;

        public static void Initialize()
        {
            VirtueGump.Register( 105, new OnVirtueUsed( OnVirtueUsed ) );
        }

        public static void OnVirtueUsed( Mobile from )
        {
            from.SendLocalizedMessage( 1053001 ); // This virtue is not activated through the virtue menu.
        }

        public static void CheckAtrophy( Mobile from )
        {
            PlayerMobile pm = from as PlayerMobile;

            if ( pm == null )
                return;

            try
            {
                if ( (pm.LastCompassionLoss + LossDelay) < DateTime.UtcNow )
                {
                    VirtueHelper.Atrophy( from, VirtueName.Compassion, LossAmount );
                    //OSI has no cliloc message for losing compassion.  Weird.
                    pm.LastCompassionLoss = DateTime.UtcNow;
                }
            }
            catch
            {
            }
        }
    }
}
