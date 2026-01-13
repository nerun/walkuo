/* ***************************************************************************
 * QuestLogDetailedGump.cs
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
using Server.Engines.MLQuests;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Engines.MLQuests.Gumps
{
    public class QuestLogDetailedGump : BaseQuestGump
    {
        private MLQuestInstance m_Instance;
        private bool m_CloseGumps;

        public QuestLogDetailedGump( MLQuestInstance instance )
            : this( instance, true )
        {
        }

        public QuestLogDetailedGump( MLQuestInstance instance, bool closeGumps )
            : base( 1046026 ) // Quest Log
        {
            m_Instance = instance;
            m_CloseGumps = closeGumps;

            PlayerMobile pm = instance.Player;
            MLQuest quest = instance.Quest;

            if ( closeGumps )
            {
                CloseOtherGumps( pm );
                pm.CloseGump( typeof( QuestLogDetailedGump ) );
            }

            SetTitle( quest.Title );
            RegisterButton( ButtonPosition.Left, ButtonGraphic.Resign, 1 );
            RegisterButton( ButtonPosition.Right, ButtonGraphic.Okay, 2 );

            SetPageCount( 3 );

            BuildPage();
            AddDescription( quest );

            if ( instance.Failed ) // only displayed on the first page
                AddHtmlLocalized( 160, 80, 250, 16, 500039, 0x3C00, false, false ); // Failed!

            BuildPage();
            AddObjectivesProgress( instance );

            BuildPage();
            AddRewardsPage( quest );
        }

        public override void OnResponse( NetState sender, RelayInfo info )
        {
            if ( m_Instance.Removed )
                return;

            switch ( info.ButtonID )
            {
                case 1: // Resign
                {
                    // TODO: Custom reward loss protection? OSI doesn't have this
                    //if ( m_Instance.ClaimReward )
                    //    pm.SendMessage( "You cannot cancel a quest with rewards pending." );
                    //else

                    sender.Mobile.SendGump( new QuestCancelConfirmGump( m_Instance, m_CloseGumps ) );

                    break;
                }
                case 2: // Okay
                {
                    sender.Mobile.SendGump( new QuestLogGump( m_Instance.Player, m_CloseGumps ) );

                    break;
                }
            }
        }
    }
}
