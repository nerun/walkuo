/* ***************************************************************************
 * CraftItemCol.cs
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
    public class CraftItemCol : System.Collections.CollectionBase
    {
        public CraftItemCol()
        {
        }

        public int Add( CraftItem craftItem )
        {
            return List.Add( craftItem );
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

        public CraftItem GetAt( int index )
        {
            return ( CraftItem ) List[index];
        }

        public CraftItem SearchForSubclass( Type type )
        {
            for ( int i = 0; i < List.Count; i++ )
            {
                CraftItem craftItem = ( CraftItem )List[i];

                if ( craftItem.ItemType == type || type.IsSubclassOf( craftItem.ItemType ) )
                    return craftItem;
            }

            return null;
        }

        public CraftItem SearchFor( Type type )
        {
            for ( int i = 0; i < List.Count; i++ )
            {
                CraftItem craftItem = ( CraftItem )List[i];
                if ( craftItem.ItemType == type )
                {
                    return craftItem;
                }
            }
            return null;
        }
    }
}
