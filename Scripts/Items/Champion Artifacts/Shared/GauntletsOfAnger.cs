/* ***************************************************************************
 * GauntletsOfAnger.cs
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
    public class GuantletsOfAnger : PlateGloves
    {
        public override int LabelNumber{ get{ return 1094902; } } // Gauntlets of Anger [Replica]

        public override int BasePhysicalResistance{ get{ return 4; } }
        public override int BaseFireResistance{ get{ return 4; } }
        public override int BaseColdResistance{ get{ return 5; } }
        public override int BasePoisonResistance{ get{ return 6; } }
        public override int BaseEnergyResistance{ get{ return 5; } }

        public override int InitMinHits{ get{ return 150; } }
        public override int InitMaxHits{ get{ return 150; } }

        public override bool CanFortify{ get{ return false; } }

        [Constructable]
        public GuantletsOfAnger()
        {
            Hue = 0x29b;

            Attributes.BonusHits = 8;
            Attributes.RegenHits = 2;
            Attributes.DefendChance = 10;
        }

        public GuantletsOfAnger( Serial serial ) : base( serial )
        {
        }
        
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
