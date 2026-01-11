/* ***************************************************************************
 * ManaVampire.cs
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
	public class ManaVampireSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Mana Vampire", "Ort Sanct",
				221,
				9032,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		public ManaVampireSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
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
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				int toDrain = 0;

				if ( Core.AOS )
				{
					toDrain = (int)(GetDamageSkill( Caster ) - GetResistSkill( m ));

					if ( !m.Player )
						toDrain /= 2;

					if ( toDrain < 0 )
						toDrain = 0;
					else if ( toDrain > m.Mana )
						toDrain = m.Mana;
				}
				else
				{
					if ( CheckResisted( m ) )
						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					else
						toDrain = m.Mana;
				}

				if ( toDrain > (Caster.ManaMax - Caster.Mana) )
					toDrain = Caster.ManaMax - Caster.Mana;

				m.Mana -= toDrain;
				Caster.Mana += toDrain;

				if ( Core.AOS )
				{
					m.FixedParticles( 0x374A, 1, 15, 5054, 23, 7, EffectLayer.Head );
					m.PlaySound( 0x1F9 );

					Caster.FixedParticles( 0x0000, 10, 5, 2054, EffectLayer.Head );
				}
				else
				{
					m.FixedParticles( 0x374A, 10, 15, 5054, EffectLayer.Head );
					m.PlaySound( 0x1F9 );
				}

				HarmfulSpell( m );
			}

			FinishSequence();
		}

		public override double GetResistPercent( Mobile target )
		{
			return 98.0;
		}

		private class InternalTarget : Target
		{
			private ManaVampireSpell m_Owner;

			public InternalTarget( ManaVampireSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
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
