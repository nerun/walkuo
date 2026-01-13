/* ***************************************************************************
 * WailingBanshee.cs
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
    [CorpseName( "a wailing banshee corpse" )]
    public class WailingBanshee : BaseCreature
    {
        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.MortalStrike;
        }

        [Constructable]
        public WailingBanshee() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a wailing banshee";
            Body = 310;
            BaseSoundID = 0x482;

            SetStr( 126, 150 );
            SetDex( 76, 100 );
            SetInt( 86, 110 );

            SetHits( 76, 90 );

            SetDamage( 10, 14 );

            SetDamageType( ResistanceType.Physical, 20 );
            SetDamageType( ResistanceType.Cold, 60 );
            SetDamageType( ResistanceType.Poison, 20 );

            SetResistance( ResistanceType.Physical, 50, 60 );
            SetResistance( ResistanceType.Fire, 25, 30 );
            SetResistance( ResistanceType.Cold, 70, 80 );
            SetResistance( ResistanceType.Poison, 30, 40 );
            SetResistance( ResistanceType.Energy, 40, 50 );

            SetSkill( SkillName.MagicResist, 70.1, 95.0 );
            SetSkill( SkillName.Tactics, 45.1, 70.0 );
            SetSkill( SkillName.Wrestling, 50.1, 70.0 );

            Fame = 1500;
            Karma = -1500;

            VirtualArmor = 19;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Meager );
        }

        public override bool BleedImmune{ get{ return true; } }

        public WailingBanshee( Serial serial ) : base( serial )
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
