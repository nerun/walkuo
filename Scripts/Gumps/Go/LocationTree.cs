/* ***************************************************************************
 * LocationTree.cs
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
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Server;

namespace Server.Gumps
{
	public class LocationTree
	{
		private Map m_Map;
		private ParentNode m_Root;
		private Dictionary<Mobile, ParentNode> m_LastBranch;

		public LocationTree( string fileName, Map map )
		{
			m_LastBranch = new Dictionary<Mobile, ParentNode>();
			m_Map = map;

			string path = Path.Combine( "Data/Locations/", fileName );

			if ( File.Exists( path ) )
			{
				XmlTextReader xml = new XmlTextReader( new StreamReader( path ) );

				xml.WhitespaceHandling = WhitespaceHandling.None;

				m_Root = Parse( xml );

				xml.Close();
			}
		}

		public Dictionary<Mobile, ParentNode> LastBranch
		{
			get
			{
				return m_LastBranch;
			}
		}

		public Map Map
		{
			get
			{
				return m_Map;
			}
		}

		public ParentNode Root
		{
			get
			{
				return m_Root;
			}
		}

		private ParentNode Parse( XmlTextReader xml )
		{
			xml.Read();
			xml.Read();
			xml.Read();

			return new ParentNode( xml, null );
		}
	}
}
