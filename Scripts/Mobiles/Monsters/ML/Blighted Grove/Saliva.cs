/* ***************************************************************************
 * Saliva.cs
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
	[CorpseName( "a Saliva corpse" )]
	public class Saliva : Harpy
	{
		[Constructable]
		public Saliva()
		{
			// TODO: Not a paragon? No ML arties?
			// It moves like a paragon on OSI...

			Name = "Saliva";
			Hue = 0x11E;

			SetStr( 110, 206 );
			SetDex( 123, 222 );
			SetInt( 80, 127 );

			SetHits( 409, 842 );

			SetDamage( 20, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 46, 48 );
			SetResistance( ResistanceType.Fire, 32, 40 );
			SetResistance( ResistanceType.Cold, 34, 49 );
			SetResistance( ResistanceType.Poison, 40, 48 );
			SetResistance( ResistanceType.Energy, 35, 39 );

			SetSkill( SkillName.Wrestling, 106.4, 128.8 );
			SetSkill( SkillName.Tactics, 129.9, 141.0 );
			SetSkill( SkillName.MagicResist, 84.3, 105.0 );

			// TODO: Fame/Karma?
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			c.DropItem( new SalivasFeather() );

			// TODO: uncomment once added
			//if ( Utility.RandomDouble() < 0.1 )
			//	c.DropItem( new ParrotItem() );
		}

		public Saliva( Serial serial )
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
