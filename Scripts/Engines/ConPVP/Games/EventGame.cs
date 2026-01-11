/* ***************************************************************************
 * EventGame.cs
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
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.ConPVP
{
	public abstract class EventController : Item
	{
		public abstract EventGame Construct( DuelContext dc );

		public abstract string Title { get; }

		public abstract string GetTeamName( int teamID );

		public EventController()
			: base( 0x1B7A )
		{
			Visible = false;
			Movable = false;
		}

		public EventController( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel >= AccessLevel.GameMaster )
				from.SendGump( new Gumps.PropertiesGump( from, this ) );
		}
	}

	public abstract class EventGame
	{
		protected DuelContext m_Context;

		public DuelContext Context { get { return m_Context; } }

		public virtual bool FreeConsume { get { return true; } }

		public EventGame( DuelContext context )
		{
			m_Context = context;
		}

		public virtual bool OnDeath( Mobile mob, Container corpse )
		{
			return true;
		}

		public virtual bool CantDoAnything( Mobile mob )
		{
			return false;
		}

		public virtual void OnStart()
		{
		}

		public virtual void OnStop()
		{
		}
	}
}
