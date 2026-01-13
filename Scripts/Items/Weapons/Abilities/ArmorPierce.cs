/* ***************************************************************************
 * ArmorPierce.cs
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
using Server;

namespace Server.Items
{
    /// <summary>
    /// Strike your opponent with great force, partially bypassing their armor and inflicting greater damage. Requires either Bushido or Ninjitsu skill
    /// </summary>
    public class ArmorPierce : WeaponAbility
    {
        public ArmorPierce()
        {
        }

        public override bool CheckSkills( Mobile from )
        {
            if( GetSkill( from, SkillName.Ninjitsu ) < 50.0  && GetSkill( from, SkillName.Bushido ) < 50.0 )
            {
                from.SendLocalizedMessage( 1063347, "50" ); // You need ~1_SKILL_REQUIREMENT~ Bushido or Ninjitsu skill to perform that attack!
                return false;
            }

            return base.CheckSkills( from );
        }

        public override int BaseMana{ get{ return 30; } }
        public override double DamageScalar{ get{ return 1.5; } }

        public override bool RequiresSE { get { return true; } }

        public override void OnHit( Mobile attacker, Mobile defender, int damage )
        {
            if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
                return;

            ClearCurrentAbility( attacker );

            attacker.SendLocalizedMessage( 1063350 ); // You pierce your opponent's armor!
            defender.SendLocalizedMessage( 1063351 ); // Your attacker pierced your armor!

            defender.FixedParticles( 0x3728, 1, 26, 0x26D6, 0, 0, EffectLayer.Waist );
        }
    }
}
