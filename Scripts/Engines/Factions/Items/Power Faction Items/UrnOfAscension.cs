/* ***************************************************************************
 * UrnOfAscension.cs
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
using Server.Gumps;
using Server.Multis;
using Server.Mobiles;
using Server.Factions;

namespace Server {
    public sealed class UrnOfAscension : PowerFactionItem {
        public override string DefaultName {
            get {
                return "urn of ascension";
            }
        }

        public UrnOfAscension()
            : base( 9246 ) {
        }

        public UrnOfAscension( Serial serial )
            : base( serial ) {
        }

        public override bool Use( Mobile from ) {
            Faction ourFaction = Faction.Find( from );

            bool used = false;

            foreach ( Mobile mob in from.GetMobilesInRange( 8 ) ) {
                if ( mob.Player && !mob.Alive && from.InLOS( mob ) ) {
                    if ( Faction.Find( mob ) != ourFaction ) {
                        continue;
                    }

                    BaseHouse house = BaseHouse.FindHouseAt( mob );

                    if ( house == null || ( house.IsFriend( from ) || house.IsFriend( mob ) ) ) {
                        Faction.ClearSkillLoss( mob );

                        mob.SendGump( new ResurrectGump( mob, from, ResurrectMessage.Generic ) );
                        used = true;
                    }
                }
            }

            if ( used ) {
                from.LocalOverheadMessage( Server.Network.MessageType.Regular, 2219, false, "The urn shatters as you invoke its power." );
                from.PlaySound( 64 );

                Effects.PlaySound( from.Location, from.Map, 1481 );
            }

            return used;
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
