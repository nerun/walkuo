/* ***************************************************************************
 * AirElemental.cs
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
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
    public class AirElementalSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Air Elemental", "Kal Vas Xen Hur",
                269,
                9010,
                false,
                Reagent.Bloodmoss,
                Reagent.MandrakeRoot,
                Reagent.SpidersSilk
            );

        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

        public AirElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override bool CheckCast()
        {
            if ( !base.CheckCast() )
                return false;

            if ( (Caster.Followers + 2) > Caster.FollowersMax )
            {
                Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if ( CheckSequence() )
            {
                TimeSpan duration = TimeSpan.FromSeconds( (2 * Caster.Skills.Magery.Fixed) / 5 );

                if ( Core.AOS )
                    SpellHelper.Summon( new SummonedAirElemental(), Caster, 0x217, duration, false, false );
                else
                    SpellHelper.Summon( new AirElemental(), Caster, 0x217, duration, false, false );
            }

            FinishSequence();
        }
    }
}
