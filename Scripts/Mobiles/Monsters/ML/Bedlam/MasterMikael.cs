/* ***************************************************************************
 * MasterMikael.cs
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
    [CorpseName( "a Master Mikael corpse" )]
    public class MasterMikael : BoneMagi
    {
        [Constructable]
        public MasterMikael()
        {
            IsParagon = true;

            Name = "Master Mikael";
            Hue = 0x8FD;

            SetStr( 93, 122 );
            SetDex( 91, 100 );
            SetInt( 252, 271 );

            SetHits( 789, 1014 );

            SetDamage( 11, 19 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 55, 59 );
            SetResistance( ResistanceType.Fire, 40, 46 );
            SetResistance( ResistanceType.Cold, 72, 80 );
            SetResistance( ResistanceType.Poison, 44, 49 );
            SetResistance( ResistanceType.Energy, 50, 57 );

            SetSkill( SkillName.Wrestling, 80.1, 87.2 );
            SetSkill( SkillName.Tactics, 79.0, 90.9 );
            SetSkill( SkillName.MagicResist, 90.3, 106.9 );
            SetSkill( SkillName.Magery, 103.8, 108.0 );
            SetSkill( SkillName.EvalInt, 96.1, 105.3 );
            SetSkill( SkillName.Necromancy, 103.8, 108.0 );
            SetSkill( SkillName.SpiritSpeak, 96.1, 105.3 );

            Fame = 18000;
            Karma = -18000;

            if ( Utility.RandomBool() )
                PackNecroScroll( Utility.RandomMinMax( 5, 9 ) );
            else
                PackScroll( 4, 7 );

            PackReg( 3 );
            PackNecroReg( 1, 10 );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 2 );
        }

        // TODO: Special move?

        /*
        // TODO: uncomment once added
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

        public MasterMikael( Serial serial )
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
