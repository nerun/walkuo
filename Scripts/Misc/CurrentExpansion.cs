/* ***************************************************************************
 * CurrentExpansion.cs
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

using Server.Accounting;
using Server.Network;

namespace Server
{
    public class CurrentExpansion
    {
        private static readonly Expansion Expansion = Expansion.TOL;

        public static void Configure()
        {
            Core.Expansion = Expansion;

            AccountGold.Enabled = Core.TOL;
            AccountGold.ConvertOnBank = true;
            AccountGold.ConvertOnTrade = false;
            VirtualCheck.UseEditGump = true;

            bool Enabled = Core.AOS;

            Mobile.InsuranceEnabled = Enabled;
            ObjectPropertyList.Enabled = Enabled;
            Mobile.VisibleDamageType = Enabled ? VisibleDamageType.Related : VisibleDamageType.None;
            Mobile.GuildClickMessage = !Enabled;
            Mobile.AsciiClickMessage = !Enabled;

            if ( Enabled )
            {
                AOS.DisableStatInfluences();

                if ( ObjectPropertyList.Enabled )
                    PacketHandlers.SingleClickProps = true; // single click for everything is overriden to check object property list

                Mobile.ActionDelay = 1000;
                Mobile.AOSStatusHandler = new AOSStatusHandler( AOS.GetStatus );
            }
        }
    }
}
