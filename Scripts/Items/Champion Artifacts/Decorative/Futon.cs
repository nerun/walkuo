/* ***************************************************************************
 * Futon.cs
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
    [Flipable]
    public class Futon : Item
    {
        [Constructable]
        public Futon() : base( Utility.RandomDouble() > 0.5 ? 0x295C : 0x295E )
        {
        }

        public Futon( Serial serial ) : base( serial )
        {
        }

        public void Flip()
        {
            switch ( ItemID )
            {
                case 0x295C: ItemID = 0x295D; break;
                case 0x295E: ItemID = 0x295F; break;

                case 0x295D: ItemID = 0x295C; break;
                case 0x295F: ItemID = 0x295E; break;
            }
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
