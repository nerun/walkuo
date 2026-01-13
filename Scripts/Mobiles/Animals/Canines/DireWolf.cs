/* ***************************************************************************
 * DireWolf.cs
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
    [CorpseName( "a dire wolf corpse" )]
    [TypeAlias( "Server.Mobiles.Direwolf" )]
    public class DireWolf : BaseCreature
    {
        [Constructable]
        public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a dire wolf";
            Body = 23;
            BaseSoundID = 0xE5;

            SetStr( 96, 120 );
            SetDex( 81, 105 );
            SetInt( 36, 60 );

            SetHits( 58, 72 );
            SetMana( 0 );

            SetDamage( 11, 17 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 20, 25 );
            SetResistance( ResistanceType.Fire, 10, 20 );
            SetResistance( ResistanceType.Cold, 5, 10 );
            SetResistance( ResistanceType.Poison, 5, 10 );
            SetResistance( ResistanceType.Energy, 10, 15 );

            SetSkill( SkillName.MagicResist, 57.6, 75.0 );
            SetSkill( SkillName.Tactics, 50.1, 70.0 );
            SetSkill( SkillName.Wrestling, 60.1, 80.0 );

            Fame = 2500;
            Karma = -2500;

            VirtualArmor = 22;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 83.1;
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 7; } }
        public override HideType HideType{ get{ return HideType.Spined; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

        public DireWolf(Serial serial) : base(serial)
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
