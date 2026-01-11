/* ***************************************************************************
 * HolyMage.cs
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
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class HolyMage : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public HolyMage() : base( "the Holy Mage" )
		{
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBHolyMage() );
		}

		public Item ApplyHue( Item item, int hue )
		{
			item.Hue = hue;

			return item;
		}

		public override void InitOutfit()
		{
			AddItem( ApplyHue( new Robe(), 0x47E ) );
			AddItem( ApplyHue( new ThighBoots(), 0x47E ) );
			AddItem( ApplyHue( new BlackStaff(), 0x47E ) );

			if ( Female )
			{
				AddItem( ApplyHue( new LeatherGloves(), 0x47E ) );
				AddItem( ApplyHue( new GoldNecklace(), 0x47E ) );
			}
			else
			{
				AddItem( ApplyHue( new PlateGloves(), 0x47E ) );
				AddItem( ApplyHue( new PlateGorget(), 0x47E ) );
			}

			switch ( Utility.Random( Female ? 2 : 1 ) )
			{
				case 0: HairItemID = 0x203C; break;
				case 1: HairItemID = 0x203D; break;
			}

			HairHue = 0x47E;

			PackGold( 100, 200 );
		}

		public HolyMage( Serial serial ) : base( serial )
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
