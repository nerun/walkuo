/* ***************************************************************************
 * FlameStrike.cs
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
using Server.Network;

namespace Server.Spells.Seventh
{
    public class FlameStrikeSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Flame Strike", "Kal Vas Flam",
                245,
                9042,
                Reagent.SpidersSilk,
                Reagent.SulfurousAsh
            );

        public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

        public FlameStrikeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget( this );
        }

        public override bool DelayedDamage{ get{ return true; } }

        public void Target( Mobile m )
        {
            if ( !Caster.CanSee( m ) )
            {
                Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
            }
            else if ( CheckHSequence( m ) )
            {
                SpellHelper.Turn( Caster, m );

                SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

                double damage;

                if ( Core.AOS )
                {
                    damage = GetNewAosDamage( 48, 1, 5, m );
                }
                else
                {
                    damage = Utility.Random( 27, 22 );

                    if ( CheckResisted( m ) )
                    {
                        damage *= 0.6;

                        m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
                    }

                    damage *= GetDamageScalar( m );
                }

                m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                m.PlaySound( 0x208 );

                SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private FlameStrikeSpell m_Owner;

            public InternalTarget( FlameStrikeSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
            {
                m_Owner = owner;
            }

            protected override void OnTarget( Mobile from, object o )
            {
                if ( o is Mobile )
                {
                    m_Owner.Target( (Mobile)o );
                }
            }

            protected override void OnTargetFinish( Mobile from )
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
