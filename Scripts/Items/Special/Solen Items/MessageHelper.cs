/* ***************************************************************************
 * MessageHelper.cs
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
using Server.Network;

namespace Server
{
    public class MessageHelper
    {
        public static void SendLocalizedMessageTo( Item from, Mobile to, int number, int hue )
        {
            SendLocalizedMessageTo( from, to, number, "", hue );
        }

        public static void SendLocalizedMessageTo( Item from, Mobile to, int number, string args, int hue )
        {
            to.Send( new MessageLocalized( from.Serial, from.ItemID, MessageType.Regular, hue, 3, number, "", args ) );
        }

        public static void SendMessageTo( Item from, Mobile to, string text, int hue )
        {
            to.Send( new UnicodeMessage( from.Serial, from.ItemID, MessageType.Regular, hue, 3, "ENU", "", text ) );
        }
    }
}
