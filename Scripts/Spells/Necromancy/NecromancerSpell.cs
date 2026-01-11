/* ***************************************************************************
 * NecromancerSpell.cs
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
using Server;
using Server.Items;

namespace Server.Spells.Necromancy
{
	public abstract class NecromancerSpell : Spell
	{
		public abstract double RequiredSkill{ get; }
		public abstract int RequiredMana{ get; }

		public override SkillName CastSkill{ get{ return SkillName.Necromancy; } }
		public override SkillName DamageSkill{ get{ return SkillName.SpiritSpeak; } }

		//public override int CastDelayBase{ get{ return base.CastDelayBase; } } // Reference, 3

		public override bool ClearHandsOnCast{ get{ return false; } }

		public override double CastDelayFastScalar{ get{ return (Core.SE? base.CastDelayFastScalar : 0); } } // Necromancer spells are not affected by fast cast items, though they are by fast cast recovery

		public NecromancerSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
		{
		}

		public override int ComputeKarmaAward()
		{
			//TODO: Verify this formula being that Necro spells don't HAVE a circle.
			//int karma = -(70 + (10 * (int)Circle));
			int karma = -(40 + (int)(10 * (CastDelayBase.TotalSeconds / CastDelaySecondsPerTick)));

			if ( Core.ML ) // Pub 36: "Added a new property called Increased Karma Loss which grants higher karma loss for casting necromancy spells."
				karma += AOS.Scale( karma, AosAttributes.GetValue( Caster, AosAttribute.IncreasedKarmaLoss ) );

			return karma;
		}

		public override void GetCastSkills( out double min, out double max )
		{
			min = RequiredSkill;
			max = Scroll != null ? min : RequiredSkill + 40.0;
		}

		public override bool ConsumeReagents()
		{
			if( base.ConsumeReagents() )
				return true;

			if( ArcaneGem.ConsumeCharges( Caster, 1 ) )
				return true;

			return false;
		}

		public override int GetMana()
		{
			return RequiredMana;
		}
	}
}
