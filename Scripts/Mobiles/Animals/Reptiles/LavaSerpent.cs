/* ***************************************************************************
 * LavaSerpent.cs
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
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "a lava serpent corpse" )]
    [TypeAlias( "Server.Mobiles.Lavaserpant" )]
    public class LavaSerpent : BaseCreature
    {
        [Constructable]
        public LavaSerpent() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
            Name = "a lava serpent";
            Body = 90;
            BaseSoundID = 219;

            SetStr( 386, 415 );
            SetDex( 56, 80 );
            SetInt( 66, 85 );

            SetHits( 232, 249 );
            SetMana( 0 );

            SetDamage( 10, 22 );

            SetDamageType( ResistanceType.Physical, 20 );
            SetDamageType( ResistanceType.Fire, 80 );

            SetResistance( ResistanceType.Physical, 35, 45 );
            SetResistance( ResistanceType.Fire, 70, 80 );
            SetResistance( ResistanceType.Poison, 30, 40 );
            SetResistance( ResistanceType.Energy, 10, 20 );

            SetSkill( SkillName.MagicResist, 25.3, 70.0 );
            SetSkill( SkillName.Tactics, 65.1, 70.0 );
            SetSkill( SkillName.Wrestling, 60.1, 80.0 );

            Fame = 4500;
            Karma = -4500;

            VirtualArmor = 40;

            PackItem( new SulfurousAsh( 3 ) );
            PackItem( new Bone() );
            // TODO: body parts, armour
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.Average );
        }

        public override bool DeathAdderCharmable{ get{ return true; } }

        public override bool HasBreath{ get{ return true; } } // fire breath enabled
        public override int Meat{ get{ return 4; } }
        public override int Hides{ get{ return 15; } }
        public override HideType HideType{ get{ return HideType.Spined; } }

        public LavaSerpent(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if ( BaseSoundID == -1 )
                BaseSoundID = 219;
        }
    }
}
