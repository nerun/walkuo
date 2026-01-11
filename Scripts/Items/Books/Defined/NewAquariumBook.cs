/* ***************************************************************************
 * NewAquariumBook.cs
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

namespace Server.Items
{
	public class NewAquariumBook : BlueBook
	{
		public static readonly BookContent Content = new BookContent
			(
				"Your New Aquarium", "Les Bilgewater",
				new BookPageInfo
				(
					"Welcome to the",
					"wonderful world",
					"of aquarium ownership.",
					"With a little time and",
					"skill your aquarium can",
					"become a work of art!"
				),
				new BookPageInfo
				(
					"Catching Fish:",
					"You will need to",
					"aquire a fishing net,",
					"and a number of fish",
					"bowls, from your local",
					"fisherman.",
					"To use the net,",
					"select it from your"
				),
				new BookPageInfo
				(
					"backpack, and cast it",
					"into shallow water.",
					"Then we wait.",
					"  The fish will be so",
					"happy to be in your",
					"aquarium, they will",
					"jump right into your",
					"fish bowl when caught!"
				),
				new BookPageInfo
				(
					"Just take them home",
					"and pour them into",
					"your aquarium, and",
					"BING! You have a happy",
					"new addition to your",
					"collection!"
				),
				new BookPageInfo
				(
					"Caring for our",
					"Underwater Allies:",
					"",
					"  Fish need clean",
					"water and food to",
					"survive.",
					"  Our aquarium comes",
					"with a status monitoring"
				),
				new BookPageInfo
				(
					"aid.  Must be Magic!",
					"  Just look at the",
					"front of your aquarium",
					"(mouse over). See the",
					"helpful and friendly",
					"guide? It tells how much",
					"food and water is",
					"needed to maintain,"
				),
				new BookPageInfo
				(
					"and improve the quality",
					"of your tank.",
					"  You dont want to",
					"overfeed your fish",
					"very often.  In fact,",
					"you only want to feed",
					"them every other day.",
					"But, remember to keep"
				),
				new BookPageInfo
				(
					"the water strong and",
					"healthy, and add more",
					"on a regular basis",
					"to keep your aquarium",
					"a pretty, sparkely blue.",
					"",
					"  Well, I hope you",
					"get as much enjoyment,"
				),
				new BookPageInfo
				(
					"collecting a beautiful",
					"array of our fine, finned,",
					"friends from the sea,",
					"as I do!",
					"",
					"Happy Fishing!"
				)
			);

		public override BookContent DefaultContent{ get{ return Content; } }

		[Constructable]
		public NewAquariumBook() : base( false )
		{
			Hue = 0;
		}

		public NewAquariumBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
