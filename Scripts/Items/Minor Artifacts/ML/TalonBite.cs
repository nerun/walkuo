/* ***************************************************************************
 * TalonBite.cs
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
    public class TalonBite : OrnateAxe
    {
        public override int LabelNumber{ get{ return 1075029; } } // Talon Bite

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public TalonBite()
        {
            ItemID = 0x2D34;
            Hue = 0x47E;

            SkillBonuses.SetValues( 0, SkillName.Tactics, 10.0 );

            Attributes.BonusDex = 8;
            Attributes.WeaponSpeed = 20;
            Attributes.WeaponDamage = 35;

            WeaponAttributes.HitHarm = 33;
            WeaponAttributes.UseBestSkill = 1;
        }

        public TalonBite( Serial serial ) : base( serial )
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
