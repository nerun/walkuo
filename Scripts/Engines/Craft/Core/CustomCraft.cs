/* ***************************************************************************
 * CustomCraft.cs
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
using Server.Items;

namespace Server.Engines.Craft
{
	public abstract class CustomCraft
	{
		private Mobile m_From;
		private CraftItem m_CraftItem;
		private CraftSystem m_CraftSystem;
		private Type m_TypeRes;
		private BaseTool m_Tool;
		private int m_Quality;

		public Mobile From{ get{ return m_From; } }
		public CraftItem CraftItem{ get{ return m_CraftItem; } }
		public CraftSystem CraftSystem{ get{ return m_CraftSystem; } }
		public Type TypeRes{ get{ return m_TypeRes; } }
		public BaseTool Tool{ get{ return m_Tool; } }
		public int Quality{ get{ return m_Quality; } }

		public CustomCraft( Mobile from, CraftItem craftItem, CraftSystem craftSystem, Type typeRes, BaseTool tool, int quality )
		{
			m_From = from;
			m_CraftItem = craftItem;
			m_CraftSystem = craftSystem;
			m_TypeRes = typeRes;
			m_Tool = tool;
			m_Quality = quality;
		}

		public abstract void EndCraftAction();
		public abstract Item CompleteCraft( out int message );
	}
}
