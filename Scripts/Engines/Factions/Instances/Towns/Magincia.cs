/* ***************************************************************************
 * Magincia.cs
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
	public class Magincia : Town
	{
		public Magincia()
		{
			Definition =
				new TownDefinition(
					7,
					0x1870,
					"Magincia",
					"Magincia",
					new TextDefinition( 1011440, "MAGINCIA" ),
					new TextDefinition( 1011568, "TOWN STONE FOR MAGINCIA" ),
					new TextDefinition( 1041041, "The Faction Sigil Monolith of Magincia" ),
					new TextDefinition( 1041411, "The Faction Town Sigil Monolith of Magincia" ),
					new TextDefinition( 1041420, "Faction Town Stone of Magincia" ),
					new TextDefinition( 1041402, "Faction Town Sigil of Magincia" ),
					new TextDefinition( 1041393, "Corrupted Faction Town Sigil of Magincia" ),
					new Point3D( 3714, 2235, 20 ),
					new Point3D( 3712, 2230, 20 ) );
		}
	}
}
