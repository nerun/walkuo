/* ***************************************************************************
 * Panther.cs
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
    [CorpseName( "a panther corpse" )]
    public class Panther : BaseCreature
    {
        [Constructable]
        public Panther() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a panther";
            Body = 0xD6;
            Hue = 0x901;
            BaseSoundID = 0x462;

            SetStr( 61, 85 );
            SetDex( 86, 105 );
            SetInt( 26, 50 );

            SetHits( 37, 51 );
            SetMana( 0 );

            SetDamage( 4, 12 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 20, 25 );
            SetResistance( ResistanceType.Fire, 5, 10 );
            SetResistance( ResistanceType.Cold, 10, 15 );
            SetResistance( ResistanceType.Poison, 5, 10 );

            SetSkill( SkillName.MagicResist, 15.1, 30.0 );
            SetSkill( SkillName.Tactics, 50.1, 65.0 );
            SetSkill( SkillName.Wrestling, 50.1, 65.0 );

            Fame = 450;
            Karma = 0;

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 53.1;
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 10; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

        public Panther(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
