/* ***************************************************************************
 * VioletCourage.cs
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
    public class VioletCourage : FemalePlateChest
    {
        public override int LabelNumber{ get{ return 1063471; } }

        public override int BasePhysicalResistance{ get{ return 14; } }
        public override int BaseFireResistance{ get{ return 12; } }
        public override int BaseColdResistance{ get{ return 12; } }
        public override int BasePoisonResistance{ get{ return 8; } }
        public override int BaseEnergyResistance{ get{ return 9; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public VioletCourage()
        {
            Hue = 0x486;
            Attributes.Luck = 95;
            Attributes.DefendChance = 15;
            ArmorAttributes.LowerStatReq = 100;
            ArmorAttributes.MageArmor = 1;
        }

        public VioletCourage( Serial serial ) : base( serial )
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
