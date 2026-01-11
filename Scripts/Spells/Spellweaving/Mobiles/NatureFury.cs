/* ***************************************************************************
 * NatureFury.cs
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
using Server.Misc;

namespace Server.Mobiles
{
	public class NatureFury : BaseCreature
	{
		public override bool DeleteCorpseOnDeath { get { return Core.AOS; } }
		public override bool IsHouseSummonable { get { return true; } }

		public override double DispelDifficulty { get { return 125.0; } }
		public override double DispelFocus { get { return 90.0; } }

		public override bool BleedImmune { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override bool AlwaysMurderer { get { return true; } }

		[Constructable]
		public NatureFury()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a nature's fury";
			Body = 0x33;
			Hue = 0x4001;

			SetStr( 150 );
			SetDex( 150 );
			SetInt( 100 );

			SetHits( 80 );
			SetStam( 250 );
			SetMana( 0 );

			SetDamage( 6, 8 );

			SetDamageType( ResistanceType.Poison, 100 );
			SetDamageType( ResistanceType.Physical, 0 );
			SetResistance( ResistanceType.Physical, 90 );

			SetSkill( SkillName.Wrestling, 90.0 );
			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 100.0 );

			Fame = 0;
			Karma = 0;

			ControlSlots = 1;
		}

		public override void MoveToWorld( Point3D loc, Map map )
		{
			base.MoveToWorld( loc, map );
			Timer.DelayCall( TimeSpan.Zero, DoEffects );
		}

		public void DoEffects()
		{
			FixedParticles( 0x91C, 10, 180, 0x2543, 0, 0, EffectLayer.Waist );
			PlaySound( 0xE );
			PlaySound( 0x1BC );

			if( Alive && !Deleted )
				Timer.DelayCall( TimeSpan.FromSeconds( 7.0 ), DoEffects );
		}

		public NatureFury( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Delete();
		}
	}
}
