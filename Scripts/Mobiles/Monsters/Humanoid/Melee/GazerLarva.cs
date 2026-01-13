/* ***************************************************************************
 * GazerLarva.cs
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
    [CorpseName( "a gazer larva corpse" )]
    public class GazerLarva : BaseCreature
    {
        [Constructable]
        public GazerLarva () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a gazer larva";
            Body = 778;
            BaseSoundID = 377;

            SetStr( 76, 100 );
            SetDex( 51, 75 );
            SetInt( 56, 80 );

            SetHits( 36, 47 );

            SetDamage( 2, 9 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 15, 25 );

            SetSkill( SkillName.MagicResist, 70.0 );
            SetSkill( SkillName.Tactics, 70.0 );
            SetSkill( SkillName.Wrestling, 70.0 );

            Fame = 900;
            Karma = -900;

            VirtualArmor = 25;

            PackItem( new Nightshade( Utility.RandomMinMax( 2, 3 ) ) );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Poor );
        }

        public override int Meat{ get{ return 1; } }

        public GazerLarva( Serial serial ) : base( serial )
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
