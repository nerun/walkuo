/* ***************************************************************************
 * DovetailSaw.cs
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
using Server.Engines.Craft;

namespace Server.Items
{
    [Flipable( 0x1028, 0x1029 )]
    public class DovetailSaw : BaseTool
    {
        public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

        [Constructable]
        public DovetailSaw() : base( 0x1028 )
        {
            Weight = 2.0;
        }

        [Constructable]
        public DovetailSaw( int uses ) : base( uses, 0x1028 )
        {
            Weight = 2.0;
        }

        public DovetailSaw( Serial serial ) : base( serial )
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

            if ( Weight == 1.0 )
                Weight = 2.0;
        }
    }
}
