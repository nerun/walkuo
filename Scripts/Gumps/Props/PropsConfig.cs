/* ***************************************************************************
 * PropsConfig.cs
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

namespace Server.Gumps
{
	public class PropsConfig
	{
		public static readonly bool OldStyle = false;

		public static readonly int GumpOffsetX = 30;
		public static readonly int GumpOffsetY = 30;

		public static readonly int TextHue = 0;
		public static readonly int TextOffsetX = 2;

		public static readonly int OffsetGumpID = 0x0A40; // Pure black
		public static readonly int HeaderGumpID = OldStyle ? 0x0BBC : 0x0E14; // Light offwhite, textured : Dark navy blue, textured
		public static readonly int  EntryGumpID = 0x0BBC; // Light offwhite, textured
		public static readonly int   BackGumpID = 0x13BE; // Gray slate/stoney
		public static readonly int    SetGumpID = OldStyle ? 0x0000 : 0x0E14; // Empty : Dark navy blue, textured

		public static readonly int SetWidth = 20;
		public static readonly int SetOffsetX = OldStyle ? 4 : 2, SetOffsetY = 2;
		public static readonly int SetButtonID1 = 0x15E1; // Arrow pointing right
		public static readonly int SetButtonID2 = 0x15E5; // " pressed

		public static readonly int PrevWidth = 20;
		public static readonly int PrevOffsetX = 2, PrevOffsetY = 2;
		public static readonly int PrevButtonID1 = 0x15E3; // Arrow pointing left
		public static readonly int PrevButtonID2 = 0x15E7; // " pressed

		public static readonly int NextWidth = 20;
		public static readonly int NextOffsetX = 2, NextOffsetY = 2;
		public static readonly int NextButtonID1 = 0x15E1; // Arrow pointing right
		public static readonly int NextButtonID2 = 0x15E5; // " pressed

		public static readonly int OffsetSize = 1;

		public static readonly int EntryHeight = 20;
		public static readonly int BorderSize = 10;
	}
}
