/* ***************************************************************************
 * QuestCallbackEntry.cs
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
using Server.ContextMenus;

namespace Server.Engines.Quests
{
	public class QuestCallbackEntry : ContextMenuEntry
	{
		private QuestCallback m_Callback;

		public QuestCallbackEntry( int number, QuestCallback callback ) : this( number, -1, callback )
		{
		}

		public QuestCallbackEntry( int number, int range, QuestCallback callback ) : base( number, range )
		{
			m_Callback = callback;
		}

		public override void OnClick()
		{
			if ( m_Callback != null )
				m_Callback();
		}
	}
}
