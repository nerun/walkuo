/* ***************************************************************************
 * Animations.cs
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

namespace Server.Misc
{
    public class Animations
    {
        public static void Initialize()
        {
            EventSink.AnimateRequest += new AnimateRequestEventHandler( EventSink_AnimateRequest );
        }

        private static void EventSink_AnimateRequest( AnimateRequestEventArgs e )
        {
            Mobile from = e.Mobile;

            int action;

            switch ( e.Action )
            {
                case "bow": action = 32; break;
                case "salute": action = 33; break;
                default: return;
            }

            if ( from.Alive && !from.Mounted && from.Body.IsHuman )
                from.Animate( action, 5, 1, true, false, 0 );
        }
    }
}
