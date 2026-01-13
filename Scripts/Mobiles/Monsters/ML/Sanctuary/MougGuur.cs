/* ***************************************************************************
 * MougGuur.cs
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
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName( "a Moug-Guur corpse" )]
    public class MougGuur : Ettin
    {
        [Constructable]
        public MougGuur()
        {
            Name = "Moug-Guur";

            SetStr( 556, 575 );
            SetDex( 84, 94 );
            SetInt( 59, 73 );

            SetHits( 400, 415 );

            SetDamage( 12, 20 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 61, 65 );
            SetResistance( ResistanceType.Fire, 16, 19 );
            SetResistance( ResistanceType.Cold, 41, 46 );
            SetResistance( ResistanceType.Poison, 21, 24 );
            SetResistance( ResistanceType.Energy, 19, 25 );

            SetSkill( SkillName.MagicResist, 70.2, 75.0 );
            SetSkill( SkillName.Tactics, 80.8, 81.7 );
            SetSkill( SkillName.Wrestling, 93.9, 99.4 );

            Fame = 3000;
            Karma = -3000;
        }

        public MougGuur( Serial serial )
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
