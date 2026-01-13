/* ***************************************************************************
 * Treefellow.cs
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
    [CorpseName( "a treefellow corpse" )]
    public class Treefellow : BaseCreature
    {
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.Dismount;
        }

        [Constructable]
        public Treefellow() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4 )
        {
            Name = "a treefellow";
            Body = 301;

            SetStr( 196, 220 );
            SetDex( 31, 55 );
            SetInt( 66, 90 );

            SetHits( 118, 132 );

            SetDamage( 12, 16 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 20, 25 );
            SetResistance( ResistanceType.Cold, 50, 60 );
            SetResistance( ResistanceType.Poison, 30, 35 );
            SetResistance( ResistanceType.Energy, 20, 30 );

            SetSkill( SkillName.MagicResist, 40.1, 55.0 );
            SetSkill( SkillName.Tactics, 65.1, 90.0 );
            SetSkill( SkillName.Wrestling, 65.1, 85.0 );

            Fame = 500;
            Karma = 1500;

            VirtualArmor = 24;
            PackItem( new Log( Utility.RandomMinMax( 23, 34 ) ) );
        }

        public override OppositionGroup OppositionGroup
        {
            get{ return OppositionGroup.FeyAndUndead; }
        }

        public override int GetIdleSound()
        {
            return 443;
        }

        public override int GetDeathSound()
        {
            return 31;
        }

        public override int GetAttackSound()
        {
            return 672;
        }

        public override bool BleedImmune{ get{ return true; } }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average );
        }

        public Treefellow( Serial serial ) : base( serial )
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

            if ( BaseSoundID == 442 )
                BaseSoundID = -1;
        }
    }
}
