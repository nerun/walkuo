/* ***************************************************************************
 * Rend.cs
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
    [CorpseName( "a Rend corpse" )]
    public class Rend : Reptalon
    {
        [Constructable]
        public Rend()
        {
            IsParagon = true;

            Name = "Rend";
            Hue = 0x455;

            SetStr( 1261, 1284 );
            SetDex( 363, 384 );
            SetInt( 601, 642 );

            SetHits( 5176, 6100 );

            SetDamage( 26, 33 );

            SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType( ResistanceType.Poison, 0 );
            SetDamageType( ResistanceType.Energy, 0 );

            SetResistance( ResistanceType.Physical, 75, 85 );
            SetResistance( ResistanceType.Fire, 81, 94 );
            SetResistance( ResistanceType.Cold, 46, 55 );
            SetResistance( ResistanceType.Poison, 35, 44 );
            SetResistance( ResistanceType.Energy, 45, 52 );

            SetSkill( SkillName.Wrestling, 136.3, 150.3 );
            SetSkill( SkillName.Tactics, 133.4, 141.4 );
            SetSkill( SkillName.MagicResist, 90.9, 110.0 );
            SetSkill( SkillName.Anatomy, 66.6, 72.0 );

            Fame = 21000;
            Karma = -21000;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 3 );
        }

        public override WeaponAbility GetWeaponAbility()
        {
            if ( Utility.RandomBool() )
                return WeaponAbility.ParalyzingBlow;
            else
                return WeaponAbility.BleedAttack;
        }

        public override bool GivesMLMinorArtifact{ get{ return true; } }

        public Rend( Serial serial )
            : base( serial )
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
