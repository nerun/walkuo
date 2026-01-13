/* ***************************************************************************
 * RagingGrizzlyBear.cs
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
    [CorpseName( "a grizzly bear corpse" )]
    [TypeAlias( "Server.Mobiles.Grizzlybear" )]
    public class RagingGrizzlyBear : BaseCreature
    {
        [Constructable]
        public RagingGrizzlyBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a raging grizzly bear";
            Body = 212;
            BaseSoundID = 0xA3;

            SetStr( 1251, 1550 );
            SetDex( 801, 1050 );
            SetInt( 151, 400 );

            SetHits( 751, 930 );
            SetMana( 0 );

            SetDamage( 18, 23 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 50, 70 );
            SetResistance( ResistanceType.Cold, 30, 50 );
            SetResistance( ResistanceType.Poison, 10, 20 );
            SetResistance( ResistanceType.Energy, 10, 20 );

            SetSkill( SkillName.Wrestling, 73.4, 88.1 );
            SetSkill( SkillName.Tactics, 73.6, 110.5 );
            SetSkill( SkillName.MagicResist, 32.8, 54.6 );
            SetSkill( SkillName.Anatomy, 0, 0 );

            Fame = 10000;  //Guessing here
            Karma = 10000;  //Guessing here

            VirtualArmor = 24;

            Tamable = false;
            
        }

        public override int Meat{ get{ return 4; } }
        public override int Hides{ get{ return 32; } }
        public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

        public RagingGrizzlyBear( Serial serial ) : base( serial )
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
