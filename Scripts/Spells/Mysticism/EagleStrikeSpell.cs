/* ***************************************************************************
 * EagleStrikeSpell.cs
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
﻿using System;
using Server.Targeting;

namespace Server.Spells.Mysticism
{
	public class EagleStrikeSpell : MysticSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Eagle Strike", "Kal Por Xen",
				-1,
				9002,
				Reagent.Bloodmoss,
				Reagent.Bone,
				Reagent.SpidersSilk,
				Reagent.MandrakeRoot
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.25 ); } }

		public override double RequiredSkill { get { return 20.0; } }
		public override int RequiredMana { get { return 9; } }

		public EagleStrikeSpell( Mobile caster, Item scroll )
			: base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( CheckHSequence( m ) )
			{
				/* Conjures a magical eagle that assaults the Target with
				 * its talons, dealing energy damage.
				 */

				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( 2, Caster, ref m );

				Caster.MovingParticles( m, 0x407A, 7, 0, false, true, 0, 0, 0xBBE, 0xFA6, 0xFFFF, 0 );
				Caster.PlaySound( 0x2EE );

				Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), Damage, m );
			}

			FinishSequence();
		}

		private void Damage( Mobile to )
		{
			if ( to == null )
				return;

			double damage = GetNewAosDamage( 19, 1, 5, to );

			SpellHelper.Damage( this, to, damage, 0, 0, 0, 0, 100 );

			to.PlaySound( 0x64D );
		}

		private class InternalTarget : Target
		{
			private EagleStrikeSpell m_Owner;

			public InternalTarget( EagleStrikeSpell owner )
				: base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}
