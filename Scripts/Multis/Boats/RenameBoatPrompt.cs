/* ***************************************************************************
 * RenameBoatPrompt.cs
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
using Server.Prompts;

namespace Server.Multis
{
	public class RenameBoatPrompt : Prompt
	{
		private BaseBoat m_Boat;

		public RenameBoatPrompt( BaseBoat boat )
		{
			m_Boat = boat;
		}

		public override void OnResponse( Mobile from, string text )
		{
			m_Boat.EndRename( from, text );
		}
	}
}
