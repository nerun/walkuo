/* ***************************************************************************
 * UzeraanTurmoilTeleporter.cs
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
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.Haven
{
    public class UzeraanTurmoilTeleporter : DynamicTeleporter
    {
        [Constructable]
        public UzeraanTurmoilTeleporter()
        {
        }

        public override bool GetDestination( PlayerMobile player, ref Point3D loc, ref Map map )
        {
            QuestSystem qs = player.Quest;

            if ( qs is UzeraanTurmoilQuest )
            {
                if ( qs.IsObjectiveInProgress( typeof( FindSchmendrickObjective ) )
                    || qs.IsObjectiveInProgress( typeof( FindApprenticeObjective ) )
                    || UzeraanTurmoilQuest.HasLostScrollOfPower( player ) )
                {
                    loc = new Point3D( 5222, 1858, 0 );
                    map = Map.Trammel;
                    return true;
                }
                else if ( qs.IsObjectiveInProgress( typeof( FindDryadObjective ) )
                    || UzeraanTurmoilQuest.HasLostFertileDirt( player ) )
                {
                    loc = new Point3D( 3557, 2690, 2 );
                    map = Map.Trammel;
                    return true;
                }
                else if ( player.Profession != 5 // paladin
                    && ( qs.IsObjectiveInProgress( typeof( GetDaemonBoneObjective ) )
                    || UzeraanTurmoilQuest.HasLostDaemonBone( player ) ) )
                {
                    loc = new Point3D( 3422, 2653, 48 );
                    map = Map.Trammel;
                    return true;
                }
                else if ( qs.IsObjectiveInProgress( typeof( CashBankCheckObjective ) ) )
                {
                    loc = new Point3D( 3624, 2610, 0 );
                    map = Map.Trammel;
                    return true;
                }
            }

            return false;
        }

        public UzeraanTurmoilTeleporter( Serial serial ) : base( serial )
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
