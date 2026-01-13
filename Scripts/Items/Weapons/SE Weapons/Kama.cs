/* ***************************************************************************
 * Kama.cs
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
    [FlipableAttribute( 0x27AD, 0x27F8 )]
    public class Kama : BaseKnife
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.DefenseMastery; } }

        public override int AosStrengthReq{ get{ return 15; } }
        public override int AosMinDamage{ get{ return 9; } }
        public override int AosMaxDamage{ get{ return 11; } }
        public override int AosSpeed{ get{ return 55; } }
        public override float MlSpeed{ get{ return 2.00f; } }

        public override int OldStrengthReq{ get{ return 15; } }
        public override int OldMinDamage{ get{ return 9; } }
        public override int OldMaxDamage{ get{ return 11; } }
        public override int OldSpeed{ get{ return 55; } }

        public override int DefHitSound{ get{ return 0x232; } }
        public override int DefMissSound{ get{ return 0x238; } }

        public override int InitMinHits{ get{ return 35; } }
        public override int InitMaxHits{ get{ return 60; } }

        public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
        public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
        public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public Kama() : base( 0x27AD )
        {
            Weight = 7.0;
            Layer = Layer.TwoHanded;
        }

        public Kama( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
