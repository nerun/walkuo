/* ***************************************************************************
 * OrcChieftainHelm.cs
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
    public class OrcChieftainHelm : OrcHelm
    {
        public override int LabelNumber{ get{ return 1094924; } } // Orc Chieftain Helm [Replica]

        public override int BasePhysicalResistance{ get{ return 23; } }
        public override int BaseFireResistance{ get{ return 1; } }
        public override int BaseColdResistance{ get{ return 23; } }
        public override int BasePoisonResistance{ get{ return 3; } }
        public override int BaseEnergyResistance{ get{ return 5; } }

        public override int InitMinHits{ get{ return 150; } }
        public override int InitMaxHits{ get{ return 150; } }

        public override bool CanFortify{ get{ return false; } }

        [Constructable]
        public OrcChieftainHelm()
        {
            Hue = 0x2a3;

            Attributes.Luck = 100;
            Attributes.RegenHits = 3;

            if( Utility.RandomBool() )
                Attributes.BonusHits = 30;
            else
                Attributes.AttackChance = 30;
        }

        public OrcChieftainHelm( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if (version < 1 && Hue == 0x3f) /* Pigmented? */
            {
                Hue = 0x2a3;
            }
        }
    }
}
