/* ***************************************************************************
 * BloodRose.cs
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
using System.Collections.Generic;
using System.Text;

using Server;
using Server.Mobiles;
using Server.Factions;

namespace Server {
    public sealed class BloodRose : PowerFactionItem {
        public override string DefaultName {
            get {
                return "blood rose";
            }
        }

        public BloodRose()
            : base( Utility.RandomList( 6378, 9035 ) ) {
            Hue = 2118;
        }

        public BloodRose( Serial serial )
            : base( serial ) {
        }

        public override bool Use( Mobile from ) {
            if ( from.GetStatMod( "blood-rose" ) == null ) {
                from.PlaySound( Utility.Random( 0x3A, 3 ) );

                if ( from.Body.IsHuman && !from.Mounted ) {
                    from.Animate( 34, 5, 1, true, false, 0 );
                }

                int amount = Utility.Dice( 3, 3, 3 );
                int time = Utility.RandomMinMax( 5, 30 );

                from.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );

                from.PlaySound( 0x1EE );
                from.AddStatMod( new StatMod( StatType.All, "blood-rose", amount, TimeSpan.FromMinutes( time ) ) );

                return true;
            } else {
                from.SendLocalizedMessage( 1062927 ); // You have eaten one of these recently and eating another would provide no benefit.

                return false;
            }
        }

        public override void Serialize( GenericWriter writer ) {
            base.Serialize( writer );

            writer.WriteEncodedInt( ( int ) 0 ); // version
        }

        public override void Deserialize( GenericReader reader ) {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
