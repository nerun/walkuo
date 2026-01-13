/* ***************************************************************************
 * Stockings.cs
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
    [Furniture]
    [FlipableAttribute( 0x2bd9, 0x2bda )]
    public class GreenStocking : BaseContainer
    {
        public override int DefaultGumpID{ get{ return 0x103; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        [Constructable]
        public GreenStocking() : base ( Utility.Random( 0x2BD9, 2 ) )
        {
        }

        public GreenStocking( Serial serial ) : base( serial )
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

    [Furniture]
    [FlipableAttribute( 0x2bdb, 0x2bdc )]
    public class RedStocking : BaseContainer
    {
        public override int DefaultGumpID{ get{ return 0x103; } }
        public override int DefaultDropSound{ get{ return 0x42; } }

        [Constructable]
        public RedStocking() : base ( Utility.Random( 0x2BDB, 2 ) )
        {
        }

        public RedStocking( Serial serial ) : base( serial )
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

