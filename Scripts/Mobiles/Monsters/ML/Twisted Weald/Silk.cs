/* ***************************************************************************
 * Silk.cs
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
	[CorpseName( "a Silk corpse" )]
	public class Silk : GiantBlackWidow
	{
		[Constructable]
		public Silk()
		{
			IsParagon = true;

			Name = "Silk";
			Hue = 0x47E;

			SetStr( 80, 131 );
			SetDex( 126, 156 );
			SetInt( 63, 102 );

			SetHits( 279, 378 );
			SetStam( 126, 156 );
			SetMana( 63, 102 );

			SetDamage( 15, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 30, 39 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 70, 76 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Wrestling, 114.1, 123.7 );
			SetSkill( SkillName.Tactics, 102.6, 118.3 );
			SetSkill( SkillName.MagicResist, 78.6, 94.8 );
			SetSkill( SkillName.Anatomy, 81.3, 105.7 );
			SetSkill( SkillName.Poisoning, 106.0, 119.2 );

			Fame = 18900;
			Karma = -18900;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		public override bool GivesMLMinorArtifact{ get{ return true; } }

		public Silk( Serial serial )
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
