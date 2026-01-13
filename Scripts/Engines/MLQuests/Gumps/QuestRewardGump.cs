/* ***************************************************************************
 * QuestRewardGump.cs
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
    public class QuestRewardGump : BaseQuestGump
    {
        private MLQuestInstance m_Instance;

        public QuestRewardGump( MLQuestInstance instance )
            : base( 1072201 ) // Reward
        {
            m_Instance = instance;

            MLQuest quest = instance.Quest;
            PlayerMobile pm = instance.Player;

            CloseOtherGumps( pm );

            SetTitle( quest.Title );
            RegisterButton( ButtonPosition.Left, ButtonGraphic.Accept, 1 );

            SetPageCount( 1 );

            BuildPage();
            AddRewards( quest );
        }

        public override void OnResponse( NetState sender, RelayInfo info )
        {
            if ( info.ButtonID == 1 )
                m_Instance.ClaimRewards();
        }
    }
}
