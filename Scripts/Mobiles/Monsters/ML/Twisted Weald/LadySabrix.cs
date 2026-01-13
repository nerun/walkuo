/* ***************************************************************************
 * LadySabrix.cs
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
    [CorpseName( "a Lady Sabrix corpse" )]
    public class LadySabrix : GiantBlackWidow
    {
        [Constructable]
        public LadySabrix()
        {
            IsParagon = true;

            Name = "Lady Sabrix";
            Hue = 0x497;

            SetStr( 82, 130 );
            SetDex( 117, 146 );
            SetInt( 50, 98 );

            SetHits( 233, 361 );
            SetStam( 117, 146 );
            SetMana( 50, 98 );

            SetDamage( 15, 22 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 40, 50 );
            SetResistance( ResistanceType.Fire, 30, 40 );
            SetResistance( ResistanceType.Cold, 30, 39 );
            SetResistance( ResistanceType.Poison, 70, 80 );
            SetResistance( ResistanceType.Energy, 35, 44 );

            SetSkill( SkillName.Wrestling, 109.8, 122.8 );
            SetSkill( SkillName.Tactics, 102.8, 120.0 );
            SetSkill( SkillName.MagicResist, 79.4, 95.1 );
            SetSkill( SkillName.Anatomy, 68.8, 105.1 );
            SetSkill( SkillName.Poisoning, 97.8, 116.7 );

            Fame = 18900;
            Karma = -18900;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 2 );
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.ArmorIgnore;
        }

        /*
        // TODO: uncomment once added
        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            if ( Utility.RandomDouble() < 0.2 )
                c.DropItem( new SabrixsEye() );

            if ( Utility.RandomDouble() < 0.25 )
            {
                switch ( Utility.Random( 2 ) )
                {
                    case 0: AddToBackpack( new PaladinArms() ); break;
                    case 1: AddToBackpack( new HunterLegs() ); break;
                }
            }

            if ( Utility.RandomDouble() < 0.1 )
                c.DropItem( new ParrotItem() );
        }
        */

        public override bool GivesMLMinorArtifact{ get{ return true; } }

        public LadySabrix( Serial serial )
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
