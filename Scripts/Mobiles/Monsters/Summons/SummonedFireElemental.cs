/* ***************************************************************************
 * SummonedFireElemental.cs
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
    [CorpseName( "a fire elemental corpse" )]
    public class SummonedFireElemental : BaseCreature
    {
        public override double DispelDifficulty{ get{ return 117.5; } }
        public override double DispelFocus{ get{ return 45.0; } }

        [Constructable]
        public SummonedFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a fire elemental";
            Body = 15;
            BaseSoundID = 838;

            SetStr( 200 );
            SetDex( 200 );
            SetInt( 100 );

            SetDamage( 9, 14 );

            SetDamageType( ResistanceType.Physical, 0 );
            SetDamageType( ResistanceType.Fire, 100 );

            SetResistance( ResistanceType.Physical, 50, 60 );
            SetResistance( ResistanceType.Fire, 70, 80 );
            SetResistance( ResistanceType.Cold, 0, 10 );
            SetResistance( ResistanceType.Poison, 50, 60 );
            SetResistance( ResistanceType.Energy, 50, 60 );

            SetSkill( SkillName.EvalInt, 90.0 );
            SetSkill( SkillName.Magery, 90.0 );
            SetSkill( SkillName.MagicResist, 85.0 );
            SetSkill( SkillName.Tactics, 100.0 );
            SetSkill( SkillName.Wrestling, 92.0 );

            VirtualArmor = 40;
            ControlSlots = 4;

            AddItem( new LightSource() );
        }

        public SummonedFireElemental( Serial serial ) : base( serial )
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
        }
    }
}
