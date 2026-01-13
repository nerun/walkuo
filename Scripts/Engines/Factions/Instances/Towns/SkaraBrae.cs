/* ***************************************************************************
 * SkaraBrae.cs
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
    public class SkaraBrae : Town
    {
        public SkaraBrae()
        {
            Definition =
                new TownDefinition(
                    6,
                    0x186F,
                    "Skara Brae",
                    "Skara Brae",
                    new TextDefinition( 1011439, "SKARA BRAE" ),
                    new TextDefinition( 1011567, "TOWN STONE FOR SKARA BRAE" ),
                    new TextDefinition( 1041040, "The Faction Sigil Monolith of Skara Brae" ),
                    new TextDefinition( 1041410, "The Faction Town Sigil Monolith of Skara Brae" ),
                    new TextDefinition( 1041419, "Faction Town Stone of Skara Brae" ),
                    new TextDefinition( 1041401, "Faction Town Sigil of Skara Brae" ),
                    new TextDefinition( 1041392, "Corrupted Faction Town Sigil of Skara Brae" ),
                    new Point3D( 576, 2200, 0 ),
                    new Point3D( 572, 2196, 0 ) );
        }
    }
}
