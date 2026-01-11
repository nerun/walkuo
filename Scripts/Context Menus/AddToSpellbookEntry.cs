/* ***************************************************************************
 * AddToSpellbookEntry.cs
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
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.ContextMenus
{
	public class AddToSpellbookEntry : ContextMenuEntry
	{
		public AddToSpellbookEntry() : base( 6144, 3 )
		{
		}

		public override void OnClick()
		{
			if ( Owner.From.CheckAlive() && Owner.Target is SpellScroll )
				Owner.From.Target = new InternalTarget( (SpellScroll)Owner.Target );
		}

		private class InternalTarget : Target
		{
			private SpellScroll m_Scroll;

			public InternalTarget( SpellScroll scroll ) : base( 3, false, TargetFlags.None )
			{
				m_Scroll = scroll;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Spellbook )
				{
					if ( from.CheckAlive() && !m_Scroll.Deleted && m_Scroll.Movable && m_Scroll.Amount >= 1 && m_Scroll.CheckItemUse( from ) )
					{
						Spellbook book = (Spellbook)targeted;

						SpellbookType type = Spellbook.GetTypeForSpell( m_Scroll.SpellID );

						if ( type != book.SpellbookType )
						{
						}
						else if ( book.HasSpell( m_Scroll.SpellID ) )
						{
							from.SendLocalizedMessage( 500179 ); // That spell is already present in that spellbook.
						}
						else
						{
							int val = m_Scroll.SpellID - book.BookOffset;

							if ( val >= 0 && val < book.BookCount )
							{
								book.Content |= (ulong)1 << val;

								m_Scroll.Consume();

								from.Send( new Network.PlaySound( 0x249, book.GetWorldLocation() ) );
							}
						}
					}
				}
			}
		}
	}
}
