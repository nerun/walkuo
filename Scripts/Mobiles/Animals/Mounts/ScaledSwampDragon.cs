/* ***************************************************************************
 * ScaledSwampDragon.cs
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
    [CorpseName( "a swamp dragon corpse" )]
    public class ScaledSwampDragon : BaseMount
    {
        [Constructable]
        public ScaledSwampDragon() : this( "a swamp dragon" )
        {
        }

        [Constructable]
        public ScaledSwampDragon( string name ) : base( name, 0x31F, 0x3EBE, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            SetStr( 201, 300 );
            SetDex( 66, 85 );
            SetInt( 61, 100 );

            SetHits( 121, 180 );

            SetDamage( 3, 4 );

            SetDamageType( ResistanceType.Physical, 75 );
            SetDamageType( ResistanceType.Poison, 25 );

            SetResistance( ResistanceType.Physical, 35, 40 );
            SetResistance( ResistanceType.Fire, 20, 30 );
            SetResistance( ResistanceType.Cold, 20, 40 );
            SetResistance( ResistanceType.Poison, 20, 30 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.Anatomy, 45.1, 55.0 );
            SetSkill( SkillName.MagicResist, 45.1, 55.0 );
            SetSkill( SkillName.Tactics, 45.1, 55.0 );
            SetSkill( SkillName.Wrestling, 45.1, 55.0 );

            Fame = 2000;
            Karma = -2000;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 93.9;
        }

        public override bool OverrideBondingReqs()
        {
            return true;
        }

        public override double GetControlChance( Mobile m, bool useBaseSkill )
        {
            return 1.0;
        }

        public override bool AutoDispel{ get{ return !Controlled; } }
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

        public ScaledSwampDragon( Serial serial ) : base( serial )
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
