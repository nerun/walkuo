/* ***************************************************************************
 * Spectre.cs
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
    [CorpseName( "a ghostly corpse" )]
    public class Spectre : BaseCreature
    {
        [Constructable]
        public Spectre() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a spectre";
            Body = 26;
            Hue = 0x4001;
            BaseSoundID = 0x482;

            SetStr( 76, 100 );
            SetDex( 76, 95 );
            SetInt( 36, 60 );

            SetHits( 46, 60 );

            SetDamage( 7, 11 );

            SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType( ResistanceType.Cold, 50 );

            SetResistance( ResistanceType.Physical, 25, 30 );
            SetResistance( ResistanceType.Cold, 15, 25 );
            SetResistance( ResistanceType.Poison, 10, 20 );

            SetSkill( SkillName.EvalInt, 55.1, 70.0 );
            SetSkill( SkillName.Magery, 55.1, 70.0 );
            SetSkill( SkillName.MagicResist, 55.1, 70.0 );
            SetSkill( SkillName.Tactics, 45.1, 60.0 );
            SetSkill( SkillName.Wrestling, 45.1, 55.0 );

            Fame = 4000;
            Karma = -4000;

            VirtualArmor = 28;

            PackReg( 10 );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Meager );
        }
        
        public override bool BleedImmune{ get{ return true; } }

        public override OppositionGroup OppositionGroup
        {
            get{ return OppositionGroup.FeyAndUndead; }
        }

        public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

        public Spectre( Serial serial ) : base( serial )
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
