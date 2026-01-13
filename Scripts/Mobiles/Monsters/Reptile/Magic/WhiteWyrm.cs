/* ***************************************************************************
 * WhiteWyrm.cs
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
    [CorpseName( "a white wyrm corpse" )]
    public class WhiteWyrm : BaseCreature
    {
        [Constructable]
        public WhiteWyrm() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Body = Utility.RandomBool() ? 180 : 49;
            Name = "a white wyrm";
            BaseSoundID = 362;

            SetStr( 721, 760 );
            SetDex( 101, 130 );
            SetInt( 386, 425 );

            SetHits( 433, 456 );

            SetDamage( 17, 25 );

            SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType( ResistanceType.Cold, 50 );

            SetResistance( ResistanceType.Physical, 55, 70 );
            SetResistance( ResistanceType.Fire, 15, 25 );
            SetResistance( ResistanceType.Cold, 80, 90 );
            SetResistance( ResistanceType.Poison, 40, 50 );
            SetResistance( ResistanceType.Energy, 40, 50 );

            SetSkill( SkillName.EvalInt, 99.1, 100.0 );
            SetSkill( SkillName.Magery, 99.1, 100.0 );
            SetSkill( SkillName.MagicResist, 99.1, 100.0 );
            SetSkill( SkillName.Tactics, 97.6, 100.0 );
            SetSkill( SkillName.Wrestling, 90.1, 100.0 );

            Fame = 18000;
            Karma = -18000;

            VirtualArmor = 64;

            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 96.3;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.FilthyRich, 2 );
            AddLoot( LootPack.Average );
            AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
        }

        public override bool ReacquireOnMovement{ get{ return true; } }
        public override int TreasureMapLevel{ get{ return 4; } }
        public override int Meat{ get{ return 19; } }
        public override int Hides{ get{ return 20; } }
        public override HideType HideType{ get{ return HideType.Barbed; } }
        public override int Scales{ get{ return 9; } }
        public override ScaleType ScaleType{ get{ return ScaleType.White; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
        public override bool CanAngerOnTame { get { return true; } }
        public override bool CanFly { get { return true; } }

        public WhiteWyrm( Serial serial ) : base( serial )
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
