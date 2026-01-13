/* ***************************************************************************
 * MelisandesCorrodedHatchet.cs
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
    public class MelisandesCorrodedHatchet : Hatchet
    {
        public override int LabelNumber{ get{ return 1072115; } } // Melisande's Corroded Hatchet

        [Constructable]
        public MelisandesCorrodedHatchet()
        {
            Hue = 0x494;

            SkillBonuses.SetValues( 0, SkillName.Lumberjacking, 5.0 );

            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 15;
            Attributes.WeaponDamage = -50;

            WeaponAttributes.SelfRepair = 4;
        }

        public MelisandesCorrodedHatchet( Serial serial ) : base( serial )
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
