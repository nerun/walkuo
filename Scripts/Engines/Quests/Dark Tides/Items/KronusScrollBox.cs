/* ***************************************************************************
 * KronusScrollBox.cs
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
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Necro
{
	public class KronusScrollBox : MetalBox
	{
		[Constructable]
		public KronusScrollBox()
		{
			ItemID = 0xE80;
			Movable = false;

			for ( int i = 0; i < 40; i++ )
			{
				Item scroll = Loot.RandomScroll( 0, 15, SpellbookType.Necromancer );
				scroll.Movable = false;
				DropItem( scroll );
			}
		}

		public KronusScrollBox( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.InRange( GetWorldLocation(), 2 ) )
			{
				QuestSystem qs = pm.Quest;

				if ( qs is DarkTidesQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( FindCallingScrollObjective ) );

					if ( (obj != null && !obj.Completed) || DarkTidesQuest.HasLostCallingScroll( from ) )
					{
						Item scroll = new KronusScroll();

						if ( pm.PlaceInBackpack( scroll ) )
						{
							pm.SendLocalizedMessage( 1060120, "", 0x41 ); // You rummage through the scrolls until you find the Scroll of Calling.  You quickly put it in your pack.

							if ( obj != null && !obj.Completed )
								obj.Complete();
						}
						else
						{
							pm.SendLocalizedMessage( 1060148, "", 0x41 ); // You were unable to take the scroll.
							scroll.Delete();
						}
					}
				}
			}

			base.OnDoubleClick( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
