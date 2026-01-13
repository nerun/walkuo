/* ***************************************************************************
 * WandererOfTheVoid.cs
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
    [CorpseName( "a wanderer of the void corpse" )]
    public class WandererOfTheVoid : BaseCreature
    {
        [Constructable]
        public WandererOfTheVoid() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a wanderer of the void";
            Body = 316;
            BaseSoundID = 377;

            SetStr( 111, 200 );
            SetDex( 101, 125 );
            SetInt( 301, 390 );

            SetHits( 351, 400 );

            SetDamage( 11, 13 );

            SetDamageType( ResistanceType.Physical, 0 );
            SetDamageType( ResistanceType.Cold, 15 );
            SetDamageType( ResistanceType.Energy, 85 );

            SetResistance( ResistanceType.Physical, 40, 50 );
            SetResistance( ResistanceType.Fire, 15, 25 );
            SetResistance( ResistanceType.Cold, 40, 50 );
            SetResistance( ResistanceType.Poison, 50, 75 );
            SetResistance( ResistanceType.Energy, 40, 50 );

            SetSkill( SkillName.EvalInt, 60.1, 70.0 );
            SetSkill( SkillName.Magery, 60.1, 70.0 );
            SetSkill( SkillName.Meditation, 60.1, 70.0 );
            SetSkill( SkillName.MagicResist, 50.1, 75.0 );
            SetSkill( SkillName.Tactics, 60.1, 70.0 );
            SetSkill( SkillName.Wrestling, 60.1, 70.0 );

            Fame = 20000;
            Karma = -20000;

            VirtualArmor = 44;

            int count = Utility.RandomMinMax( 2, 3 );

            for ( int i = 0; i < count; ++i )
                PackItem( new TreasureMap( 3, Map.Trammel ) );
        }

        public override bool BleedImmune{ get{ return true; } }
        public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 1; } }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.FilthyRich );
        }

        public WandererOfTheVoid( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
