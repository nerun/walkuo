/* ***************************************************************************
 * TailorBag.cs
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

namespace Server.Items
{
    public class TailorBag : Bag
    {
        public override string DefaultName
        {
            get { return "a Tailoring Kit"; }
        }

        [Constructable]
        public TailorBag() : this( 1 )
        {
            Movable = true;
            Hue = 0x315;
        }

        [Constructable]
        public TailorBag( int amount )
        {
            DropItem( new SewingKit( 5 ) );
            DropItem( new Scissors() );
            DropItem( new Hides( 500 ) );
            DropItem( new BoltOfCloth( 20 ) );
            DropItem( new DyeTub() );
            DropItem( new DyeTub() );
            DropItem( new BlackDyeTub() );
            DropItem( new Dyes() );
        }
        
        public TailorBag( Serial serial ) : base( serial )
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
