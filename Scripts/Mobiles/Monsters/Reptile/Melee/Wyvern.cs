/* ***************************************************************************
 * Wyvern.cs
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

namespace Server.Mobiles
{
    [CorpseName( "a wyvern corpse" )]
    public class Wyvern : BaseCreature
    {
        [Constructable]
        public Wyvern () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a wyvern";
            Body = 62;
            BaseSoundID = 362;

            SetStr( 202, 240 );
            SetDex( 153, 172 );
            SetInt( 51, 90 );

            SetHits( 125, 141 );

            SetDamage( 8, 19 );

            SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType( ResistanceType.Poison, 50 );

            SetResistance( ResistanceType.Physical, 35, 45 );
            SetResistance( ResistanceType.Fire, 30, 40 );
            SetResistance( ResistanceType.Cold, 20, 30 );
            SetResistance( ResistanceType.Poison, 90, 100 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.Poisoning, 60.1, 80.0 );
            SetSkill( SkillName.MagicResist, 65.1, 80.0 );
            SetSkill( SkillName.Tactics, 65.1, 90.0 );
            SetSkill( SkillName.Wrestling, 65.1, 80.0 );

            Fame = 4000;
            Karma = -4000;

            VirtualArmor = 40;

            PackItem( new LesserPoisonPotion() );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average );
            AddLoot( LootPack.Meager );
            AddLoot( LootPack.MedScrolls );
        }

        public override bool ReacquireOnMovement{ get{ return true; } }

        public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
        public override Poison HitPoison{ get{ return Poison.Deadly; } }
        public override int TreasureMapLevel{ get{ return 2; } }

        public override int Meat{ get{ return 10; } }
        public override int Hides{ get{ return 20; } }
        public override HideType HideType{ get{ return HideType.Horned; } }
        public override bool CanFly { get { return true; } }

        public override int GetAttackSound()
        {
            return 713;
        }

        public override int GetAngerSound()
        {
            return 718;
        }

        public override int GetDeathSound()
        {
            return 716;
        }

        public override int GetHurtSound()
        {
            return 721;
        }

        public override int GetIdleSound()
        {
            return 725;
        }

        public Wyvern( Serial serial ) : base( serial )
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
