/* ***************************************************************************
 * Szavetra.cs
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
    [CorpseName( "a Szavetra corpse" )]
    public class Szavetra : Succubus
    {
        [Constructable]
        public Szavetra()
        {
            Name = "Szavetra";

            SetStr( 627, 655 );
            SetDex( 164, 193 );
            SetInt( 566, 595 );

            SetHits( 312, 415 );

            SetDamage( 20, 30 );

            SetDamageType( ResistanceType.Physical, 75 );
            SetDamageType( ResistanceType.Energy, 25 );

            SetResistance( ResistanceType.Physical, 83, 90 );
            SetResistance( ResistanceType.Fire, 72, 80 );
            SetResistance( ResistanceType.Cold, 40, 49 );
            SetResistance( ResistanceType.Poison, 51, 60 );
            SetResistance( ResistanceType.Energy, 50, 60 );

            SetSkill( SkillName.EvalInt, 90.3, 99.8 );
            SetSkill( SkillName.Magery, 100.1, 100.6 ); // 10.1-10.6 on OSI, bug?
            SetSkill( SkillName.Meditation, 90.1, 110.0 );
            SetSkill( SkillName.MagicResist, 112.2, 127.2 );
            SetSkill( SkillName.Tactics, 91.2, 92.8 );
            SetSkill( SkillName.Wrestling, 80.2, 86.4 );

            Fame = 24000;
            Karma = -24000;
        }

        public Szavetra( Serial serial )
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
