/* ***************************************************************************
 * QuestRestartInfo.cs
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

namespace Server.Engines.Quests
{
	public class QuestRestartInfo
	{
		private Type m_QuestType;
		private DateTime m_RestartTime;

		public Type QuestType
		{
			get{ return m_QuestType; }
			set{ m_QuestType = value; }
		}

		public DateTime RestartTime
		{
			get{ return m_RestartTime; }
			set{ m_RestartTime = value; }
		}

		public void Reset( TimeSpan restartDelay )
		{
			if ( restartDelay < TimeSpan.MaxValue )
				m_RestartTime = DateTime.UtcNow + restartDelay;
			else
				m_RestartTime = DateTime.MaxValue;
		}

		public QuestRestartInfo( Type questType, TimeSpan restartDelay )
		{
			m_QuestType = questType;
			Reset( restartDelay );
		}

		public QuestRestartInfo( Type questType, DateTime restartTime )
		{
			m_QuestType = questType;
			m_RestartTime = restartTime;
		}
	}
}
