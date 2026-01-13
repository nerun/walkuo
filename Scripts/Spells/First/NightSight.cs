/* ***************************************************************************
 * NightSight.cs
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
using Server;

namespace Server.Spells.First
{
    public class NightSightSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Night Sight", "In Lor",
                236,
                9031,
                Reagent.SulfurousAsh,
                Reagent.SpidersSilk
            );

        public override SpellCircle Circle { get { return SpellCircle.First; } }

        public NightSightSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            Caster.Target = new NightSightTarget( this );
        }

        private class NightSightTarget : Target
        {
            private Spell m_Spell;

            public NightSightTarget( Spell spell ) : base( 12, false, TargetFlags.Beneficial )
            {
                m_Spell = spell;
            }

            protected override void OnTarget( Mobile from, object targeted )
            {
                if ( targeted is Mobile && m_Spell.CheckBSequence( (Mobile) targeted ) )
                {
                    Mobile targ = (Mobile)targeted;

                    SpellHelper.Turn( m_Spell.Caster, targ );

                    if ( targ.BeginAction( typeof( LightCycle ) ) )
                    {
                        new LightCycle.NightSightTimer( targ ).Start();
                        int level = (int)( LightCycle.DungeonLevel * ( (Core.AOS ? targ.Skills[SkillName.Magery].Value : from.Skills[SkillName.Magery].Value )/ 100 ) );

                        if ( level < 0 )
                            level = 0;

                        targ.LightLevel = level;

                        targ.FixedParticles( 0x376A, 9, 32, 5007, EffectLayer.Waist );
                        targ.PlaySound( 0x1E3 );

                        BuffInfo.AddBuff( targ, new BuffInfo( BuffIcon.NightSight, 1075643 ) );    //Night Sight/You ignore lighting effects
                    }
                    else
                    {
                        from.SendMessage( "{0} already have nightsight.", from == targ ? "You" : "They" );
                    }
                }

                m_Spell.FinishSequence();
            }

            protected override void OnTargetFinish( Mobile from )
            {
                m_Spell.FinishSequence();
            }
        }
    }
}
