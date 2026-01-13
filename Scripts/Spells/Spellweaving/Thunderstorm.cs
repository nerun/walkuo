/* ***************************************************************************
 * Thunderstorm.cs
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
using System.Collections.Generic;

namespace Server.Spells.Spellweaving
{
    public class ThunderstormSpell : ArcanistSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Thunderstorm", "Erelonia",
                -1
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.5 ); } }

        public override double RequiredSkill { get { return 10.0; } }
        public override int RequiredMana { get { return 32; } }

        public ThunderstormSpell( Mobile caster, Item scroll )
            : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            if( CheckSequence() )
            {
                Caster.PlaySound( 0x5CE );

                double skill = Caster.Skills[SkillName.Spellweaving].Value;

                int damage = Math.Max( 11, 10 + (int)(skill / 24) ) + FocusLevel;

                int sdiBonus = AosAttributes.GetValue( Caster, AosAttribute.SpellDamage );
                        
                int pvmDamage = damage * ( 100 + sdiBonus );
                pvmDamage /= 100;

                if ( sdiBonus > 15 )
                    sdiBonus = 15;
                        
                int pvpDamage = damage * ( 100 + sdiBonus );
                pvpDamage /= 100;

                int range = 2 + FocusLevel;
                TimeSpan duration = TimeSpan.FromSeconds( 5 + FocusLevel );

                List<Mobile> targets = new List<Mobile>();

                foreach( Mobile m in Caster.GetMobilesInRange( range ) )
                {
                    if( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) && Caster.InLOS( m ) )
                        targets.Add( m );
                }

                for( int i = 0; i < targets.Count; i++ )
                {
                    Mobile m = targets[i];

                    Caster.DoHarmful( m );

                    Spell oldSpell = m.Spell as Spell;

                    SpellHelper.Damage( this, m, ( m.Player && Caster.Player ) ? pvpDamage : pvmDamage, 0, 0, 0, 0, 100 );

                    if( oldSpell != null && oldSpell != m.Spell )
                    {
                        if( !CheckResisted( m ) )
                        {
                            m_Table[m] = Timer.DelayCall<Mobile>( duration, DoExpire, m );

                            BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.Thunderstorm, 1075800, duration, m, GetCastRecoveryMalus( m ) ) );
                        }
                    }
                }
            }

            FinishSequence();
        }

        private static Dictionary<Mobile, Timer> m_Table = new Dictionary<Mobile, Timer>();

        public static int GetCastRecoveryMalus( Mobile m )
        {
            return m_Table.ContainsKey( m ) ? 6 : 0;
        }

        public static void DoExpire( Mobile m )
        {
            Timer t;

            if( m_Table.TryGetValue( m, out t ) )
            {
                t.Stop();
                m_Table.Remove( m );

                BuffInfo.RemoveBuff( m, BuffIcon.Thunderstorm );
            }
        }
    }
}
