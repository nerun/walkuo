/* ***************************************************************************
 * ParentNode.cs
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
using System.Xml;
using System.Collections;
using Server;

namespace Server.Gumps
{
    public class ParentNode
    {
        private ParentNode m_Parent;
        private object[] m_Children;

        private string m_Name;

        public ParentNode( XmlTextReader xml, ParentNode parent )
        {
            m_Parent = parent;

            Parse( xml );
        }

        private void Parse( XmlTextReader xml )
        {
            if ( xml.MoveToAttribute( "name" ) )
                m_Name = xml.Value;
            else
                m_Name = "empty";

            if ( xml.IsEmptyElement )
            {
                m_Children = new object[0];
            }
            else
            {
                ArrayList children = new ArrayList();

                while ( xml.Read() && ( xml.NodeType == XmlNodeType.Element || xml.NodeType == XmlNodeType.Comment ) )
                {
                    if ( xml.NodeType == XmlNodeType.Comment )
                        continue;

                    if ( xml.Name == "child" )
                    {
                        ChildNode n = new ChildNode( xml, this );

                        children.Add( n );
                    }
                    else
                    {
                        children.Add( new ParentNode( xml, this ) );
                    }
                }

                m_Children = children.ToArray();
            }
        }

        public ParentNode Parent
        {
            get
            {
                return m_Parent;
            }
        }

        public object[] Children
        {
            get
            {
                return m_Children;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }
    }
}
