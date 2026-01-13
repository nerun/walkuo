/* ***************************************************************************
 * DupresShield.cs
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
    public class DupresShield : BaseShield, ITokunoDyable
    {
        public override int LabelNumber { get { return 1075196; } } // Dupre’s Shield

        public override int BasePhysicalResistance { get { return 1; } }
        public override int BaseFireResistance { get { return 0; } }
        public override int BaseColdResistance { get { return 0; } }
        public override int BasePoisonResistance { get { return 0; } }
        public override int BaseEnergyResistance { get { return 1; } }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }

        public override int AosStrReq { get { return 50; } }

        public override int ArmorBase { get { return 15; } }

        [Constructable]
        public DupresShield() : base( 0x2B01 )
        {
            LootType = LootType.Blessed;
            Weight = 6.0;

            Attributes.BonusHits = 5;
            Attributes.RegenHits = 1;

            SkillBonuses.SetValues( 0, SkillName.Parry, 5 );
        }

        public DupresShield( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); //version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
