/* ***************************************************************************
 * VendorList.cs
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
using System.Collections.Generic;

namespace Server.Factions
{
	public class VendorList
	{
		private VendorDefinition m_Definition;
		private List<BaseFactionVendor> m_Vendors;

		public VendorDefinition Definition{ get{ return m_Definition; } }
		public List<BaseFactionVendor> Vendors { get { return m_Vendors; } }

		public BaseFactionVendor Construct( Town town, Faction faction )
		{
			try{ return Activator.CreateInstance( m_Definition.Type, new object[]{ town, faction } ) as BaseFactionVendor; }
			catch{ return null; }
		}

		public VendorList( VendorDefinition definition )
		{
			m_Definition = definition;
			m_Vendors = new List<BaseFactionVendor>();
		}
	}
}
