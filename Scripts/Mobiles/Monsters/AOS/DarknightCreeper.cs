/* ***************************************************************************
 * DarknightCreeper.cs
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
    [CorpseName( "a darknight creeper corpse" )]
    public class DarknightCreeper : BaseCreature
    {
        public override bool IgnoreYoungProtection { get { return Core.ML; } }

        [Constructable]
        public DarknightCreeper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = NameList.RandomName( "darknight creeper" );
            Body = 313;
            BaseSoundID = 0xE0;

            SetStr( 301, 330 );
            SetDex( 101, 110 );
            SetInt( 301, 330 );

            SetHits( 4000 );

            SetDamage( 22, 26 );

            SetDamageType( ResistanceType.Physical, 85 );
            SetDamageType( ResistanceType.Poison, 15 );

            SetResistance( ResistanceType.Physical, 60 );
            SetResistance( ResistanceType.Fire, 60 );
            SetResistance( ResistanceType.Cold, 100 );
            SetResistance( ResistanceType.Poison, 90 );
            SetResistance( ResistanceType.Energy, 75 );

            SetSkill( SkillName.DetectHidden, 80.0 );
            SetSkill( SkillName.EvalInt, 118.1, 120.0 );
            SetSkill( SkillName.Magery, 112.6, 120.0 );
            SetSkill( SkillName.Meditation, 150.0 );
            SetSkill( SkillName.Poisoning, 120.0 );
            SetSkill( SkillName.MagicResist, 90.1, 90.9 );
            SetSkill( SkillName.Tactics, 100.0 );
            SetSkill( SkillName.Wrestling, 90.1, 90.9 );
            SetSkill( SkillName.Necromancy, 120.1, 130.0 );
            SetSkill( SkillName.SpiritSpeak, 120.1, 130.0 );

            Fame = 22000;
            Karma = -22000;

            VirtualArmor = 34;
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 2 );
        }

        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            if ( !Summoned && !NoKillAwards && DemonKnight.CheckArtifactChance( this ) )
                DemonKnight.DistributeArtifact( this );
        }

        public override bool BardImmune{ get{ return !Core.SE; } }
        public override bool Unprovokable{ get{ return Core.SE; } }
        public override bool AreaPeaceImmune { get { return Core.SE; } }
        public override bool BleedImmune{ get{ return true; } }
        public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
        public override Poison HitPoison{ get{ return Poison.Lethal; } }

        public override int TreasureMapLevel{ get{ return 1; } }

        public DarknightCreeper( Serial serial ) : base( serial )
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

            if ( BaseSoundID == 471 )
                BaseSoundID = 0xE0;
        }
    }
}
