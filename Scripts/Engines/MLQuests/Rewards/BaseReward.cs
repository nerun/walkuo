/* ***************************************************************************
 * BaseReward.cs
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
using Server.Mobiles;
using Server.Gumps;
using System.Collections.Generic;

namespace Server.Engines.MLQuests.Rewards
{
	public abstract class BaseReward
	{
		private TextDefinition m_Name;

		public TextDefinition Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public BaseReward( TextDefinition name )
		{
			m_Name = name;
		}

		protected virtual int LabelHeight { get { return 16; } }

		public void WriteToGump( Gump g, int x, ref int y )
		{
			TextDefinition.AddHtmlText( g, x, y, 280, LabelHeight, m_Name, false, false, 0x15F90, 0xBDE784 );
		}

		public abstract void AddRewardItems( PlayerMobile pm, List<Item> rewards );
	}
}
