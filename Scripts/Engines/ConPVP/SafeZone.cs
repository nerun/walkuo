/* ***************************************************************************
 * SafeZone.cs
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
using Server;
using Server.Mobiles;
using Server.Regions;

namespace Server.Engines.ConPVP
{
	public class SafeZone : GuardedRegion
	{
		public static readonly int SafeZonePriority = HouseRegion.HousePriority + 1;

		/*public override bool AllowReds{ get{ return true; } }*/

		public SafeZone( Rectangle2D area, Point3D goloc, Map map, bool isGuarded ) : base( null, map, SafeZonePriority, area )
		{
			GoLocation = goloc;

			this.Disabled = !isGuarded;

			Register();
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			if ( from.AccessLevel < AccessLevel.GameMaster )
				return false;

			return base.AllowHousing( from, p );
		}

		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( m.Player && Factions.Sigil.ExistsOn( m ) )
			{
				m.SendMessage( 0x22, "You are holding a sigil and cannot enter this zone." );
				return false;
			}

			PlayerMobile pm = m as PlayerMobile;

			if ( pm == null && m is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)m;

				if ( bc.Summoned )
					pm = bc.SummonMaster as PlayerMobile;
			}

			if ( pm != null && pm.DuelContext != null && pm.DuelContext.StartedBeginCountdown )
				return true;

			if ( DuelContext.CheckCombat( m ) )
			{
				m.SendMessage( 0x22, "You have recently been in combat and cannot enter this zone." );
				return false;
			}

			return base.OnMoveInto( m, d, newLocation, oldLocation );
		}

		public override void OnEnter( Mobile m )
		{
			m.SendMessage( "You have entered a dueling safezone. No combat other than duels are allowed in this zone." );
		}

		public override void OnExit( Mobile m )
		{
			m.SendMessage( "You have left a dueling safezone. Combat is now unrestricted." );
		}

		public override bool CanUseStuckMenu( Mobile m )
		{
			return false;
		}
	}
}
