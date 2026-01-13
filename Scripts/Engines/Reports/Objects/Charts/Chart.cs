/* ***************************************************************************
 * Chart.cs
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
    public abstract class Chart : PersistableObject
    {
        protected string m_Name;
        protected string m_FileName;
        protected ChartItemCollection m_Items;

        public string Name{ get{ return m_Name; } set{ m_Name = value; } }
        public string FileName{ get{ return m_FileName; } set{ m_FileName = value; } }
        public ChartItemCollection Items{ get{ return m_Items; } }

        public Chart()
        {
            m_Items = new ChartItemCollection();
        }

        public override void SerializeAttributes( PersistanceWriter op )
        {
            op.SetString( "n", m_Name );
            op.SetString( "f", m_FileName );
        }

        public override void DeserializeAttributes( PersistanceReader ip )
        {
            m_Name = Utility.Intern( ip.GetString( "n" ) );
            m_FileName = Utility.Intern( ip.GetString( "f" ) );
        }

        public override void SerializeChildren( PersistanceWriter op )
        {
            for ( int i = 0; i < m_Items.Count; ++i )
                m_Items[i].Serialize( op );
        }

        public override void DeserializeChildren( PersistanceReader ip )
        {
            while ( ip.HasChild )
                m_Items.Add( ip.GetChild() as ChartItem );
        }
    }
}
