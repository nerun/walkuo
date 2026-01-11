/* ***************************************************************************
 * HouseRaffleRegion.cs
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
using Server;
using Server.Accounting;
using Server.Items;
using Server.Spells.Sixth;
using Server.Targeting;

namespace Server.Regions
{
	public class HouseRaffleRegion : BaseRegion
	{
		private HouseRaffleStone m_Stone;

		public HouseRaffleRegion( HouseRaffleStone stone )
			: base( null, stone.PlotFacet, Region.DefaultPriority, stone.PlotBounds )
		{
			m_Stone = stone;
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			if ( m_Stone == null )
				return false;

			if ( m_Stone.IsExpired )
				return true;

			if ( m_Stone.Deed == null )
				return false;

			Container pack = from.Backpack;

			if ( pack != null && ContainsDeed( pack ) )
				return true;

			BankBox bank = from.FindBankNoCreate();

			if ( bank != null && ContainsDeed( bank ) )
				return true;

			return false;
		}

		private bool ContainsDeed( Container cont )
		{
			List<HouseRaffleDeed> deeds = cont.FindItemsByType<HouseRaffleDeed>();

			for ( int i = 0; i < deeds.Count; ++i )
			{
				if ( deeds[i] == m_Stone.Deed )
					return true;
			}

			return false;
		}

		public override bool OnTarget( Mobile m, Target t, object o )
		{
			if ( m.Spell != null && m.Spell is MarkSpell && m.AccessLevel == AccessLevel.Player )
			{
				m.SendLocalizedMessage( 501800 ); // You cannot mark an object at that location.
				return false;
			}

			return base.OnTarget( m, t, o );
		}
	}
}
