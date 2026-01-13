/* ***************************************************************************
 * FireSteed.cs
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
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "a fire steed corpse" )]
    public class FireSteed : BaseMount
    {
        [Constructable]
        public FireSteed() : this( "a fire steed" )
        {
        }

        [Constructable]
        public FireSteed( string name ) : base( name, 0xBE, 0x3E9E, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            BaseSoundID = 0xA8;

            SetStr( 376, 400 );
            SetDex( 91, 120 );
            SetInt( 291, 300 );

            SetHits( 226, 240 );

            SetDamage( 11, 30 );

            SetDamageType( ResistanceType.Physical, 20 );
            SetDamageType( ResistanceType.Fire, 80 );

            SetResistance( ResistanceType.Physical, 30, 40 );
            SetResistance( ResistanceType.Fire, 70, 80 );
            SetResistance( ResistanceType.Cold, 20, 30 );
            SetResistance( ResistanceType.Poison, 30, 40 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.MagicResist, 100.0, 120.0 );
            SetSkill( SkillName.Tactics, 100.0 );
            SetSkill( SkillName.Wrestling, 100.0 );

            Fame = 20000;
            Karma = -20000;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 106.0;
        }

        public override void GenerateLoot()
        {
            PackItem( new SulfurousAsh( Utility.RandomMinMax( 151, 300 ) ) );
            PackItem( new Ruby( Utility.RandomMinMax( 16, 30 ) ) );
        }

        public override bool HasBreath{ get{ return true; } } // fire breath enabled
        public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Daemon | PackInstinct.Equine; } }

        public FireSteed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( BaseSoundID <= 0 )
                BaseSoundID = 0xA8;

            if( version < 1 )
            {
                for ( int i = 0; i < Skills.Length; ++i )
                {
                    Skills[i].Cap = Math.Max( 100.0, Skills[i].Cap * 0.9 );

                    if ( Skills[i].Base > Skills[i].Cap )
                    {
                        Skills[i].Base = Skills[i].Cap;
                    }
                }
            }
        }
    }
}
