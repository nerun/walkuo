/* ***************************************************************************
 * Winter2004.cs
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

namespace Server.Misc
{
	public class WinterGiftGiver2004 : GiftGiver
	{
		public static void Initialize()
		{
			GiftGiving.Register( new WinterGiftGiver2004() );
		}

		public override DateTime Start{ get{ return new DateTime( 2004, 12, 24 ); } }
		public override DateTime Finish{ get{ return new DateTime( 2005, 1, 1 ); } }

		public override void GiveGift( Mobile mob )
		{
			GiftBox box = new GiftBox();

			box.DropItem( new MistletoeDeed() );
			box.DropItem( new PileOfGlacialSnow() );
			box.DropItem( new LightOfTheWinterSolstice() );

			int random = Utility.Random( 100 );

			if ( random < 60 )
				box.DropItem( new DecorativeTopiary() );
			else if ( random < 84 )
				box.DropItem( new FestiveCactus() );
			else
				box.DropItem( new SnowyTree() );

			switch ( GiveGift( mob, box ) )
			{
				case GiftResult.Backpack:
					mob.SendMessage( 0x482, "Happy Holidays from the team!  Gift items have been placed in your backpack." );
					break;
				case GiftResult.BankBox:
					mob.SendMessage( 0x482, "Happy Holidays from the team!  Gift items have been placed in your bank box." );
					break;
			}
		}
	}
}
