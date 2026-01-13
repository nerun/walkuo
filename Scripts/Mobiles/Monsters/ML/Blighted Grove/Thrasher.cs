/* ***************************************************************************
 * Thrasher.cs
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
    [CorpseName( "a Thrasher corpse" )]
    public class Thrasher : Alligator
    {
        [Constructable]
        public Thrasher()
        {
            IsParagon = true;

            Name = "Thrasher";
            Hue = 0x497;

            SetStr( 93, 327 );
            SetDex( 7, 201 );
            SetInt( 15, 67 );

            SetHits( 260, 984 );
            SetStam( 56, 75 );
            SetMana( 25, 30 );

            SetDamage( 20, 30 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 50, 55 );
            SetResistance( ResistanceType.Fire, 25, 29 );
            SetResistance( ResistanceType.Poison, 25, 28 );

            SetSkill( SkillName.Wrestling, 101.2, 118.3 );
            SetSkill( SkillName.Tactics, 96.3, 117.3 );
            SetSkill( SkillName.MagicResist, 102.4, 118.6 );

            // TODO: Fame/Karma
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.FilthyRich, 4 );
        }

        public override WeaponAbility GetWeaponAbility()
        {
            return WeaponAbility.ArmorIgnore;
        }

        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            c.DropItem( new ThrashersTail() );
        }

        public override bool GivesMLMinorArtifact { get { return true; } }
        public override int Hides { get { return 48; } }
        public override int Meat { get { return 1; } }

        public Thrasher( Serial serial )
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
