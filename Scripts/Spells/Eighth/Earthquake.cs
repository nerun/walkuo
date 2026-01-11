/* ***************************************************************************
 * Earthquake.cs
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
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class EarthquakeSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Earthquake", "In Vas Por",
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

		public EarthquakeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool DelayedDamage{ get{ return !Core.AOS; } }

		public override void OnCast()
		{
			if ( SpellHelper.CheckTown( Caster, Caster ) && CheckSequence() )
			{
				List<Mobile> targets = new List<Mobile>();

				Map map = Caster.Map;

				if ( map != null )
					foreach ( Mobile m in Caster.GetMobilesInRange( 1 + (int)(Caster.Skills[SkillName.Magery].Value / 15.0) ) )
						if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) && (!Core.AOS || Caster.InLOS( m )) )
							targets.Add( m );

				Caster.PlaySound( 0x220 );

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = targets[i];

					int damage;

					if ( Core.AOS )
					{
						damage = m.Hits / 2;

						if ( !m.Player )
							damage = Math.Max( Math.Min( damage, 100 ), 15 );
							damage += Utility.RandomMinMax( 0, 15 );

					}
					else
					{
						damage = (m.Hits * 6) / 10;

						if ( !m.Player && damage < 10 )
							damage = 10;
						else if ( damage > 75 )
							damage = 75;
					}

					Caster.DoHarmful( m );
					SpellHelper.Damage( TimeSpan.Zero, m, Caster, damage, 100, 0, 0, 0, 0 );
				}
			}

			FinishSequence();
		}
	}
}
