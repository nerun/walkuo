/* ***************************************************************************
 * RewardEntry.cs
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

namespace Server.Engines.VeteranRewards
{
	public class RewardEntry
	{
		private RewardList m_List;
		private RewardCategory m_Category;
		private Type m_ItemType;
		private Expansion m_RequiredExpansion;
		private int m_Name;
		private string m_NameString;
		private object[] m_Args;

		public RewardList List{ get{ return m_List; } set{ m_List = value; } }
		public RewardCategory Category{ get{ return m_Category; } }
		public Type ItemType{ get{ return m_ItemType; } }
		public Expansion RequiredExpansion{ get{ return m_RequiredExpansion; } }
		public int Name{ get{ return m_Name; } }
		public string NameString{ get{ return m_NameString; } }
		public object[] Args{ get{ return m_Args; } }

		public Item Construct()
		{
			try
			{
				Item item = Activator.CreateInstance( m_ItemType, m_Args ) as Item;

				if ( item is IRewardItem )
					((IRewardItem)item).IsRewardItem = true;

				return item;
			}
			catch
			{
			}

			return null;
		}

		public RewardEntry( RewardCategory category, int name, Type itemType, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_Name = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, string name, Type itemType, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, int name, Type itemType, Expansion requiredExpansion, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_Name = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, string name, Type itemType, Expansion requiredExpansion, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add( this );
		}
	}
}
