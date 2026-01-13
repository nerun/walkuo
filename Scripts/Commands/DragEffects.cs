/* ***************************************************************************
 * DragEffects.cs
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

namespace Server.Commands
{
    public static class DragEffects
    {
        public static void Initialize()
        {
            CommandSystem.Register( "DragEffects", AccessLevel.Developer, new CommandEventHandler( DragEffects_OnCommand ) );
        }

        [Usage( "DragEffects [enable=false]" )]
        [Description( "Enables or disables the item drag and drop effects." )]
        public static void DragEffects_OnCommand( CommandEventArgs e )
        {
            if ( e.Length == 0 )
            {
                e.Mobile.SendMessage( "Drag effects are currently {0}.", Mobile.DragEffects ? "enabled" : "disabled" );
            }
            else
            {
                Mobile.DragEffects = e.GetBoolean( 0 );

                e.Mobile.SendMessage( "Drag effects have been {0}.", Mobile.DragEffects ? "enabled" : "disabled" );
            }
        }
    }
}
