/* ***************************************************************************
 * StrongholdRegion.cs
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

namespace Server.Factions
{
	public class StrongholdRegion : BaseRegion
	{
		private Faction m_Faction;

		public Faction Faction
		{
			get{ return m_Faction; }
			set{ m_Faction = value; }
		}

		public StrongholdRegion( Faction faction ) : base( faction.Definition.FriendlyName, Faction.Facet, Region.DefaultPriority, faction.Definition.Stronghold.Area )
		{
			m_Faction = faction;

			Register();
		}

		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( !base.OnMoveInto( m, d, newLocation, oldLocation ) )
				return false;

			if ( m.AccessLevel >= AccessLevel.Counselor || Contains( oldLocation ) )
				return true;
			
			if ( m is PlayerMobile ) {
				PlayerMobile pm = (PlayerMobile)m;

				if ( pm.DuelContext != null ) {
					m.SendMessage( "You may not enter this area while participating in a duel or a tournament." );
					return false;
				}
			}

			return ( Faction.Find( m, true, true ) != null );
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}
	}
}
