/* ***************************************************************************
 * Trinsic.cs
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
	public class Trinsic : Town
	{
		public Trinsic()
		{
			Definition =
				new TownDefinition(
					1,
					0x186A,
					"Trinsic",
					"Trinsic",
					new TextDefinition( 1011434, "TRINSIC" ),
					new TextDefinition( 1011562, "TOWN STONE FOR TRINSIC" ),
					new TextDefinition( 1041035, "The Faction Sigil Monolith of Trinsic" ),
					new TextDefinition( 1041405, "The Faction Town Sigil Monolith of Trinsic" ),
					new TextDefinition( 1041414, "Faction Town Stone of Trinsic" ),
					new TextDefinition( 1041396, "Faction Town Sigil of Trinsic" ),
					new TextDefinition( 1041387, "Corrupted Faction Town Sigil of Trinsic" ),
					new Point3D( 1914, 2717, 20 ),
					new Point3D( 1909, 2720, 20 ) );
		}
	}
}
