/* ***************************************************************************
 * SummonFamiliar.cs
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
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;

namespace Server.Ethics.Hero
{
    public sealed class SummonFamiliar : Power
    {
        public SummonFamiliar()
        {
            m_Definition = new PowerDefinition(
                    5,
                    "Summon Familiar",
                    "Trubechs Vingir",
                    ""
                );
        }

        public override void BeginInvoke( Player from )
        {
            if ( from.Familiar != null && from.Familiar.Deleted )
                from.Familiar = null;

            if ( from.Familiar != null )
            {
                from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy familiar." );
                return;
            }

            if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
            {
                from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
                return;
            }

            HolyFamiliar familiar = new HolyFamiliar();

            if ( Mobiles.BaseCreature.Summon( familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
            {
                from.Familiar = familiar;

                FinishInvoke( from );
            }
        }
    }
}
