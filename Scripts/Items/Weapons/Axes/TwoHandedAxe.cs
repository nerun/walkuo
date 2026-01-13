/* ***************************************************************************
 * TwoHandedAxe.cs
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
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute( 0x1443, 0x1442 )]
    public class TwoHandedAxe : BaseAxe
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

        public override int AosStrengthReq{ get{ return 40; } }
        public override int AosMinDamage{ get{ return 16; } }
        public override int AosMaxDamage{ get{ return 17; } }
        public override int AosSpeed{ get{ return 31; } }
        public override float MlSpeed{ get{ return 3.50f; } }

        public override int OldStrengthReq{ get{ return 35; } }
        public override int OldMinDamage{ get{ return 5; } }
        public override int OldMaxDamage{ get{ return 39; } }
        public override int OldSpeed{ get{ return 30; } }

        public override int InitMinHits{ get{ return 31; } }
        public override int InitMaxHits{ get{ return 90; } }

        [Constructable]
        public TwoHandedAxe() : base( 0x1443 )
        {
            Weight = 8.0;
        }

        public TwoHandedAxe( Serial serial ) : base( serial )
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
