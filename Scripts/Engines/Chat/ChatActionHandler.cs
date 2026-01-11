/* ***************************************************************************
 * ChatActionHandler.cs
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

namespace Server.Engines.Chat
{
	public delegate void OnChatAction( ChatUser from, Channel channel, string param );

	public class ChatActionHandler
	{
		private bool m_RequireModerator;
		private bool m_RequireConference;
		private OnChatAction m_Callback;

		public bool RequireModerator{ get{ return m_RequireModerator; } }
		public bool RequireConference{ get{ return m_RequireConference; } }
		public OnChatAction Callback{ get{ return m_Callback; } }

		public ChatActionHandler( bool requireModerator, bool requireConference, OnChatAction callback )
		{
			m_RequireModerator = requireModerator;
			m_RequireConference = requireConference;
			m_Callback = callback;
		}
	}
}
