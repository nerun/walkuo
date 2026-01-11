/* ***************************************************************************
 * HonorCandle.cs
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

namespace Server.Engines.Quests.Samurai
{
	public class HonorCandle : CandleLong
	{
		private static readonly TimeSpan LitDuration = TimeSpan.FromSeconds( 20.0 );

		public override int LitSound{ get{ return 0; } }
		public override int UnlitSound{ get{ return 0; } }

		[Constructable]
		public HonorCandle()
		{
			Movable = false;
			Duration = LitDuration;
		}

		public HonorCandle( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			bool wasBurning = Burning;

			base.OnDoubleClick( from );

			if ( !wasBurning && Burning )
			{
				PlayerMobile player = from as PlayerMobile;

				if ( player == null )
					return;

				QuestSystem qs = player.Quest;

				if ( qs != null && qs is HaochisTrialsQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( SixthTrialIntroObjective ) );

					if ( obj != null && !obj.Completed )
						obj.Complete();

					this.SendLocalizedMessageTo( from, 1063251 ); // You light a candle in honor.
				}
			}
		}

		public override void Burn()
		{
			Douse();
		}

		public override void Douse()
		{
			base.Douse();

			Duration = LitDuration;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
