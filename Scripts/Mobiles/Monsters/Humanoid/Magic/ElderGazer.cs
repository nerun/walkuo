/* ***************************************************************************
 * ElderGazer.cs
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
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "an elder gazer corpse" )]
    public class ElderGazer : BaseCreature
    {
        [Constructable]
        public ElderGazer () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "an elder gazer";
            Body = 22;
            BaseSoundID = 377;

            SetStr( 296, 325 );
            SetDex( 86, 105 );
            SetInt( 291, 385 );

            SetHits( 178, 195 );

            SetDamage( 8, 19 );

            SetDamageType( ResistanceType.Physical, 50 );
            SetDamageType( ResistanceType.Energy, 50 );

            SetResistance( ResistanceType.Physical, 45, 55 );
            SetResistance( ResistanceType.Fire, 60, 70 );
            SetResistance( ResistanceType.Cold, 40, 50 );
            SetResistance( ResistanceType.Poison, 40, 50 );
            SetResistance( ResistanceType.Energy, 40, 50 );

            SetSkill( SkillName.Anatomy, 62.0, 100.0 );
            SetSkill( SkillName.EvalInt, 90.1, 100.0 );
            SetSkill( SkillName.Magery, 90.1, 100.0 );
            SetSkill( SkillName.MagicResist, 115.1, 130.0 );
            SetSkill( SkillName.Tactics, 80.1, 100.0 );
            SetSkill( SkillName.Wrestling, 80.1, 100.0 );

            Fame = 12500;
            Karma = -12500;

            VirtualArmor = 50;
        }

        public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 0; } }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.FilthyRich );
        }

        public ElderGazer( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
