/* ***************************************************************************
 * AssassinSpike.cs
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
    [FlipableAttribute( 0x2D21, 0x2D2D )]
    public class AssassinSpike : BaseKnife
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.InfectiousStrike; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

        public override int AosStrengthReq{ get{ return 15; } }
        public override int AosMinDamage{ get{ return 10; } }
        public override int AosMaxDamage{ get{ return 12; } }
        public override int AosSpeed{ get{ return 50; } }
        public override float MlSpeed{ get{ return 2.00f; } }

        public override int OldStrengthReq{ get{ return 15; } }
        public override int OldMinDamage{ get{ return 10; } }
        public override int OldMaxDamage{ get{ return 12; } }
        public override int OldSpeed{ get{ return 50; } }

        public override int DefMissSound{ get{ return 0x239; } }
        public override SkillName DefSkill { get { return SkillName.Fencing; } }

        public override int InitMinHits{ get{ return 30; } } // TODO
        public override int InitMaxHits{ get{ return 60; } } // TODO

        [Constructable]
        public AssassinSpike() : base( 0x2D21 )
        {
            Weight = 4.0;
        }

        public AssassinSpike( Serial serial ) : base( serial )
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
