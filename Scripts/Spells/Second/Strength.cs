/* ***************************************************************************
 * Strength.cs
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

namespace Server.Spells.Second
{
    public class StrengthSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Strength", "Uus Mani",
                212,
                9061,
                Reagent.MandrakeRoot,
                Reagent.Nightshade
            );

        public override SpellCircle Circle { get { return SpellCircle.Second; } }

        public StrengthSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override bool CheckCast()
        {
            if ( Engines.ConPVP.DuelContext.CheckSuddenDeath( Caster ) )
            {
                Caster.SendMessage( 0x22, "You cannot cast this spell when in sudden death." );
                return false;
            }

            return base.CheckCast();
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget( this );
        }

        public void Target( Mobile m )
        {
            if ( !Caster.CanSee( m ) )
            {
                Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
            }
            else if ( CheckBSequence( m ) )
            {
                SpellHelper.Turn( Caster, m );

                SpellHelper.AddStatBonus( Caster, m, StatType.Str );

                m.FixedParticles( 0x375A, 10, 15, 5017, EffectLayer.Waist );
                m.PlaySound( 0x1EE );

                int percentage = (int)(SpellHelper.GetOffsetScalar( Caster, m, false )*100);
                TimeSpan length = SpellHelper.GetDuration( Caster, m );

                BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.Strength, 1075845, length, m, percentage.ToString() ) );
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private StrengthSpell m_Owner;

            public InternalTarget( StrengthSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Beneficial )
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
