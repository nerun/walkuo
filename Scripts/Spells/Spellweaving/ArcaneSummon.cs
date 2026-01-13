/* ***************************************************************************
 * ArcaneSummon.cs
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
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.Spellweaving
{
    public abstract class ArcaneSummon<T> : ArcanistSpell where T : BaseCreature
    {
        public abstract int Sound { get; }

        public ArcaneSummon( Mobile caster, Item scroll, SpellInfo info )
            : base( caster, scroll, info )
        {
        }

        public override bool CheckCast()
        {
            if( !base.CheckCast() )
                return false;

            if( (Caster.Followers + 1) > Caster.FollowersMax )
            {
                Caster.SendLocalizedMessage( 1074270 ); // You have too many followers to summon another one.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if( CheckSequence() )
            {
                TimeSpan duration = TimeSpan.FromMinutes( Caster.Skills.Spellweaving.Value /24 + FocusLevel*2 );
                int summons = Math.Min( 1+FocusLevel, Caster.FollowersMax - Caster.Followers );

                for( int i = 0; i < summons; i++ )
                {
                    BaseCreature bc;

                    try { bc = Activator.CreateInstance<T>(); }
                    catch { break; }

                    SpellHelper.Summon( bc, Caster, Sound, duration, false, false );
                }

                FinishSequence();
            }
        }
    }
}
