/* ***************************************************************************
 * Party.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C) 2002  The RunUO Software Team
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

namespace Server
{
    public abstract class PartyCommands
    {
        private static PartyCommands m_Handler;

        public static PartyCommands Handler{ get{ return m_Handler; } set{ m_Handler = value; } }

        public abstract void OnAdd( Mobile from );
        public abstract void OnRemove( Mobile from, Mobile target );
        public abstract void OnPrivateMessage( Mobile from, Mobile target, string text );
        public abstract void OnPublicMessage( Mobile from, string text );
        public abstract void OnSetCanLoot( Mobile from, bool canLoot );
        public abstract void OnAccept( Mobile from, Mobile leader );
        public abstract void OnDecline( Mobile from, Mobile leader );
    }
}
