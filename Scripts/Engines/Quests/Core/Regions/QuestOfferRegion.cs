/* ***************************************************************************
 * QuestOfferRegion.cs
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
using System.Xml;
using Server;
using Server.Regions;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class QuestOfferRegion : BaseRegion
	{
		private Type m_Quest;

		public Type Quest{ get{ return m_Quest ; } }

		public QuestOfferRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			ReadType( xml["quest"], "type", ref m_Quest );
		}

		public override void OnEnter( Mobile m )
		{
			base.OnEnter( m );

			if ( m_Quest == null )
				return;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null && player.Quest == null && QuestSystem.CanOfferQuest( m, m_Quest ) )
			{
				try
				{
					QuestSystem qs = (QuestSystem) Activator.CreateInstance( m_Quest, new object[] { player } );
					qs.SendOffer();
				}
				catch ( Exception ex )
				{
					Console.WriteLine( "Error creating quest {0}: {1}", m_Quest, ex );
				}
			}
		}
	}
}
