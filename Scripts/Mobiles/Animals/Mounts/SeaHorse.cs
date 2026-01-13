/* ***************************************************************************
 * SeaHorse.cs
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
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "a sea horse corpse" )]
    public class SeaHorse : BaseMount
    {
        [Constructable]
        public SeaHorse() : this( "a sea horse" )
        {
        }

        [Constructable]
        public SeaHorse( string name ) : base( name, 0x90, 0x3EB3, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
        {
            InitStats( Utility.Random( 50, 30 ), Utility.Random( 50, 30 ), 10 );
            Skills[SkillName.MagicResist].Base = 25.0 + (Utility.RandomDouble() * 5.0);
            Skills[SkillName.Wrestling].Base = 35.0 + (Utility.RandomDouble() * 10.0);
            Skills[SkillName.Tactics].Base = 30.0 + (Utility.RandomDouble() * 15.0);
        }

        public SeaHorse( Serial serial ) : base( serial )
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
