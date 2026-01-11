/* ***************************************************************************
 * TeachEntry.cs
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
using Server.Mobiles;

namespace Server.ContextMenus
{
	public class TeachEntry : ContextMenuEntry
	{
		private SkillName m_Skill;
		private BaseCreature m_Mobile;
		private Mobile m_From;

		public TeachEntry( SkillName skill, BaseCreature m, Mobile from, bool enabled ) : base( 6000 + (int)skill )
		{
			m_Skill = skill;
			m_Mobile = m;
			m_From = from;

			if ( !enabled )
				Flags |= Network.CMEFlags.Disabled;
		}

		public override void OnClick()
		{
			if ( !m_From.CheckAlive() )
				return;

			m_Mobile.Teach( m_Skill, m_From, 0, false );
		}
	}
}
