/* ***************************************************************************
 * QuestCompleteObjectiveRegion.cs
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
using System.Xml;
using Server;
using Server.Regions;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class QuestCompleteObjectiveRegion : BaseRegion
    {
        private Type m_Quest;
        private Type m_Objective;

        public Type Quest{ get{ return m_Quest ; } }
        public Type Objective{ get{ return m_Objective; } }

        public QuestCompleteObjectiveRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
        {
            XmlElement questEl = xml["quest"];

            ReadType( questEl, "type", ref m_Quest );
            ReadType( questEl, "complete", ref m_Objective );
        }

        public override void OnEnter( Mobile m )
        {
            base.OnEnter( m );

            if ( m_Quest != null && m_Objective != null )
            {
                PlayerMobile player = m as PlayerMobile;

                if ( player != null && player.Quest != null && player.Quest.GetType() == m_Quest )
                {
                    QuestObjective obj = player.Quest.FindObjective( m_Objective );

                    if ( obj != null && !obj.Completed )
                        obj.Complete();
                }
            }
        }
    }
}
