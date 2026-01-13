/* ***************************************************************************
 * BookOfNinjitsu.cs
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
using Server.Network;
using Server.Spells;

namespace Server.Items
{
    public class BookOfNinjitsu : Spellbook
    {
        public override SpellbookType SpellbookType{ get{ return SpellbookType.Ninja; } }
        public override int BookOffset{ get{ return 500; } }
        public override int BookCount{ get{ return 8; } }


        [Constructable]
        public BookOfNinjitsu() : this( (ulong)0xFF )
        {
        }

        [Constructable]
        public BookOfNinjitsu( ulong content ) : base( content, 0x23A0 )
        {
            Layer = (Core.ML ? Layer.OneHanded : Layer.Invalid);
        }

        public BookOfNinjitsu( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if( version == 0 && Core.ML )
                Layer = Layer.OneHanded;
        }
    }
}
