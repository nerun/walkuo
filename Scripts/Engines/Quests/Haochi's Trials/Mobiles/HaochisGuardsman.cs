/* ***************************************************************************
 * HaochisGuardsman.cs
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
using Server.Mobiles;
using Server.Gumps;
using Server.Items;

namespace Server.Engines.Quests.Samurai
{
	public class HaochisGuardsman : BaseQuester
	{
		[Constructable]
		public HaochisGuardsman() : base( "the Guardsman of Daimyo Haochi" )
		{
		}

		public override void InitBody()
		{
			InitStats( 100, 100, 25 );

			Hue = Race.Human.RandomSkinHue();

			Female = false;
			Body = 0x190;
			Name = NameList.RandomName( "male" );
		}

		public override void InitOutfit()
		{
			Utility.AssignRandomHair( this );

			AddItem( new LeatherDo() );
			AddItem( new LeatherHiroSode() );
			AddItem( new SamuraiTabi( Utility.RandomNondyedHue() ) );

			switch ( Utility.Random( 3 ) )
			{
				case 0: AddItem( new StuddedHaidate() ); break;
				case 1: AddItem( new PlateSuneate() ); break;
				default: AddItem( new LeatherSuneate() ); break;
			}

			switch ( Utility.Random( 4 ) )
			{
				case 0: AddItem( new DecorativePlateKabuto() ); break;
				case 1: AddItem( new ChainHatsuburi() ); break;
				case 2: AddItem( new LightPlateJingasa() ); break;
				default: AddItem( new LeatherJingasa() ); break;
			}

			Item weapon;
			switch ( Utility.Random( 3 ) )
			{
				case 0: weapon = new NoDachi(); break;
				case 1: weapon = new Lajatang(); break;
				default: weapon = new Wakizashi(); break;
			}
			weapon.Movable = false;
			AddItem( weapon );
		}

		public override int TalkNumber{ get	{ return -1; } }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
		}

		public HaochisGuardsman( Serial serial ) : base( serial )
		{
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
