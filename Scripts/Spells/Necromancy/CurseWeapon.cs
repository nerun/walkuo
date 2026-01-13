/* ***************************************************************************
 * CurseWeapon.cs
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
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
    public class CurseWeaponSpell : NecromancerSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Curse Weapon", "An Sanct Gra Char",
                203,
                9031,
                Reagent.PigIron
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 0.75 ); } }

        public override double RequiredSkill{ get{ return 0.0; } }
        public override int RequiredMana{ get{ return 7; } }

        public CurseWeaponSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            BaseWeapon weapon = Caster.Weapon as BaseWeapon;

            if ( weapon == null || weapon is Fists )
            {
                Caster.SendLocalizedMessage( 501078 ); // You must be holding a weapon.
            }
            else if ( CheckSequence() )
            {
                /* Temporarily imbues a weapon with a life draining effect.
                 * Half the damage that the weapon inflicts is added to the necromancer's health.
                 * The effects lasts for (Spirit Speak skill level / 34) + 1 seconds.
                 * 
                 * NOTE: Above algorithm is fixed point, should be :
                 * (Spirit Speak skill level / 3.4) + 1
                 * 
                 * TODO: What happens if you curse a weapon then give it to someone else? Should they get the drain effect?
                 */

                Caster.PlaySound( 0x387 );
                Caster.FixedParticles( 0x3779, 1, 15, 9905, 32, 2, EffectLayer.Head );
                Caster.FixedParticles( 0x37B9, 1, 14, 9502, 32, 5, (EffectLayer)255 );
                new SoundEffectTimer( Caster ).Start();

                TimeSpan duration = TimeSpan.FromSeconds( (Caster.Skills[SkillName.SpiritSpeak].Value / 3.4) + 1.0 );


                Timer t = (Timer)m_Table[weapon];

                if ( t != null )
                    t.Stop();

                weapon.Cursed = true;

                m_Table[weapon] = t = new ExpireTimer( weapon, duration );

                t.Start();
            }

            FinishSequence();
        }

        private static Hashtable m_Table = new Hashtable();

        private class ExpireTimer : Timer
        {
            private BaseWeapon m_Weapon;

            public ExpireTimer( BaseWeapon weapon, TimeSpan delay ) : base( delay )
            {
                m_Weapon = weapon;
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Weapon.Cursed = false;
                Effects.PlaySound( m_Weapon.GetWorldLocation(), m_Weapon.Map, 0xFA );
                m_Table.Remove( this );
            }
        }

        private class SoundEffectTimer : Timer
        {
            private Mobile m_Mobile;

            public SoundEffectTimer( Mobile m ) : base( TimeSpan.FromSeconds( 0.75 ) )
            {
                m_Mobile = m;
                Priority = TimerPriority.FiftyMS;
            }

            protected override void OnTick()
            {
                m_Mobile.PlaySound( 0xFA );
            }
        }
    }
}
