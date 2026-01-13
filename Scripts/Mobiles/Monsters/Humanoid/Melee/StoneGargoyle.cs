/* ***************************************************************************
 * StoneGargoyle.cs
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
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName( "a gargoyle corpse" )]
    public class StoneGargoyle : BaseCreature
    {
        [Constructable]
        public StoneGargoyle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a stone gargoyle";
            Body = 67;
            BaseSoundID = 0x174;

            SetStr( 246, 275 );
            SetDex( 76, 95 );
            SetInt( 81, 105 );

            SetHits( 148, 165 );

            SetDamage( 11, 17 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 45, 55 );
            SetResistance( ResistanceType.Fire, 20, 30 );
            SetResistance( ResistanceType.Cold, 10, 20 );
            SetResistance( ResistanceType.Poison, 30, 40 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.MagicResist, 85.1, 100.0 );
            SetSkill( SkillName.Tactics, 80.1, 100.0 );
            SetSkill( SkillName.Wrestling, 60.1, 100.0 );

            Fame = 4000;
            Karma = -4000;

            VirtualArmor = 50;

            PackItem( new IronIngot( 12 ) );

            if ( 0.05 > Utility.RandomDouble() )
                PackItem( new GargoylesPickaxe() );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average, 2 );
            AddLoot( LootPack.Gems, 1 );
            AddLoot( LootPack.Potions );
        }

        public override int TreasureMapLevel{ get{ return 2; } }

        public StoneGargoyle( Serial serial ) : base( serial )
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
