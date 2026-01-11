/* ***************************************************************************
 * CraftGroupCol.cs
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
	public class CraftGroupCol : System.Collections.CollectionBase
	{
		public CraftGroupCol()
		{
		}

		public int Add( CraftGroup craftGroup )
		{
			return List.Add( craftGroup );
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

		public CraftGroup GetAt( int index )
		{
			return ( CraftGroup ) List[index];
		}

		public int SearchFor( TextDefinition groupName )
		{
			for ( int i = 0; i < List.Count; i++ )
			{
				CraftGroup craftGroup = (CraftGroup)List[i];

				int nameNumber = craftGroup.NameNumber;
				string nameString = craftGroup.NameString;

				if ( ( nameNumber != 0 && nameNumber == groupName.Number ) || ( nameString != null && nameString == groupName.String ) )
					return i;
			}

			return -1;
		}
	}
}
