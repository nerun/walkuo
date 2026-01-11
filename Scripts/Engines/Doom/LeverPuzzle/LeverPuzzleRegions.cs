/* ***************************************************************************
 * LeverPuzzleRegions.cs
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
using Server.Mobiles;
using Server.Regions;

namespace Server.Engines.Doom
{
	public class LampRoomRegion : BaseRegion
	{
		private LeverPuzzleController Controller;

		public LampRoomRegion ( LeverPuzzleController controller )
			: base( null, Map.Malas, Region.Find( LeverPuzzleController.lr_Enter, Map.Malas ), LeverPuzzleController.lr_Rect )
		{
			Controller = controller;
			Register();
		}

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( OnLogin );
		}

		public static void OnLogin( LoginEventArgs e )
		{
			Mobile m = e.Mobile;
			Rectangle2D rect = LeverPuzzleController.lr_Rect;
			if ( m.X >= rect.X && m.X <= (rect.X+10) && m.Y >= rect.Y && m.Y <= (rect.Y+10) && m.Map == Map.Internal )
			{
				Timer kick = new LeverPuzzleController.LampRoomKickTimer( m );
				kick.Start();
			}
		}

		public override void OnEnter( Mobile m )
		{
			if ( m == null || m is WandererOfTheVoid )
				return;

			if ( m.AccessLevel > AccessLevel.Player )
				return;

			if ( Controller.Successful != null )
			{
				if ( m is PlayerMobile )
				{
					if ( m == Controller.Successful )
					{
						return;
					}
				}
				else if ( m is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)m;
					if(( bc.Controlled && bc.ControlMaster == Controller.Successful ) || bc.Summoned )
					{
						return;
					}
				}
			}
			Timer kick = new LeverPuzzleController.LampRoomKickTimer( m );
			kick.Start();
		}

		public override void OnExit( Mobile m )
		{
			if( m != null && m == Controller.Successful )
				Controller.RemoveSuccessful();
		}

		public override void OnDeath( Mobile m )
		{
			if( m != null && !m.Deleted &&  !(m is WandererOfTheVoid) )
			{
				Timer kick = new LeverPuzzleController.LampRoomKickTimer( m );
				kick.Start();;
			}
		}

		public override bool OnSkillUse( Mobile m, int Skill ) /* just in case */
		{
			if (( Controller.Successful == null ) || ( m.AccessLevel == AccessLevel.Player && m != Controller.Successful ))
			{
				return false;
			}
			return true;
		}
	}

	public class LeverPuzzleRegion : BaseRegion
	{
		private LeverPuzzleController Controller;
		public Mobile m_Occupant;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Occupant
		{
			get
			{
				if ( m_Occupant != null && m_Occupant.Alive )
					return m_Occupant;
				return null;
			}
		}

		public LeverPuzzleRegion ( LeverPuzzleController controller, int[] loc ) 
			: base( null, Map.Malas, Region.Find( LeverPuzzleController.lr_Enter, Map.Malas ), new Rectangle2D(loc[0],loc[1],1,1) )
		{
			Controller = controller;
			Register();
		}

		public override void OnEnter( Mobile m )
		{
			if( m != null && m_Occupant == null && m is PlayerMobile && m.Alive )
				m_Occupant = m;
		}

		public override void OnExit( Mobile m )
		{
			if( m != null && m == m_Occupant )
				m_Occupant = null;
		}
	}
}


