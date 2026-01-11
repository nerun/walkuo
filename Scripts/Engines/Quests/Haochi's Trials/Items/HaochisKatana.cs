/* ***************************************************************************
 * HaochisKatana.cs
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
using Server.Items;

namespace Server.Engines.Quests.Samurai
{
	public class HaochisKatana : QuestItem
	{
		public override int LabelNumber{ get{ return 1063165; } } // Daimyo Haochi's Katana

		[Constructable]
		public HaochisKatana() : base( 0x13FF )
		{
			Weight = 1.0;
		}

		public HaochisKatana( Serial serial ) : base( serial )
		{
		}

		public override bool CanDrop( PlayerMobile player )
		{
			HaochisTrialsQuest qs = player.Quest as HaochisTrialsQuest;

			if ( qs == null )
				return true;

			//return !qs.IsObjectiveInProgress( typeof( FifthTrialReturnObjective ) );
			return false;
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
