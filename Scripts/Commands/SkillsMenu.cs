/* ***************************************************************************
 * SkillsMenu.cs
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
using Server.Targeting;
using Server.Gumps;

namespace Server.Commands
{
	public class Skills
	{
		public static void Initialize()
		{
			Register();
		}

		public static void Register()
		{
			CommandSystem.Register( "Skills", AccessLevel.Counselor, new CommandEventHandler( Skills_OnCommand ) );
		}

		private class SkillsTarget : Target
		{
			public SkillsTarget( ) : base( -1, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					from.SendGump( new SkillsGump( from, (Mobile)o ) );
			}
		}

		[Usage( "Skills" )]
		[Description( "Opens a menu where you can view or edit skills of a targeted mobile." )]
		private static void Skills_OnCommand( CommandEventArgs e )
		{
			e.Mobile.Target = new SkillsTarget();
		}
	}
}
