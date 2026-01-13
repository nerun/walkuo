/* ***************************************************************************
 * Ridgeback.cs
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
    [CorpseName( "a ridgeback corpse" )]
    public class Ridgeback : BaseMount
    {
        [Constructable]
        public Ridgeback() : this( "a ridgeback" )
        {
        }

        [Constructable]
        public Ridgeback( string name ) : base( name, 187, 0x3EBA, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            BaseSoundID = 0x3F3;

            SetStr( 58, 100 );
            SetDex( 56, 75 );
            SetInt( 16, 30 );

            SetHits( 41, 54 );
            SetMana( 0 );

            SetDamage( 3, 5 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 15, 25 );
            SetResistance( ResistanceType.Fire, 5, 10 );
            SetResistance( ResistanceType.Cold, 5, 10 );
            SetResistance( ResistanceType.Poison, 5, 10 );
            SetResistance( ResistanceType.Energy, 5, 10 );

            SetSkill( SkillName.MagicResist, 25.3, 40.0 );
            SetSkill( SkillName.Tactics, 29.3, 44.0 );
            SetSkill( SkillName.Wrestling, 35.1, 45.0 );

            Fame = 300;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 83.1;
        }

        public override bool OverrideBondingReqs()
        {
            return true;
        }

        public override double GetControlChance( Mobile m, bool useBaseSkill )
        {
            return 1.0;
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 12; } }
        public override HideType HideType{ get{ return HideType.Spined; } }
        public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public Ridgeback( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
