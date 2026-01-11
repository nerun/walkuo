/* ***************************************************************************
 * ScreenCommandImplementor.cs
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

namespace Server.Commands.Generic
{
	public class ScreenCommandImplementor : BaseCommandImplementor
	{
		public ScreenCommandImplementor()
		{
			Accessors = new string[]{ "Screen" };
			SupportRequirement = CommandSupport.Area;
			SupportsConditionals = true;
			AccessLevel = AccessLevel.GameMaster;
			Usage = "Screen <command> [condition]";
			Description = "Invokes the command on all appropriate objects in your screen. Optional condition arguments can further restrict the set of objects.";
		}

		public override void Process( Mobile from, BaseCommand command, string[] args )
		{
			RangeCommandImplementor impl = RangeCommandImplementor.Instance;

			if ( impl == null )
				return;

			impl.Process( 18, from, command, args );
		}
	}
}
