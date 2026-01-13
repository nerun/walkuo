/* ***************************************************************************
 * RemovePartyTarget.cs
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

namespace Server.Engines.PartySystem
{
    public class RemovePartyTarget : Target
    {
        public RemovePartyTarget() : base( 8, false, TargetFlags.None )
        {
        }

        protected override void OnTarget( Mobile from, object o )
        {
            if ( o is Mobile )
            {
                Mobile m = (Mobile)o;
                Party p = Party.Get( from );

                if ( p == null || p.Leader != from || !p.Contains( m ) )
                    return;

                if ( from == m )
                    from.SendLocalizedMessage( 1005446 ); // You may only remove yourself from a party if you are not the leader.
                else
                    p.Remove( m );
            }
        }
    }
}
