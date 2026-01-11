/* ***************************************************************************
 * IEntity.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C) 2002  The RunUO Software Team
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

namespace Server
{
	public interface IEntity : IPoint3D, IComparable, IComparable<IEntity>
	{
		string Name { get; set; }
		Serial Serial{ get; }
		Point3D Location{ get; }
		Map Map{ get; }
		bool Deleted { get; }

		void Delete();
		void ProcessDelta();
		void InvalidateProperties();
	}

	public class Entity : IEntity, IComparable<Entity>
	{
		public int CompareTo( IEntity other )
		{
			if ( other == null )
				return -1;

			return m_Serial.CompareTo( other.Serial );
		}

		public int CompareTo( Entity other )
		{
			return this.CompareTo( (IEntity) other );
		}

		public int CompareTo( object other )
		{
			if ( other == null || other is IEntity )
				return this.CompareTo( (IEntity) other );

			throw new ArgumentException();
		}

		private string m_Name;
		private Serial m_Serial;
		private Point3D m_Location;
		private Map m_Map;
		private bool m_Deleted;

		public Entity( Serial serial, Point3D loc, Map map )
		{
			m_Name = null;
			m_Serial = serial;
			m_Location = loc;
			m_Map = map;
			m_Deleted = false;
		}

		public string Name {
			get {
				return m_Name;
			}
			set {
				m_Name = value;
			}
		}

		public Serial Serial {
			get {
				return m_Serial;
			}
		}

		public Point3D Location {
			get {
				return m_Location;
			}
		}

		public int X {
			get {
				return m_Location.X;
			}
		}

		public int Y {
			get {
				return m_Location.Y;
			}
		}

		public int Z {
			get {
				return m_Location.Z;
			}
		}

		public Map Map {
			get {
				return m_Map;
			}
		}

		public bool Deleted {
			get {
				return m_Deleted;
			}
		}

		public void Delete()
		{
			m_Deleted = true;
		}

		public void ProcessDelta()
		{
		}

		public void InvalidateProperties()
		{
		}
	}
}
