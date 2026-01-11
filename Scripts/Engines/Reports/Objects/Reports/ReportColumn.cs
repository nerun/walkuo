/* ***************************************************************************
 * ReportColumn.cs
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

namespace Server.Engines.Reports
{
	public class ReportColumn : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "rc", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new ReportColumn();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private string m_Width;
		private string m_Align;
		private string m_Name;

		public string Width{ get{ return m_Width; } set{ m_Width = value; } }
		public string Align{ get{ return m_Align; } set{ m_Align = value; } }
		public string Name{ get{ return m_Name; } set{ m_Name = value; } }

		private ReportColumn()
		{
		}

		public ReportColumn( string width, string align ) : this( width, align, null )
		{
		}

		public ReportColumn( string width, string align, string name )
		{
			m_Width = width;
			m_Align = align;
			m_Name = name;
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetString( "w", m_Width );
			op.SetString( "a", m_Align );
			op.SetString( "n", m_Name );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_Width = Utility.Intern( ip.GetString( "w" ) );
			m_Align = Utility.Intern( ip.GetString( "a" ) );
			m_Name = Utility.Intern( ip.GetString( "n" ) );
		}
	}
}
