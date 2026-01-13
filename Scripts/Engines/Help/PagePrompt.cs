/* ***************************************************************************
 * PagePrompt.cs
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
using Server.Prompts;

namespace Server.Engines.Help
{
    public class PagePrompt : Prompt
    {
        private PageType m_Type;

        public PagePrompt( PageType type )
        {
            m_Type = type;
        }

        public override void OnCancel( Mobile from )
        {
            from.SendLocalizedMessage( 501235, "", 0x35 ); // Help request aborted.
        }

        public override void OnResponse( Mobile from, string text )
        {
            from.SendLocalizedMessage( 501234, "", 0x35 ); /* The next available Counselor/Game Master will respond as soon as possible.
                                                            * Please check your Journal for messages every few minutes.
                                                            */

            PageQueue.Enqueue( new PageEntry( from, text, m_Type ) );
        }
    }
}
