/* ***************************************************************************
 * QuestOfferGump.cs
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
    public class QuestOfferGump : BaseQuestGump
    {
        private MLQuest m_Quest;
        private IQuestGiver m_Quester;

        public QuestOfferGump( MLQuest quest, IQuestGiver quester, PlayerMobile pm )
            : base( 1049010 ) // Quest Offer
        {
            m_Quest = quest;
            m_Quester = quester;

            CloseOtherGumps( pm );
            pm.CloseGump( typeof( QuestOfferGump ) );

            SetTitle( quest.Title );
            RegisterButton( ButtonPosition.Left, ButtonGraphic.Accept, 1 );
            RegisterButton( ButtonPosition.Right, ButtonGraphic.Refuse, 2 );

            SetPageCount( 3 );

            BuildPage();
            AddDescription( quest );

            BuildPage();
            AddObjectives( quest );

            BuildPage();
            AddRewardsPage( quest );
        }

        public override void OnResponse( NetState sender, RelayInfo info )
        {
            PlayerMobile pm = sender.Mobile as PlayerMobile;

            if ( pm == null )
                return;

            switch ( info.ButtonID )
            {
                case 1: // Accept
                {
                    m_Quest.OnAccept( m_Quester, pm );
                    break;
                }
                case 2: // Refuse
                {
                    m_Quest.OnRefuse( m_Quester, pm );
                    break;
                }
            }
        }
    }
}
