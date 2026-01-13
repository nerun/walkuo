/* ***************************************************************************
 * Teleporters.cs
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
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Items
{
    public class MLQuestTeleporter : Teleporter
    {
        private Type m_QuestType;
        private TextDefinition m_Message;

        [CommandProperty(AccessLevel.GameMaster)]
        public Type QuestType
        {
            get { return m_QuestType; }
            set { m_QuestType = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TextDefinition Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        [Constructable]
        public MLQuestTeleporter()
            : this(Point3D.Zero, null, null, null)
        {
        }

        [Constructable]
        public MLQuestTeleporter(Point3D pointDest, Map mapDest)
            : this(pointDest, mapDest, null, null)
        {
        }

        [Constructable]
        public MLQuestTeleporter(Point3D pointDest, Map mapDest, Type questType, TextDefinition message)
            : base(pointDest, mapDest)
        {
            m_QuestType = questType;
            m_Message = message;
        }

        public override bool CanTeleport(Mobile m)
        {
            if (!base.CanTeleport(m))
                return false;

            if (m_QuestType != null)
            {
                PlayerMobile pm = m as PlayerMobile;

                if (pm == null)
                    return false;

                MLQuestContext context = MLQuestSystem.GetContext(pm);

                if (context == null || (!context.IsDoingQuest(m_QuestType) && !context.HasDoneQuest(m_QuestType)))
                {
                    TextDefinition.SendMessageTo(m, m_Message);
                    return false;
                }
            }

            return true;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_QuestType != null)
                list.Add(String.Format("Required quest: {0}", m_QuestType.Name));
        }

        public MLQuestTeleporter(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((m_QuestType != null) ? m_QuestType.FullName : null);
            TextDefinition.Serialize(writer, m_Message);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            string typeName = reader.ReadString();

            if (typeName != null)
                m_QuestType = ScriptCompiler.FindTypeByFullName(typeName, false);

            m_Message = TextDefinition.Deserialize(reader);
        }
    }

    public interface ITicket
    {
        void OnTicketUsed(Mobile from);
    }

    public class TicketTeleporter : Teleporter
    {
        private Type m_TicketType;
        private TextDefinition m_Message;

        [CommandProperty(AccessLevel.GameMaster)]
        public Type TicketType
        {
            get { return m_TicketType; }
            set { m_TicketType = value; InvalidateProperties(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TextDefinition Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }

        [Constructable]
        public TicketTeleporter()
            : this(Point3D.Zero, null, null, null)
        {
        }

        [Constructable]
        public TicketTeleporter(Point3D pointDest, Map mapDest)
            : this(pointDest, mapDest, null, null)
        {
        }

        [Constructable]
        public TicketTeleporter(Point3D pointDest, Map mapDest, Type ticketType, TextDefinition message)
            : base(pointDest, mapDest)
        {
            m_TicketType = ticketType;
            m_Message = message;
        }

        public override bool CanTeleport(Mobile m)
        {
            if (!base.CanTeleport(m))
                return false;

            if (m_TicketType != null)
            {
                Item ticket = null;
                Container pack = m.Backpack;

                if (pack != null)
                    ticket = pack.FindItemByType(m_TicketType, false); // Check (top level) backpack

                if (ticket == null)
                {
                    foreach (Item item in m.Items) // Check paperdoll
                    {
                        if (m_TicketType.IsAssignableFrom(item.GetType()))
                        {
                            ticket = item;
                            break;
                        }
                    }
                }

                if (ticket == null)
                {
                    TextDefinition.SendMessageTo(m, m_Message);
                    return false;
                }

                if (ticket is ITicket)
                    ((ITicket)ticket).OnTicketUsed(m);
            }

            return true;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_TicketType != null)
                list.Add(String.Format("Required ticket: {0}", m_TicketType.Name));
        }

        public TicketTeleporter(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((m_TicketType != null) ? m_TicketType.FullName : null);
            TextDefinition.Serialize(writer, m_Message);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            string typeName = reader.ReadString();

            if (typeName != null)
                m_TicketType = ScriptCompiler.FindTypeByFullName(typeName, false);

            m_Message = TextDefinition.Deserialize(reader);
        }
    }
}

