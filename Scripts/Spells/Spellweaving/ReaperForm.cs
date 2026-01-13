/* ***************************************************************************
 * ReaperForm.cs
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
using Server.Network;

namespace Server.Spells.Spellweaving
{
    public class ReaperFormSpell : ArcaneForm
    {
        private static SpellInfo m_Info = new SpellInfo( "Reaper Form", "Tarisstree", -1 );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.5 ); } }

        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler( OnLogin );
        }

        public static void OnLogin( LoginEventArgs e )
        {
            TransformContext context = TransformationSpellHelper.GetContext( e.Mobile );

            if( context != null && context.Type == typeof( ReaperFormSpell ) )
                e.Mobile.Send( SpeedControl.WalkSpeed );
        }

        public override double RequiredSkill { get { return 24.0; } }
        public override int RequiredMana { get { return 34; } }

        public override int Body { get { return 0x11D; } }

        public override int FireResistOffset { get { return -25; } }
        public override int PhysResistOffset { get { return 5 + FocusLevel; } }        
        public override int ColdResistOffset { get { return 5 + FocusLevel; } }
        public override int PoisResistOffset { get { return 5 + FocusLevel; } }
        public override int NrgyResistOffset { get { return 5 + FocusLevel; } }

        public virtual int SwingSpeedBonus { get { return 10 + FocusLevel; } }
        public virtual int SpellDamageBonus { get { return 10 + FocusLevel; } }

        public ReaperFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void DoEffect( Mobile m )
        {
            m.PlaySound( 0x1BA );

            m.Send( SpeedControl.WalkSpeed );
        }

        public override void RemoveEffect( Mobile m )
        {
            m.Send( SpeedControl.Disable );
        }
    }
}
