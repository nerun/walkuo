/* ***************************************************************************
 * CraftSubResCol.cs
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

namespace Server.Engines.Craft
{
    public class CraftSubResCol : System.Collections.CollectionBase
    {
        private Type m_Type;
        private string m_NameString;
        private int m_NameNumber;
        private bool m_Init;

        public bool Init
        {
            get { return m_Init; }
            set { m_Init = value; }
        }
                
        public Type ResType
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public string NameString
        {
            get { return m_NameString; }
            set { m_NameString = value; }
        }

        public int NameNumber
        {
            get { return m_NameNumber; }
            set { m_NameNumber = value; }
        }

        public CraftSubResCol()
        {
            m_Init = false;
        }

        public void Add( CraftSubRes craftSubRes )
        {
            List.Add( craftSubRes );
        }

        public void Remove( int index )
        {
            if ( index > Count - 1 || index < 0 )
            {
            }
            else
            {
                List.RemoveAt( index );
            }
        }

        public CraftSubRes GetAt( int index )
        {
            return ( CraftSubRes ) List[index];
        }

        public CraftSubRes SearchFor( Type type )
        {
            for ( int i = 0; i < List.Count; i++ )
            {
                CraftSubRes craftSubRes = ( CraftSubRes )List[i];
                if ( craftSubRes.ItemType == type )
                {
                    return craftSubRes;
                }
            }
            return null;
        }
    }
}
