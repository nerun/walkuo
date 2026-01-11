/* ***************************************************************************
 * LichForm.cs
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
	public class LichFormSpell : TransformationSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Lich Form", "Rel Xen Corp Ort",
				203,
				9031,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
				Reagent.NoxCrystal
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		public override double RequiredSkill{ get{ return 70.0; } }
		public override int RequiredMana{ get{ return 23; } }

		public override int Body{ get{ return 749; } }

		public override int FireResistOffset{ get{ return -10; } }
		public override int ColdResistOffset{ get{ return +10; } }
		public override int PoisResistOffset{ get{ return +10; } }

		public override double TickRate{ get{ return 2.5; } }

		public LichFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void DoEffect( Mobile m )
		{
			m.PlaySound( 0x19C );
			m.FixedParticles( 0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot );
		}

		public override void OnTick( Mobile m )
		{
			--m.Hits;
		}
	}
}
