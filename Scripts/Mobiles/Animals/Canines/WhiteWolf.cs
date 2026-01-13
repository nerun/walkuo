/* ***************************************************************************
 * WhiteWolf.cs
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
    [CorpseName( "a white wolf corpse" )]
    [TypeAlias( "Server.Mobiles.Whitewolf" )]
    public class WhiteWolf : BaseCreature
    {
        [Constructable]
        public WhiteWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a white wolf";
            Body = Utility.RandomList( 34, 37 );
            BaseSoundID = 0xE5;

            SetStr( 56, 80 );
            SetDex( 56, 75 );
            SetInt( 31, 55 );

            SetHits( 34, 48 );
            SetMana( 0 );

            SetDamage( 3, 7 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 15, 20 );
            SetResistance( ResistanceType.Fire, 10, 15 );
            SetResistance( ResistanceType.Cold, 20, 25 );
            SetResistance( ResistanceType.Poison, 10, 15 );
            SetResistance( ResistanceType.Energy, 10, 15 );

            SetSkill( SkillName.MagicResist, 20.1, 35.0 );
            SetSkill( SkillName.Tactics, 45.1, 60.0 );
            SetSkill( SkillName.Wrestling, 45.1, 60.0 );

            Fame = 450;
            Karma = 0;

            VirtualArmor = 16;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 65.1;
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 6; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

        public WhiteWolf( Serial serial ) : base( serial )
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
