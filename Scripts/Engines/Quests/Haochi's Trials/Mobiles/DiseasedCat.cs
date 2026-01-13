/* ***************************************************************************
 * DiseasedCat.cs
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

namespace Server.Engines.Quests.Samurai
{
    public class DiseasedCat : BaseCreature
    {
        [Constructable]
        public DiseasedCat() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            Name = "a diseased cat";
            Body = 0xC9;
            Hue = Utility.RandomAnimalHue();
            BaseSoundID = 0x69;

            SetStr( 9 );
            SetDex( 35 );
            SetInt( 5 );

            SetHits( 6 );
            SetMana( 0 );

            SetDamage( 1 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 5, 10 );

            SetSkill( SkillName.MagicResist, 5.0 );
            SetSkill( SkillName.Tactics, 4.0 );
            SetSkill( SkillName.Wrestling, 5.0 );

            VirtualArmor = 8;
        }

        public override bool AlwaysMurderer{ get{ return true; } }

        public DiseasedCat( Serial serial ) : base( serial )
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            if( Name == "a deseased cat" )
                Name = "a diseased cat";
        }
    }
}
