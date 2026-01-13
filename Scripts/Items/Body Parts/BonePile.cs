/* ***************************************************************************
 * BonePile.cs
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
using Server.Items;
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute( 0x1B09, 0x1B10 )]
    public class BonePile : Item, IScissorable
    {
        [Constructable]
        public BonePile( ) : base( 0x1B09 + Utility.Random( 8 ) )
        {
            Stackable = false;
            Weight = 10.0;
        }

        public BonePile( Serial serial ) : base( serial )
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

        public bool Scissor( Mobile from, Scissors scissors )
        {
            if ( Deleted || !from.CanSee( this ) )
                return false;

            base.ScissorHelper( from, new Bone(), Utility.RandomMinMax( 10, 15 ) );

            return true;
        }
    }
}
