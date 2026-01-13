/* ***************************************************************************
 * WizardsGlasses.cs
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
    public class WizardsGlasses : ElvenGlasses
    {
        public override int LabelNumber{ get{ return 1073374; } } //Wizard's Crystal Reading Glasses

        public override int BasePhysicalResistance{ get{ return 5; } }
        public override int BaseFireResistance{ get{ return 5; } }
        public override int BaseColdResistance{ get{ return 5; } }
        public override int BasePoisonResistance{ get{ return 5; } }
        public override int BaseEnergyResistance{ get{ return 5; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public WizardsGlasses()
        {
            Attributes.BonusMana = 10;
            Attributes.RegenMana = 3;
            Attributes.SpellDamage = 15;

            Hue = 0x2B0;
        }
        public WizardsGlasses( Serial serial ) : base( serial )
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

            if ( version == 0 && Hue == 0 )
                Hue = 0x2B0;
        }
    }
}
