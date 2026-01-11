/* ***************************************************************************
 * PersistableObject.cs
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

namespace Server.Engines.Reports
{
	public abstract class PersistableObject
	{
		public abstract PersistableType TypeID{ get; }

		public virtual void SerializeAttributes( PersistanceWriter op )
		{
		}

		public virtual void SerializeChildren( PersistanceWriter op )
		{
		}

		public void Serialize( PersistanceWriter op )
		{
			op.BeginObject( this.TypeID );
			SerializeAttributes( op );
			op.BeginChildren();
			SerializeChildren( op );
			op.FinishChildren();
			op.FinishObject();
		}

		public virtual void DeserializeAttributes( PersistanceReader ip )
		{
		}

		public virtual void DeserializeChildren( PersistanceReader ip )
		{
		}

		public void Deserialize( PersistanceReader ip )
		{
			DeserializeAttributes( ip );

			if ( ip.BeginChildren() )
			{
				DeserializeChildren( ip );
				ip.FinishChildren();
			}
		}

		public PersistableObject()
		{
		}
	}
}
