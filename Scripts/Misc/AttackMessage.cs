/* ***************************************************************************
 * AttackMessage.cs
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
using System.Collections.Generic;
using Server;
using Server.Network;

namespace Server.Misc
{
    public class AttackMessage
    {
        private const string AggressorFormat = "You are attacking {0}!";
        private const string AggressedFormat = "{0} is attacking you!";
        private const int Hue = 0x22;

        private static TimeSpan Delay = TimeSpan.FromMinutes( 1.0 );

        public static void Initialize()
        {
            EventSink.AggressiveAction += new AggressiveActionEventHandler( EventSink_AggressiveAction );
        }

        public static void EventSink_AggressiveAction( AggressiveActionEventArgs e )
        {
            Mobile aggressor = e.Aggressor;
            Mobile aggressed = e.Aggressed;

            if ( !aggressor.Player || !aggressed.Player )
                return;

            if ( !CheckAggressions( aggressor, aggressed ) )
            {
                aggressor.LocalOverheadMessage( MessageType.Regular, Hue, true, String.Format( AggressorFormat, aggressed.Name ) );
                aggressed.LocalOverheadMessage( MessageType.Regular, Hue, true, String.Format( AggressedFormat, aggressor.Name ) );
            }
        }

        public static bool CheckAggressions( Mobile m1, Mobile m2 )
        {
            List<AggressorInfo> list = m1.Aggressors;

            for ( int i = 0; i < list.Count; ++i )
            {
                AggressorInfo info = list[i];

                if ( info.Attacker == m2 && DateTime.UtcNow < (info.LastCombatTime + Delay) )
                    return true;
            }

            list = m2.Aggressors;

            for ( int i = 0; i < list.Count; ++i )
            {
                AggressorInfo info = list[i];

                if ( info.Attacker == m1 && DateTime.UtcNow < (info.LastCombatTime + Delay) )
                    return true;
            }

            return false;
        }
    }
}
