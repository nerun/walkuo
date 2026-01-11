/* ***************************************************************************
 * AccountComment.cs
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

namespace Server.Accounting
{
	public class AccountComment
	{
		private string m_AddedBy;
		private string m_Content;
		private DateTime m_LastModified;

		/// <summary>
		/// A string representing who added this comment.
		/// </summary>
		public string AddedBy
		{
			get{ return m_AddedBy; }
		}

		/// <summary>
		/// Gets or sets the body of this comment. Setting this value will reset LastModified.
		/// </summary>
		public string Content
		{
			get{ return m_Content; }
			set{ m_Content = value; m_LastModified = DateTime.UtcNow; }
		}

		/// <summary>
		/// The date and time when this account was last modified -or- the comment creation time, if never modified.
		/// </summary>
		public DateTime LastModified
		{
			get{ return m_LastModified; }
		}

		/// <summary>
		/// Constructs a new AccountComment instance.
		/// </summary>
		/// <param name="addedBy">Initial AddedBy value.</param>
		/// <param name="content">Initial Content value.</param>
		public AccountComment( string addedBy, string content )
		{
			m_AddedBy = addedBy;
			m_Content = content;
			m_LastModified = DateTime.UtcNow;
		}

		/// <summary>
		/// Deserializes an AccountComment instance from an xml element.
		/// </summary>
		/// <param name="node">The XmlElement instance from which to deserialize.</param>
		public AccountComment( XmlElement node )
		{
			m_AddedBy = Utility.GetAttribute( node, "addedBy", "empty" );
			m_LastModified = Utility.GetXMLDateTime( Utility.GetAttribute( node, "lastModified" ), DateTime.UtcNow );
			m_Content = Utility.GetText( node, "" );
		}

		/// <summary>
		/// Serializes this AccountComment instance to an XmlTextWriter.
		/// </summary>
		/// <param name="xml">The XmlTextWriter instance from which to serialize.</param>
		public void Save( XmlTextWriter xml )
		{
			xml.WriteStartElement( "comment" );

			xml.WriteAttributeString( "addedBy", m_AddedBy );

			xml.WriteAttributeString( "lastModified", XmlConvert.ToString( m_LastModified, XmlDateTimeSerializationMode.Utc ) );

			xml.WriteString( m_Content );

			xml.WriteEndElement();
		}
	}
}
