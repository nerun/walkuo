/* ***************************************************************************
 * IceSnake.cs
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
    [CorpseName( "an ice snake corpse" )]
    [TypeAlias( "Server.Mobiles.Icesnake" )]
    public class IceSnake : BaseCreature
    {
        [Constructable]
        public IceSnake() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "an ice snake";
            Body = 52;
            Hue = 0x480;
            BaseSoundID = 0xDB;

            SetStr( 42, 54 );
            SetDex( 36, 45 );
            SetInt( 26, 30 );

            SetMana( 0 );

            SetDamage( 4, 12 );

            SetDamageType( ResistanceType.Physical, 25 );
            SetDamageType( ResistanceType.Cold, 25 );
            SetDamageType( ResistanceType.Poison, 50 );

            SetResistance( ResistanceType.Physical, 20, 25 );
            SetResistance( ResistanceType.Cold, 80, 90 );
            SetResistance( ResistanceType.Poison, 60, 70 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.MagicResist, 15.1, 20.0 );
            SetSkill( SkillName.Tactics, 39.3, 54.0 );
            SetSkill( SkillName.Wrestling, 39.3, 54.0 );

            Fame = 900;
            Karma = -900;

            VirtualArmor = 30;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Meager );
        }

        public override bool DeathAdderCharmable{ get{ return true; } }

        public override int Meat{ get{ return 1; } }

        public IceSnake(Serial serial) : base(serial)
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
