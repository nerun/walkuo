/* ***************************************************************************
 * GuildDeclareWarPrompt.cs
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
using Server;
using Server.Guilds;
using Server.Prompts;
using System.Collections.Generic;

namespace Server.Gumps
{
	public class GuildDeclareWarPrompt : Prompt
	{
		private Mobile m_Mobile;
		private Guild m_Guild;

		public GuildDeclareWarPrompt( Mobile m, Guild g )
		{
			m_Mobile = m;
			m_Guild = g;
		}

		public override void OnCancel( Mobile from )
		{
			if ( GuildGump.BadLeader( m_Mobile, m_Guild ) )
				return;

			GuildGump.EnsureClosed( m_Mobile );
			m_Mobile.SendGump( new GuildWarAdminGump( m_Mobile, m_Guild ) );
		}

		public override void OnResponse( Mobile from, string text )
		{
			if ( GuildGump.BadLeader( m_Mobile, m_Guild ) )
				return;

			text = text.Trim();

			if ( text.Length >= 3 )
			{
				List<Guild> guilds = Utility.CastConvertList<BaseGuild, Guild>( Guild.Search( text ) );

				GuildGump.EnsureClosed( m_Mobile );

				if ( guilds.Count > 0 )
				{
					m_Mobile.SendGump( new GuildDeclareWarGump( m_Mobile, m_Guild, guilds ) );
				}
				else
				{
					m_Mobile.SendGump( new GuildWarAdminGump( m_Mobile, m_Guild ) );
					m_Mobile.SendLocalizedMessage( 1018003 ); // No guilds found matching - try another name in the search
				}
			}
			else
			{
				m_Mobile.SendMessage( "Search string must be at least three letters in length." );
			}
		}
	}
}
