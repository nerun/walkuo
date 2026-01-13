/* ***************************************************************************
 * BlueNinjaQuestTeleporter.cs
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
using Server.Mobiles;

namespace Server.Engines.Quests.Ninja
{
    public class BlueNinjaQuestTeleporter : DynamicTeleporter
    {
        public override int LabelNumber{ get{ return 1026157; } } // teleporter

        [Constructable]
        public BlueNinjaQuestTeleporter() : base( 0x51C, 0x2 )
        {
        }

        public override int NotWorkingMessage{ get{ return 1063198; } } // You stand on the strange floor tile but nothing happens.

        public override bool GetDestination( PlayerMobile player, ref Point3D loc, ref Map map )
        {
            QuestSystem qs = player.Quest;

            if ( qs is EminosUndertakingQuest && qs.FindObjective( typeof( GainInnInformationObjective ) ) != null )
            {
                loc = new Point3D( 411, 1116, 0 );
                map = Map.Malas;

                return true;
            }

            return false;
        }

        public BlueNinjaQuestTeleporter( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
