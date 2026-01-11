/* ***************************************************************************
 * MovingShot.cs
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
	/// Available on some crossbows, this special move allows archers to fire while on the move.
	/// This shot is somewhat less accurate than normal, but the ability to fire while running is a clear advantage.
	/// </summary>
	public class MovingShot : WeaponAbility
	{
		public MovingShot()
		{
		}

		public override int BaseMana{ get{ return 15; } }
		public override int AccuracyBonus{ get{ return -25; } }

		public override bool OnBeforeSwing( Mobile attacker, Mobile defender )
		{
			return ( Validate( attacker ) && CheckMana( attacker, true ) );
		}
		
		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			//Validates in OnSwing for accuracy scalar

			ClearCurrentAbility( attacker );

			attacker.SendLocalizedMessage( 1060089 ); // You fail to execute your special move
		}

		public override bool ValidatesDuringHit { get { return false; } }

		public override void OnHit( Mobile attacker, Mobile defender, int damage )
		{
			//Validates in OnSwing for accuracy scalar

			ClearCurrentAbility( attacker );

			attacker.SendLocalizedMessage( 1060216 ); // Your shot was successful
		}
	}
}
