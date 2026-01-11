/* ***************************************************************************
 * Moonglow.cs
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

namespace Server.Factions
{
	public class Moonglow : Town
	{
		public Moonglow()
		{
			Definition =
				new TownDefinition(
					3,
					0x186C,
					"Moonglow",
					"Moonglow",
					new TextDefinition( 1011435, "MOONGLOW" ),
					new TextDefinition( 1011563, "TOWN STONE FOR MOONGLOW" ),
					new TextDefinition( 1041037, "The Faction Sigil Monolith of Moonglow" ),
					new TextDefinition( 1041407, "The Faction Town Sigil Monolith of Moonglow" ),
					new TextDefinition( 1041416, "Faction Town Stone of Moonglow" ),
					new TextDefinition( 1041398, "Faction Town Sigil of Moonglow" ),
					new TextDefinition( 1041389, "Corrupted Faction Town Sigil of Moonglow" ),
					new Point3D( 4436, 1083, 0 ),
					new Point3D( 4432, 1086, 0 ) );
		}
	}
}
