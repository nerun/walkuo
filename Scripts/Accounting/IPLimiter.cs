/* ***************************************************************************
 * IPLimiter.cs
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
using System.Net;
using System.Net.Sockets;
using Server;
using Server.Network;

namespace Server.Misc
{
    public class IPLimiter
    {
        public static bool Enabled = true;
        public static bool SocketBlock = true; // true to block at connection, false to block at login request

        public static int MaxAddresses = 10;
        
        public static IPAddress[] Exemptions = new IPAddress[]    //For hosting services where there are cases where IPs can be proxied
        {
            //IPAddress.Parse( "127.0.0.1" ),
        };

        public static bool IsExempt( IPAddress ip )
        {
            for ( int i = 0; i < Exemptions.Length; i++ )
            {
                if ( ip.Equals( Exemptions[i] ) )
                    return true;
            }

            return false;
        }

        public static bool Verify( IPAddress ourAddress )
        {
            if ( !Enabled || IsExempt( ourAddress ) )
                return true;

            List<NetState> netStates = NetState.Instances;

            int count = 0;

            for ( int i = 0; i < netStates.Count; ++i )
            {
                NetState compState = netStates[i];

                if ( ourAddress.Equals( compState.Address ) )
                {
                    ++count;

                    if ( count >= MaxAddresses )
                        return false;
                }
            }

            return true;
        }
    }
}
