/* ***************************************************************************
 * Rat.cs
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
    [CorpseName( "a rat corpse" )]
    public class Rat : BaseCreature
    {
        [Constructable]
        public Rat() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a rat";
            Body = 238;
            BaseSoundID = 0xCC;

            SetStr( 9 );
            SetDex( 35 );
            SetInt( 5 );

            SetHits( 6 );
            SetMana( 0 );

            SetDamage( 1, 2 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 5, 10 );
            SetResistance( ResistanceType.Poison, 5, 10 );

            SetSkill( SkillName.MagicResist, 4.0 );
            SetSkill( SkillName.Tactics, 4.0 );
            SetSkill( SkillName.Wrestling, 4.0 );

            Fame = 150;
            Karma = -150;

            VirtualArmor = 6;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = -0.9;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
        }

        public override int Meat{ get{ return 1; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.GrainsAndHay; } }

        public Rat(Serial serial) : base(serial)
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
