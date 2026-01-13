/* ***************************************************************************
 * LeatherShorts.cs
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
using Server.Items;

namespace Server.Items
{
    [FlipableAttribute( 0x1c00, 0x1c01 )]
    public class LeatherShorts : BaseArmor
    {
        public override int BasePhysicalResistance{ get{ return 2; } }
        public override int BaseFireResistance{ get{ return 4; } }
        public override int BaseColdResistance{ get{ return 3; } }
        public override int BasePoisonResistance{ get{ return 3; } }
        public override int BaseEnergyResistance{ get{ return 3; } }

        public override int InitMinHits{ get{ return 30; } }
        public override int InitMaxHits{ get{ return 40; } }

        public override int AosStrReq{ get{ return 20; } }
        public override int OldStrReq{ get{ return 10; } }

        public override int ArmorBase{ get{ return 13; } }

        public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

        public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

        public override bool AllowMaleWearer{ get{ return false; } }

        [Constructable]
        public LeatherShorts() : base( 0x1C00 )
        {
            Weight = 3.0;
        }

        public LeatherShorts( Serial serial ) : base( serial )
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
