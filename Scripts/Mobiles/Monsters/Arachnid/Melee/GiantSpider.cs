/* ***************************************************************************
 * GiantSpider.cs
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
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
    [CorpseName( "a giant spider corpse" )]
    public class GiantSpider : BaseCreature
    {
        [Constructable]
        public GiantSpider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a giant spider";
            Body = 28;
            BaseSoundID = 0x388;

            SetStr( 76, 100 );
            SetDex( 76, 95 );
            SetInt( 36, 60 );

            SetHits( 46, 60 );
            SetMana( 0 );

            SetDamage( 5, 13 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 15, 20 );
            SetResistance( ResistanceType.Poison, 25, 35 );

            SetSkill( SkillName.Poisoning, 60.1, 80.0 );
            SetSkill( SkillName.MagicResist, 25.1, 40.0 );
            SetSkill( SkillName.Tactics, 35.1, 50.0 );
            SetSkill( SkillName.Wrestling, 50.1, 65.0 );

            Fame = 600;
            Karma = -600;

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 59.1;

            PackItem( new SpidersSilk( 5 ) );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
        }

        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
        public override Poison PoisonImmune{ get{ return Poison.Regular; } }
        public override Poison HitPoison{ get{ return Poison.Regular; } }

        public GiantSpider( Serial serial ) : base( serial )
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
