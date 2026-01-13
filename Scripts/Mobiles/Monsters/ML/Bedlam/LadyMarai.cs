/* ***************************************************************************
 * LadyMarai.cs
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
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "a Lady Marai corpse" )]
    public class LadyMarai : SkeletalKnight
    {
        [Constructable]
        public LadyMarai()
        {
            IsParagon = true;

            Name = "Lady Marai";
            Hue = 0x21;

            SetStr( 221, 304 );
            SetDex( 98, 138 );
            SetInt( 54, 99 );

            SetHits( 694, 846 );

            SetDamage( 15, 25 );

            SetDamageType( ResistanceType.Physical, 40 );
            SetDamageType( ResistanceType.Cold, 60 );

            SetResistance( ResistanceType.Physical, 55, 65 );
            SetResistance( ResistanceType.Fire, 40, 50 );
            SetResistance( ResistanceType.Cold, 70, 80 );
            SetResistance( ResistanceType.Poison, 40, 50 );
            SetResistance( ResistanceType.Energy, 50, 60 );

            SetSkill( SkillName.Wrestling, 126.6, 137.2 );
            SetSkill( SkillName.Tactics, 128.7, 134.5 );
            SetSkill( SkillName.MagicResist, 102.1, 119.1 );
            SetSkill( SkillName.Anatomy, 126.2, 136.5 );

            Fame = 18000;
            Karma = -18000;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 3 );
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.CrushingBlow;
        }

        /*
        // TODO: Uncomment once added
        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            if ( Utility.RandomDouble() < 0.15 )
                c.DropItem( new DisintegratingThesisNotes() );

            if ( Utility.RandomDouble() < 0.1 )
                c.DropItem( new ParrotItem() );
        }
        */

        public override bool GivesMLMinorArtifact{ get{ return true; } }

        public LadyMarai( Serial serial )
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
