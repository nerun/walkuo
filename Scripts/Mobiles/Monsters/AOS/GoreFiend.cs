/* ***************************************************************************
 * GoreFiend.cs
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
    [CorpseName( "a gore fiend corpse" )]
    public class GoreFiend : BaseCreature
    {
        [Constructable]
        public GoreFiend() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a gore fiend";
            Body = 305;
            BaseSoundID = 224;

            SetStr( 161, 185 );
            SetDex( 41, 65 );
            SetInt( 46, 70 );

            SetHits( 97, 111 );

            SetDamage( 15, 21 );

            SetDamageType( ResistanceType.Physical, 85 );
            SetDamageType( ResistanceType.Poison, 15 );

            SetResistance( ResistanceType.Physical, 35, 45 );
            SetResistance( ResistanceType.Fire, 25, 35 );
            SetResistance( ResistanceType.Cold, 15, 25 );
            SetResistance( ResistanceType.Poison, 5, 15 );
            SetResistance( ResistanceType.Energy, 30, 40 );

            SetSkill( SkillName.MagicResist, 40.1, 55.0 );
            SetSkill( SkillName.Tactics, 45.1, 70.0 );
            SetSkill( SkillName.Wrestling, 50.1, 70.0 );

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 24;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average );
        }

        public override int GetDeathSound()
        {
            return 1218;
        }

        public override bool BleedImmune{ get{ return true; } }

        public GoreFiend( Serial serial ) : base( serial )
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
