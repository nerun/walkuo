/* ***************************************************************************
 * WhirlwindAttack.cs
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
using System.Collections;
using Server;
using Server.Spells;

namespace Server.Items
{
    /// <summary>
    /// A godsend to a warrior surrounded, the Whirlwind Attack allows the fighter to strike at all nearby targets in one mighty spinning swing.
    /// </summary>
    public class WhirlwindAttack : WeaponAbility
    {
        public WhirlwindAttack()
        {
        }

        public override int BaseMana{ get{ return 15; } }

        public override void OnHit( Mobile attacker, Mobile defender, int damage )
        {
            if ( !Validate( attacker )  )
                return;

            ClearCurrentAbility( attacker );

            Map map = attacker.Map;

            if ( map == null )
                return;

            BaseWeapon weapon = attacker.Weapon as BaseWeapon;

            if ( weapon == null )
                return;

            if ( !CheckMana( attacker, true ) )
                return;

            attacker.FixedEffect( 0x3728, 10, 15 );
            attacker.PlaySound( 0x2A1 );

            ArrayList list = new ArrayList();

            foreach ( Mobile m in attacker.GetMobilesInRange( 1 ) )
                list.Add( m );

            ArrayList targets = new ArrayList();

            for ( int i = 0; i < list.Count; ++i )
            {
                Mobile m = (Mobile)list[i];

                if ( m != defender && m != attacker && SpellHelper.ValidIndirectTarget( attacker, m ) )
                {
                    if ( m == null || m.Deleted || m.Map != attacker.Map || !m.Alive || !attacker.CanSee( m ) || !attacker.CanBeHarmful( m ) )
                        continue;

                    if ( !attacker.InRange( m, weapon.MaxRange ) )
                        continue;

                    if ( attacker.InLOS( m ) )
                        targets.Add( m );
                }
            }

            if ( targets.Count > 0 )
            {
                double bushido = attacker.Skills.Bushido.Value;
                double damageBonus = 1.0 + Math.Pow( (targets.Count * bushido) / 60, 2 ) / 100;

                if ( damageBonus > 2.0 )
                    damageBonus = 2.0;
                    
                attacker.RevealingAction();

                for ( int i = 0; i < targets.Count; ++i )
                {
                    Mobile m = (Mobile)targets[i];

                        attacker.SendLocalizedMessage( 1060161 ); // The whirling attack strikes a target!
                        m.SendLocalizedMessage( 1060162 ); // You are struck by the whirling attack and take damage!

                    weapon.OnHit( attacker, m, damageBonus );
                }
            }
        }
    }
}
