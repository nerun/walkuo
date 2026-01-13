/* ***************************************************************************
 * AegisOfGrace.cs
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
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class AegisOfGrace : DragonHelm
    {
        public override int LabelNumber{ get{ return 1075047; } } // Aegis of Grace

        public override int BasePhysicalResistance{ get{ return 10; } }
        public override int BaseFireResistance{ get{ return 9; } }
        public override int BaseColdResistance{ get{ return 7; } }
        public override int BasePoisonResistance{ get{ return 7; } }
        public override int BaseEnergyResistance{ get{ return 15; } }

        public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Dragon; } }
        public override CraftResource DefaultResource{ get{ return CraftResource.Iron; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public AegisOfGrace()
        {
            SkillBonuses.SetValues( 0, SkillName.MagicResist, 10.0 );

            Attributes.DefendChance = 20;

            ArmorAttributes.SelfRepair = 2;
        }

        public override Race RequiredRace
        {
            get
            {
                return Race.Elf;
            }
        }

        public AegisOfGrace( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
