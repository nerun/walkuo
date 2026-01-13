/* ***************************************************************************
 * MLQuestPersistence.cs
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
using Server;
using Server.Mobiles;

namespace Server.Engines.MLQuests
{
    public class MLQuestPersistence : Item
    {
        private static MLQuestPersistence m_Instance;

        public static void EnsureExistence()
        {
            if ( m_Instance == null )
                m_Instance = new MLQuestPersistence();
        }

        public override string DefaultName
        {
            get { return "ML quests persistence - Internal"; }
        }

        private MLQuestPersistence()
            : base( 1 )
        {
            Movable = false;
        }

        public MLQuestPersistence( Serial serial ) : base( serial )
        {
            m_Instance = this;
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 2 ); // version
            writer.Write( MLQuestSystem.Contexts.Count );

            foreach ( MLQuestContext context in MLQuestSystem.Contexts.Values )
                context.Serialize( writer );

            writer.Write( MLQuestSystem.Quests.Count );

            foreach ( MLQuest quest in MLQuestSystem.Quests.Values )
                MLQuest.Serialize( writer, quest );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
            int contexts = reader.ReadInt();

            for ( int i = 0; i < contexts; ++i )
            {
                MLQuestContext context = new MLQuestContext( reader, version );

                if ( context.Owner != null )
                    MLQuestSystem.Contexts[context.Owner] = context;
            }

            int quests = reader.ReadInt();

            for ( int i = 0; i < quests; ++i )
                MLQuest.Deserialize( reader, version );
        }
    }
}
