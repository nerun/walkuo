/* ***************************************************************************
 * LostItems.cs
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
using Server.Engines.MLQuests;
using Server.Engines.MLQuests.Items;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;

namespace Server.Engines.MLQuests.Definitions
{
	// TODO: Assassination Contract, Evidence, Lost in Transit, Last Words

	#region Quests

	public class LostAndFound : MLQuest
	{
		public LostAndFound()
		{
			Activated = true;
			Title = 1072370; // Lost and Found
			Description = 1072589; // The battered, old bucket is inscribed with barely legible writing that indicates it belongs to someone named "Dallid".  Maybe they'd pay for its return?
			RefusalMessage = 1072590; // You're right, who cares if Dallid might pay for his battered old bucket back.  This way you can carry it around with you!
			InProgressMessage = 1072591; // Whoever this "Dallid" might be, he's probably looking for his bucket.
			CompletionMessage = 1074580; // Is that my bucket? I had to ditch my favorite bucket when a group of ratmen jumped me!

			Objectives.Add( new TimedDeliverObjective( TimeSpan.FromSeconds( 600 ), typeof( BatteredBucket ), 1, "battered bucket", typeof( Dallid ), false ) );

			Rewards.Add( ItemReward.BagOfTrinkets );
		}
	}

	#endregion

	#region Items

	public class BatteredBucket : TransientQuestGiverItem
	{
		// Original label, doesn't fit the expiration message well
		//public override int LabelNumber { get { return 1073129; } } // A battered bucket.

		public override string DefaultName { get { return "battered bucket"; } }

		[Constructable]
		public BatteredBucket()
			: base( 0x2004, TimeSpan.FromMinutes( 10 ) )
		{
			LootType = LootType.Blessed;
		}

		public BatteredBucket( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	#endregion
}
