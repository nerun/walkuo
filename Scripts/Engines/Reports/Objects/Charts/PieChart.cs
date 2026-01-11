/* ***************************************************************************
 * PieChart.cs
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
	public class PieChart : Chart
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "pc", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new PieChart();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private bool m_ShowPercents;

		public bool ShowPercents{ get{ return m_ShowPercents; } set{ m_ShowPercents = value; } }

		public PieChart( string name, string fileName, bool showPercents )
		{
			m_Name = name;
			m_FileName = fileName;
			m_ShowPercents = showPercents;
		}

		private PieChart()
		{
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			base.SerializeAttributes( op );

			op.SetBoolean( "p", m_ShowPercents );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			base.DeserializeAttributes( ip );

			m_ShowPercents = ip.GetBoolean( "p" );
		}
	}
}
