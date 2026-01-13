/* ***************************************************************************
 * BrownBear.cs
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
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "a bear corpse" )]
    public class BrownBear : BaseCreature
    {
        [Constructable]
        public BrownBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a brown bear";
            Body = 167;
            BaseSoundID = 0xA3;

            SetStr( 76, 100 );
            SetDex( 26, 45 );
            SetInt( 23, 47 );

            SetHits( 46, 60 );
            SetMana( 0 );

            SetDamage( 6, 12 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 20, 30 );
            SetResistance( ResistanceType.Cold, 15, 20 );
            SetResistance( ResistanceType.Poison, 10, 15 );

            SetSkill( SkillName.MagicResist, 25.1, 35.0 );
            SetSkill( SkillName.Tactics, 40.1, 60.0 );
            SetSkill( SkillName.Wrestling, 40.1, 60.0 );

            Fame = 450;
            Karma = 0;

            VirtualArmor = 24;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 41.1;
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 12; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

        public BrownBear( Serial serial ) : base( serial )
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
