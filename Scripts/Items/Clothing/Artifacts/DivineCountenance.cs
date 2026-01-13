/* ***************************************************************************
 * DivineCountenance.cs
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
    public class DivineCountenance : HornedTribalMask
    {
        public override int LabelNumber{ get{ return 1061289; } } // Divine Countenance

        public override int ArtifactRarity{ get{ return 11; } }

        public override int BasePhysicalResistance{ get{ return 8; } }
        public override int BaseFireResistance{ get{ return 6; } }
        public override int BaseColdResistance{ get{ return 9; } }
        public override int BaseEnergyResistance{ get{ return 25; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public DivineCountenance()
        {
            Hue = 0x482;

            Attributes.BonusInt = 8;
            Attributes.RegenMana = 2;
            Attributes.ReflectPhysical = 15;
            Attributes.LowerManaCost = 8;
        }

        public DivineCountenance( Serial serial ) : base( serial )
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

            switch ( version )
            {
                case 0:
                {
                    Resistances.Physical = 0;
                    Resistances.Fire = 0;
                    Resistances.Cold = 0;
                    Resistances.Energy = 0;
                    break;
                }
            }
        }
    }
}
