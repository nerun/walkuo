/* ***************************************************************************
 * Yew.cs
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
    public class Yew : Town
    {
        public Yew()
        {
            Definition =
                new TownDefinition(
                    4,
                    0x186D,
                    "Yew",
                    "Yew",
                    new TextDefinition( 1011438, "YEW" ),
                    new TextDefinition( 1011565, "TOWN STONE FOR YEW" ),
                    new TextDefinition( 1041038, "The Faction Sigil Monolith of Yew" ),
                    new TextDefinition( 1041408, "The Faction Town Sigil Monolith of Yew" ),
                    new TextDefinition( 1041417, "Faction Town Stone of Yew" ),
                    new TextDefinition( 1041399, "Faction Town Sigil of Yew" ),
                    new TextDefinition( 1041390, "Corrupted Faction Town Sigil of Yew" ),
                    new Point3D( 548, 979, 0 ),
                    new Point3D( 542, 980, 0 ) );
        }
    }
}
