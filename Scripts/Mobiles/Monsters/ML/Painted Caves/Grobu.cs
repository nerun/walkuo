/* ***************************************************************************
 * Grobu.cs
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
    [CorpseName( "a Grobu corpse" )]
    public class Grobu : BlackBear
    {
        [Constructable]
        public Grobu()
        {
            IsParagon = true;

            Name = "Grobu";
            Hue = 0x455;

            AI = AIType.AI_Melee;
            FightMode = FightMode.Closest;

            SetStr( 192, 210 );
            SetDex( 132, 150 );
            SetInt( 50, 52 );

            SetHits( 1235, 1299 );
            SetStam( 132, 150 );
            SetMana( 9 );

            SetDamage( 15, 18 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 40, 45 );
            SetResistance( ResistanceType.Fire, 20, 40 );
            SetResistance( ResistanceType.Cold, 32, 35 );
            SetResistance( ResistanceType.Poison, 25, 30 );
            SetResistance( ResistanceType.Energy, 22, 34 );

            SetSkill( SkillName.Wrestling, 96.4, 119.0 );
            SetSkill( SkillName.Tactics, 96.2, 116.5 );
            SetSkill( SkillName.MagicResist, 66.2, 83.7 );

            Fame = 1000;
            Karma = 1000;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.FilthyRich, 2 );
        }


        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            c.DropItem( new GrobusFur() );
        }

        public override bool GivesMLMinorArtifact{ get{ return true; } }

        public Grobu( Serial serial )
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
