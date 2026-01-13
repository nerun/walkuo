/* ***************************************************************************
 * GiantToad.cs
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
    [CorpseName( "a giant toad corpse" )]
    [TypeAlias( "Server.Mobiles.Gianttoad" )]
    public class GiantToad : BaseCreature
    {
        [Constructable]
        public GiantToad() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a giant toad";
            Body = 80;
            BaseSoundID = 0x26B;

            SetStr( 76, 100 );
            SetDex( 6, 25 );
            SetInt( 11, 20 );

            SetHits( 46, 60 );
            SetMana( 0 );

            SetDamage( 5, 17 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 20, 25 );
            SetResistance( ResistanceType.Fire, 5, 10 );
            SetResistance( ResistanceType.Energy, 5, 10 );

            SetSkill( SkillName.MagicResist, 25.1, 40.0 );
            SetSkill( SkillName.Tactics, 40.1, 60.0 );
            SetSkill( SkillName.Wrestling, 40.1, 60.0 );

            Fame = 750;
            Karma = -750;

            VirtualArmor = 24;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 77.1;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
        }

        public override int Hides{ get{ return 12; } }
        public override HideType HideType{ get{ return HideType.Spined; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

        public GiantToad(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            if ( version < 1 )
            {
                    AI = AIType.AI_Melee;
                    FightMode = FightMode.Closest;
            }
        }
    }
}
