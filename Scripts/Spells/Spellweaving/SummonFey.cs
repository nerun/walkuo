/* ***************************************************************************
 * SummonFey.cs
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
using Server.Mobiles;
using Server.Engines.MLQuests;

namespace Server.Spells.Spellweaving
{
	public class SummonFeySpell : ArcaneSummon<ArcaneFey>
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Summon Fey", "Alalithra",
				-1
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.5 ); } }

		public override double RequiredSkill { get { return 38.0; } }
		public override int RequiredMana { get { return 10; } }

		public SummonFeySpell( Mobile caster, Item scroll )
			: base( caster, scroll, m_Info )
		{
		}

		public override int Sound { get { return 0x217; } }

		public override bool CheckSequence()
		{
			Mobile caster = Caster;

			// This is done after casting completes
			if ( caster is PlayerMobile )
			{
				MLQuestContext context = MLQuestSystem.GetContext( (PlayerMobile)caster );

				if ( context == null || !context.SummonFey )
				{
					caster.SendLocalizedMessage( 1074563 ); // You haven't forged a friendship with the fey and are unable to summon their aid.
					return false;
				}
			}

			return base.CheckSequence();
		}
	}
}
