/* ***************************************************************************
 * Silver.cs
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

namespace Server.Factions
{
    public class Silver : Item
    {
        public override double DefaultWeight
        {
            get { return 0.02; }
        }

        [Constructable]
        public Silver() : this( 1 )
        {
        }

        [Constructable]
        public Silver( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
        {
        }

        [Constructable]
        public Silver( int amount ) : base( 0xEF0 )
        {
            Stackable = true;
            Amount = amount;
        }

        public Silver( Serial serial ) : base( serial )
        {
        }

        public override int GetDropSound()
        {
            if ( Amount <= 1 )
                return 0x2E4;
            else if ( Amount <= 5 )
                return 0x2E5;
            else
                return 0x2E6;
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
