/* ***************************************************************************
 * Snapshot.cs
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
using System.Collections;

namespace Server.Engines.Reports
{
	public class Snapshot : PersistableObject
	{
		#region Type Identification
		public static readonly PersistableType ThisTypeID = new PersistableType( "ss", new ConstructCallback( Construct ) );

		private static PersistableObject Construct()
		{
			return new Snapshot();
		}

		public override PersistableType TypeID{ get{ return ThisTypeID; } }
		#endregion

		private DateTime m_TimeStamp;
		private ObjectCollection m_Children;

		public DateTime TimeStamp{ get{ return m_TimeStamp; } set{ m_TimeStamp = value; } }
		public ObjectCollection Children{ get{ return m_Children; } set{ m_Children = value; } }

		public Snapshot()
		{
			m_Children = new ObjectCollection();
		}

		public override void SerializeAttributes( PersistanceWriter op )
		{
			op.SetDateTime( "t", m_TimeStamp );
		}

		public override void DeserializeAttributes( PersistanceReader ip )
		{
			m_TimeStamp = ip.GetDateTime( "t" );
		}

		public override void SerializeChildren( PersistanceWriter op )
		{
			for ( int i = 0; i < m_Children.Count; ++i )
				m_Children[i].Serialize( op );
		}

		public override void DeserializeChildren( PersistanceReader ip )
		{
			while ( ip.HasChild )
				m_Children.Add( ip.GetChild() );
		}
	}
}
