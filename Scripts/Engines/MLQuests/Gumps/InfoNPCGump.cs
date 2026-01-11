/* ***************************************************************************
 * InfoNPCGump.cs
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
using Server.Gumps;
using Server.Network;

namespace Server.Engines.MLQuests.Gumps
{
	public class InfoNPCGump : BaseQuestGump
	{
		public InfoNPCGump( TextDefinition title, TextDefinition message )
			: base( 1060668 ) // INFORMATION
		{
			RegisterButton( ButtonPosition.Left, ButtonGraphic.Close, 3 );

			SetPageCount( 1 );

			BuildPage();
			TextDefinition.AddHtmlText( this, 160, 108, 250, 16, title, false, false, 0x2710, 0x4AC684 );
			TextDefinition.AddHtmlText( this, 98, 156, 312, 180, message, false, true, 0x15F90, 0xBDE784 );
		}
	}
}
