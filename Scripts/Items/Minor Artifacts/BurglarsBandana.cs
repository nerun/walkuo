/* ***************************************************************************
 * BurglarsBandana.cs
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
    public class BurglarsBandana : Bandana
    {
        public override int LabelNumber{ get{ return 1063473; } }

        public override int BasePhysicalResistance{ get{ return 10; } }
        public override int BaseFireResistance{ get{ return 5; } }
        public override int BaseColdResistance{ get{ return 7; } }
        public override int BasePoisonResistance{ get{ return 10; } }
        public override int BaseEnergyResistance{ get{ return 10; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public BurglarsBandana()
        {
            Hue = Utility.RandomBool() ? 0x58C : 0x10;

            SkillBonuses.SetValues( 0, SkillName.Stealing, 10.0 );
            SkillBonuses.SetValues( 1, SkillName.Stealth, 10.0 );
            SkillBonuses.SetValues( 2, SkillName.Snooping, 10.0 );

            Attributes.BonusDex = 5;
        }

        public BurglarsBandana( Serial serial ) : base( serial )
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
                Resistances.Fire = 0;
                Resistances.Cold = 0;
                Resistances.Poison = 0;
                Resistances.Energy = 0;
            }
        }
    }
}
