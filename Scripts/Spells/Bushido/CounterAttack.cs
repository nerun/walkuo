/* ***************************************************************************
 * CounterAttack.cs
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
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Bushido
{
    public class CounterAttack : SamuraiSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "CounterAttack", null,
                -1,
                9002
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 0.25 ); } }

        public override double RequiredSkill{ get{ return 40.0; } }
        public override int RequiredMana{ get{ return 5; } }

        public override bool CheckCast()
        {
            if ( !base.CheckCast() )
                return false;

            if ( Caster.FindItemOnLayer( Layer.TwoHanded ) as BaseShield != null )
                return true;

            if ( Caster.FindItemOnLayer( Layer.OneHanded ) as BaseWeapon != null )
                return true;

            if ( Caster.FindItemOnLayer( Layer.TwoHanded ) as BaseWeapon != null )
                return true;

            Caster.SendLocalizedMessage( 1062944 ); // You must have a weapon or a shield equipped to use this ability!
            return false;
        }

        public CounterAttack( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnBeginCast()
        {
            base.OnBeginCast();

            Caster.FixedEffect( 0x37C4, 10, 7, 4, 3 );
        }

        public override void OnCast()
        {
            if ( CheckSequence() )
            {
                Caster.SendLocalizedMessage( 1063118 ); // You prepare to respond immediately to the next blocked blow.

                OnCastSuccessful( Caster );

                StartCountering( Caster );
            }

            FinishSequence();
        }

        private static Hashtable m_Table = new Hashtable();

        public static bool IsCountering( Mobile m )
        {
            return m_Table.Contains( m );
        }

        public static void StartCountering( Mobile m )
        {
            Timer t = (Timer)m_Table[m];

            if ( t != null )
                t.Stop();

            t = new InternalTimer( m );

            m_Table[m] = t;

            t.Start();
        }

        public static void StopCountering( Mobile m )
        {
            Timer t = (Timer)m_Table[m];

            if ( t != null )
                t.Stop();

            m_Table.Remove( m );

            OnEffectEnd( m, typeof( CounterAttack ) );
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer( Mobile m ) : base( TimeSpan.FromSeconds( 30.0 ) )
            {
                m_Mobile = m;
                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                StopCountering( m_Mobile );
                m_Mobile.SendLocalizedMessage( 1063119 ); // You return to your normal stance.
            }
        }
    }
}
