/* ***************************************************************************
 * BlueBook.cs
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

namespace Server.Items
{
    public class BlueBook : BaseBook
    {

        [Constructable]
        public BlueBook() : base( 0xFF2, 40, true )
        {
        }

        [Constructable]
        public BlueBook( int pageCount, bool writable ) : base( 0xFF2, pageCount, writable )
        {
        }

        [Constructable]
        public BlueBook( string title, string author, int pageCount, bool writable ) : base( 0xFF2, title, author, pageCount, writable )
        {
        }

        // Intended for defined books only
        public BlueBook( bool writable ) : base( 0xFF2, writable )
        {
        }

        public BlueBook( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 ); // version
        }
    }
}
