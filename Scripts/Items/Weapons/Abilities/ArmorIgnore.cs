/* ***************************************************************************
 * ArmorIgnore.cs
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

namespace Server.Items
{
	/// <summary>
	/// This special move allows the skilled warrior to bypass his target's physical resistance, for one shot only.
	/// The Armor Ignore shot does slightly less damage than normal.
	/// Against a heavily armored opponent, this ability is a big win, but when used against a very lightly armored foe, it might be better to use a standard strike!
	/// </summary>
	public class ArmorIgnore : WeaponAbility
	{
		public ArmorIgnore()
		{
		}

		public override int BaseMana{ get{ return 30; } }
		public override double DamageScalar{ get{ return 0.9; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			if ( !Validate( attacker ) || !CheckMana( attacker, true ) )
				return;

			ClearCurrentAbility( attacker );

			attacker.SendLocalizedMessage( 1060076 ); // Your attack penetrates their armor!
			defender.SendLocalizedMessage( 1060077 ); // The blow penetrated your armor!

			defender.PlaySound( 0x56 );
			defender.FixedParticles( 0x3728, 200, 25, 9942, EffectLayer.Waist );
		}
	}
}
