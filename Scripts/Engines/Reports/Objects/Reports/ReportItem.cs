/* ***************************************************************************
 * ReportItem.cs
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
    public class ReportItem : PersistableObject
    {
        #region Type Identification
        public static readonly PersistableType ThisTypeID = new PersistableType( "ri", new ConstructCallback( Construct ) );

        private static PersistableObject Construct()
        {
            return new ReportItem();
        }

        public override PersistableType TypeID{ get{ return ThisTypeID; } }
        #endregion

        private ItemValueCollection m_Values;

        public ItemValueCollection Values{ get{ return m_Values; } }

        public ReportItem()
        {
            m_Values = new ItemValueCollection();
        }

        public override void SerializeChildren( PersistanceWriter op )
        {
            for ( int i = 0; i < m_Values.Count; ++i )
                m_Values[i].Serialize( op );
        }

        public override void DeserializeChildren( PersistanceReader ip )
        {
            while ( ip.HasChild )
                m_Values.Add( ip.GetChild() as ItemValue );
        }
    }
}
