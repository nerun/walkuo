/* ***************************************************************************
 * WarFork.cs
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
    [FlipableAttribute( 0x1405, 0x1404 )]
    public class WarFork : BaseSpear
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

        public override int AosStrengthReq{ get{ return 45; } }
        public override int AosMinDamage{ get{ return 12; } }
        public override int AosMaxDamage{ get{ return 13; } }
        public override int AosSpeed{ get{ return 43; } }
        public override float MlSpeed{ get{ return 2.50f; } }

        public override int OldStrengthReq{ get{ return 35; } }
        public override int OldMinDamage{ get{ return 4; } }
        public override int OldMaxDamage{ get{ return 32; } }
        public override int OldSpeed{ get{ return 45; } }

        public override int DefHitSound{ get{ return 0x236; } }
        public override int DefMissSound{ get{ return 0x238; } }

        public override int InitMinHits{ get{ return 31; } }
        public override int InitMaxHits{ get{ return 110; } }

        public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

        [Constructable]
        public WarFork() : base( 0x1405 )
        {
            Weight = 9.0;
        }

        public WarFork( Serial serial ) : base( serial )
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
