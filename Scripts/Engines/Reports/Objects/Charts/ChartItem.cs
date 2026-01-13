/* ***************************************************************************
 * ChartItem.cs
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
    public class ChartItem : PersistableObject
    {
        #region Type Identification
        public static readonly PersistableType ThisTypeID = new PersistableType( "ci", new ConstructCallback( Construct ) );

        private static PersistableObject Construct()
        {
            return new ChartItem();
        }

        public override PersistableType TypeID{ get{ return ThisTypeID; } }
        #endregion

        private string m_Name;
        private int m_Value;

        public string Name{ get{ return m_Name; } set{ m_Name = value; } }
        public int Value{ get{ return m_Value; } set{ m_Value = value; } }

        private ChartItem()
        {
        }

        public ChartItem( string name, int value )
        {
            m_Name = name;
            m_Value = value;
        }

        public override void SerializeAttributes( PersistanceWriter op )
        {
            op.SetString( "n", m_Name );
            op.SetInt32( "v", m_Value );
        }

        public override void DeserializeAttributes( PersistanceReader ip )
        {
            m_Name = Utility.Intern( ip.GetString( "n" ) );
            m_Value = ip.GetInt32( "v" );
        }
    }
}
