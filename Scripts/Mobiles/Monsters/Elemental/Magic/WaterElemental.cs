/* ***************************************************************************
 * WaterElemental.cs
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
    [CorpseName( "a water elemental corpse" )]
    public class WaterElemental : BaseCreature
    {
        public override double DispelDifficulty{ get{ return 117.5; } }
        public override double DispelFocus{ get{ return 45.0; } }

        [Constructable]
        public WaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a water elemental";
            Body = 16;
            BaseSoundID = 278;

            SetStr( 126, 155 );
            SetDex( 66, 85 );
            SetInt( 101, 125 );

            SetHits( 76, 93 );

            SetDamage( 7, 9 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 35, 45 );
            SetResistance( ResistanceType.Fire, 10, 25 );
            SetResistance( ResistanceType.Cold, 10, 25 );
            SetResistance( ResistanceType.Poison, 60, 70 );
            SetResistance( ResistanceType.Energy, 5, 10 );

            SetSkill( SkillName.EvalInt, 60.1, 75.0 );
            SetSkill( SkillName.Magery, 60.1, 75.0 );
            SetSkill( SkillName.MagicResist, 100.1, 115.0 );
            SetSkill( SkillName.Tactics, 50.1, 70.0 );
            SetSkill( SkillName.Wrestling, 50.1, 70.0 );

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 40;
            ControlSlots = 3;
            CanSwim = true;

            PackItem( new BlackPearl( 3 ) );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average );
            AddLoot( LootPack.Meager );
            AddLoot( LootPack.Potions );
        }

        public override bool BleedImmune{ get{ return true; } }
        public override int TreasureMapLevel{ get{ return 2; } }

        public WaterElemental( Serial serial ) : base( serial )
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
