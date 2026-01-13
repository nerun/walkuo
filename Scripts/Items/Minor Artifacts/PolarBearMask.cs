/* ***************************************************************************
 * PolarBearMask.cs
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
    public class PolarBearMask : BearMask
    {
        public override int LabelNumber{ get{ return 1070637; } }

        public override int BasePhysicalResistance{ get{ return 15; } }
        public override int BaseColdResistance{ get{ return 21; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public PolarBearMask()
        {
            Hue = 0x481;

            ClothingAttributes.SelfRepair = 3;

            Attributes.RegenHits = 2;
            Attributes.NightSight = 1;
        }

        public PolarBearMask( Serial serial ) : base( serial )
        {
        }
        
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 2 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( version < 2 )
            {
                Resistances.Physical = 0;
                Resistances.Cold = 0;
            }

            if ( Attributes.NightSight == 0 )
                Attributes.NightSight = 1;
        }
    }
}
