/* ***************************************************************************
 * DeathAdder.cs
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

namespace Server.Mobiles
{
    [CorpseName( "a death adder corpse" )]
    public class DeathAdder : BaseFamiliar
    {
        public DeathAdder()
        {
            Name = "a death adder";
            Body = 0x15;
            Hue = 0x455;
            BaseSoundID = 219;

            SetStr( 70 );
            SetDex( 150 );
            SetInt( 100 );

            SetHits( 50 );
            SetStam( 150 );
            SetMana( 0 );

            SetDamage( 1, 4 );
            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 10 );
            SetResistance( ResistanceType.Poison, 100 );

            SetSkill( SkillName.Wrestling, 90.0 );
            SetSkill( SkillName.Tactics, 50.0 );
            SetSkill( SkillName.MagicResist, 100.0 );
            SetSkill( SkillName.Poisoning, 150.0 );

            ControlSlots = 1;
        }

        public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

        public DeathAdder( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
