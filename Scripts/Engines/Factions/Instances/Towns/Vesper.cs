/* ***************************************************************************
 * Vesper.cs
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
    public class Vesper : Town
    {
        public Vesper()
        {
            Definition =
                new TownDefinition(
                    5,
                    0x186E,
                    "Vesper",
                    "Vesper",
                    new TextDefinition( 1016413, "VESPER" ),
                    new TextDefinition( 1011566, "TOWN STONE FOR VESPER" ),
                    new TextDefinition( 1041039, "The Faction Sigil Monolith of Vesper" ),
                    new TextDefinition( 1041409, "The Faction Town Sigil Monolith of Vesper" ),
                    new TextDefinition( 1041418, "Faction Town Stone of Vesper" ),
                    new TextDefinition( 1041400, "Faction Town Sigil of Vesper" ),
                    new TextDefinition( 1041391, "Corrupted Faction Town Sigil of Vesper" ),
                    new Point3D( 2982, 818, 0 ),
                    new Point3D( 2985, 821, 0 ) );
        }
    }
}
