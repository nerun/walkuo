/* ***************************************************************************
 * UzeraanTurmoilHorn.cs
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
    public class UzeraanTurmoilHorn : HornOfRetreat
    {
        public override bool ValidateUse( Mobile from )
        {
            PlayerMobile pm = from as PlayerMobile;

            return ( pm != null && pm.Quest is UzeraanTurmoilQuest );
        }

        [Constructable]
        public UzeraanTurmoilHorn()
        {
            DestLoc = new Point3D( 3597, 2582, 0 );
            DestMap = Map.Trammel;
        }

        public UzeraanTurmoilHorn( Serial serial ) : base( serial )
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
