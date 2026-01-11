/* ***************************************************************************
 * SetCustomEnumGump.cs
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
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
	public class SetCustomEnumGump : SetListOptionGump
	{
		private string[] m_Names;

		public SetCustomEnumGump( PropertyInfo prop, Mobile mobile, object o, Stack<StackEntry> stack, int propspage, ArrayList list, string[] names ) : base( prop, mobile, o, stack, propspage, list, names, null )
		{
			m_Names = names;
		}

		public override void OnResponse( NetState sender, RelayInfo relayInfo )
		{
			int index = relayInfo.ButtonID - 1;

			if ( index >= 0 && index < m_Names.Length )
			{
				try
				{
					MethodInfo info = m_Property.PropertyType.GetMethod( "Parse", new Type[]{ typeof( string ) } );

					string result = "";

					if ( info != null )
						result = Properties.SetDirect( m_Mobile, m_Object, m_Object, m_Property, m_Property.Name, info.Invoke( null, new object[] { m_Names[index] } ), true );
					else if ( m_Property.PropertyType == typeof( Enum ) || m_Property.PropertyType.IsSubclassOf( typeof( Enum ) ) )
						result = Properties.SetDirect( m_Mobile, m_Object, m_Object, m_Property, m_Property.Name, Enum.Parse( m_Property.PropertyType, m_Names[index], false ), true );

					m_Mobile.SendMessage( result );

					if ( result == "Property has been set." )
						PropertiesGump.OnValueChanged( m_Object, m_Property, m_Stack );
				}
				catch
				{
					m_Mobile.SendMessage( "An exception was caught. The property may not have changed." );
				}
			}

			m_Mobile.SendGump( new PropertiesGump( m_Mobile, m_Object, m_Stack, m_List, m_Page ) );
		}
	}
}
