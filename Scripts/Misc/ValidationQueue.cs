/* ***************************************************************************
 * ValidationQueue.cs
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
using System.Collections.Generic;
using System.Reflection;
using Server;

namespace Server
{
	public delegate void ValidationEventHandler();

	public static class ValidationQueue
	{
		public static event ValidationEventHandler StartValidation;

		public static void Initialize()
		{
			if ( StartValidation != null )
				StartValidation();

			StartValidation = null;
		}
	}

	public static class ValidationQueue<T>
	{
		private static List<T> m_Queue;

		static ValidationQueue()
		{
			m_Queue = new List<T>();
			ValidationQueue.StartValidation += new ValidationEventHandler( ValidateAll );
		}

		public static void Add( T obj )
		{
			m_Queue.Add( obj );
		}

		private static void ValidateAll()
		{
			Type type = typeof( T );

			if ( type != null )
			{
				MethodInfo m = type.GetMethod( "Validate", BindingFlags.Instance | BindingFlags.Public );

				if ( m != null )
				{
					for ( int i = 0; i < m_Queue.Count; ++i )
						m.Invoke( m_Queue[i], null );
				}
			}

			m_Queue.Clear();
			m_Queue = null;
		}
	}
}
