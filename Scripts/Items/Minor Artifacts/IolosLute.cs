/* ***************************************************************************
 * IolosLute.cs
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

namespace Server.Items
{
    public class IolosLute : Lute
    {
        public override int LabelNumber{ get{ return 1063479; } }

        public override int InitMinUses{ get{ return 1600; } }
        public override int InitMaxUses{ get{ return 1600; } }

        [Constructable]
        public IolosLute()
        {
            Hue = 0x47E;
            Slayer = SlayerName.Silver;
            //Slayer2 = SlayerName.DaemonDismissal;
            Slayer2 = SlayerName.Exorcism;
        }

        public IolosLute( Serial serial ) : base( serial )
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
