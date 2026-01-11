/* ***************************************************************************
 * MantraEffervescence.cs
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

namespace Server.Mobiles
{
	[CorpseName( "a mantra effervescence corpse" )]
	public class MantraEffervescence : BaseCreature
	{
		[Constructable]
		public MantraEffervescence()
			: base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mantra effervescence";
			Body = 0x111;
			BaseSoundID = 0x56E;

			SetStr( 130, 150 );
			SetDex( 120, 130 );
			SetInt( 150, 230 );

			SetHits( 150, 250 );

			SetDamage( 21, 25 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Energy, 70 );

			SetResistance( ResistanceType.Physical, 60, 65 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.Wrestling, 80.0, 85.0 );
			SetSkill( SkillName.Tactics, 80.0, 85.0 );
			SetSkill( SkillName.MagicResist, 105.0, 115.0 );
			SetSkill( SkillName.Magery, 90.0, 110.0 );
			SetSkill( SkillName.EvalInt, 80.0, 90.0 );
			SetSkill( SkillName.Meditation, 90.0, 100.0 );

			Fame = 6500;
			Karma = -6500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
		}

		public MantraEffervescence( Serial serial )
			: base( serial )
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
