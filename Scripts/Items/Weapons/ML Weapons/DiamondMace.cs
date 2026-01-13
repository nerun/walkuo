/* ***************************************************************************
 * DiamondMace.cs
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
    [FlipableAttribute( 0x2D24, 0x2D30 )]
    public class DiamondMace : BaseBashing
    {
        public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
        public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.CrushingBlow; } }

        public override int AosStrengthReq{ get{ return 35; } }
        public override int AosMinDamage{ get{ return 14; } }
        public override int AosMaxDamage{ get{ return 17; } }
        public override int AosSpeed{ get{ return 37; } }
        public override float MlSpeed{ get{ return 3.00f; } }

        public override int OldStrengthReq{ get{ return 35; } }
        public override int OldMinDamage{ get{ return 14; } }
        public override int OldMaxDamage{ get{ return 17; } }
        public override int OldSpeed{ get{ return 37; } }

        public override int InitMinHits{ get{ return 30; } } // TODO
        public override int InitMaxHits{ get{ return 60; } } // TODO

        [Constructable]
        public DiamondMace() : base( 0x2D24 )
        {
            Weight = 10.0;
        }

        public DiamondMace( Serial serial ) : base( serial )
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
