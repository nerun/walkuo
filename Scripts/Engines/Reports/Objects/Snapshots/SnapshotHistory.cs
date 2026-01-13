/* ***************************************************************************
 * SnapshotHistory.cs
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
using System.IO;
using System.Xml;

namespace Server.Engines.Reports
{
    public class SnapshotHistory : PersistableObject
    {
        #region Type Identification
        public static readonly PersistableType ThisTypeID = new PersistableType( "sh", new ConstructCallback( Construct ) );

        private static PersistableObject Construct()
        {
            return new SnapshotHistory();
        }

        public override PersistableType TypeID{ get{ return ThisTypeID; } }
        #endregion

        private SnapshotCollection m_Snapshots;

        public SnapshotCollection Snapshots{ get{ return m_Snapshots; } set{ m_Snapshots = value; } }

        public SnapshotHistory()
        {
            m_Snapshots = new SnapshotCollection();
        }

        public void Save()
        {
            string path = Path.Combine( Core.BaseDirectory, "reportHistory.xml" );
            PersistanceWriter pw = new XmlPersistanceWriter( path, "Stats" );

            pw.WriteDocument( this );

            pw.Close();
        }

        public void Load()
        {
            string path = Path.Combine( Core.BaseDirectory, "reportHistory.xml" );

            if ( !File.Exists( path ) )
                return;

            PersistanceReader pr = new XmlPersistanceReader( path, "Stats" );

            pr.ReadDocument( this );

            pr.Close();
        }

        public override void SerializeChildren( PersistanceWriter op )
        {
            for ( int i = 0; i < m_Snapshots.Count; ++i )
                m_Snapshots[i].Serialize( op );
        }

        public override void DeserializeChildren( PersistanceReader ip )
        {
            while ( ip.HasChild )
                m_Snapshots.Add( ip.GetChild() as Snapshot );
        }
    }
}
