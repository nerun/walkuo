/* ***************************************************************************
 * QuestReportBackGump.cs
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
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Engines.MLQuests.Gumps
{
	public class QuestReportBackGump : BaseQuestGump
	{
		private MLQuestInstance m_Instance;

		public QuestReportBackGump( MLQuestInstance instance )
			: base( 3006156 ) // Quest Conversation
		{
			m_Instance = instance;

			MLQuest quest = instance.Quest;
			PlayerMobile pm = instance.Player;

			// TODO: Check close sequence
			CloseOtherGumps( pm );

			SetTitle( quest.Title );
			RegisterButton( ButtonPosition.Left, ButtonGraphic.Continue, 4 );
			RegisterButton( ButtonPosition.Right, ButtonGraphic.Close, 3 );

			SetPageCount( 1 );

			BuildPage();
			AddConversation( quest.CompletionMessage );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 4 )
				m_Instance.ContinueReportBack( true );
		}
	}
}
