/* ***************************************************************************
 * EscortableMage.cs
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
using EDI = Server.Mobiles.EscortDestinationInfo;

namespace Server.Mobiles
{
	public class EscortableMage : BaseEscortable
	{
		[Constructable]
		public EscortableMage()
		{
			Title = "the mage";

			SetSkill( SkillName.EvalInt, 80.0, 100.0 );
			SetSkill( SkillName.Inscribe, 80.0, 100.0 );
			SetSkill( SkillName.Magery, 80.0, 100.0 );
			SetSkill( SkillName.Meditation, 80.0, 100.0 );
			SetSkill( SkillName.MagicResist, 80.0, 100.0 );
		}

		public override bool CanTeach{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } } // Do not display 'the mage' when single-clicking

		private static int GetRandomHue()
		{
			switch ( Utility.Random( 5 ) )
			{
				default:
				case 0: return Utility.RandomBlueHue();
				case 1: return Utility.RandomGreenHue();
				case 2: return Utility.RandomRedHue();
				case 3: return Utility.RandomYellowHue();
				case 4: return Utility.RandomNeutralHue();
			}
		}

		public override void InitOutfit()
		{
			AddItem( new Robe( GetRandomHue() ) );

			int lowHue = GetRandomHue();

			AddItem( new ShortPants( lowHue ) );

			if ( Female )
				AddItem( new ThighBoots( lowHue ) );
			else
				AddItem( new Boots( lowHue ) );

			Utility.AssignRandomHair( this );

			PackGold( 200, 250 );
		}

		public EscortableMage( Serial serial ) : base( serial )
		{
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
