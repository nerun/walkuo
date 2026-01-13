/* ***************************************************************************
 * PyramidAddon.cs
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
using System.Text;
using System.Net;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class PyramidAddon : BaseAddon
    {
        public override bool ShareHue
        {
            get { return false; }
        }

        [Constructable]
        public PyramidAddon()
        {
            AddComponent( new AddonComponent( 1006 ), 0, 0, 5 );

            for ( int o = 1; o <= 2; ++o )
            {
                AddComponent( new AddonComponent( 1011 ), -o, -o, ( 2 - o ) * 5 );
                AddComponent( new AddonComponent( 1012 ), +o, +o, ( 2 - o ) * 5 );
                AddComponent( new AddonComponent( 1013 ), +o, -o, ( 2 - o ) * 5 );
                AddComponent( new AddonComponent( 1014 ), -o, +o, ( 2 - o ) * 5 );
            }

            for ( int o = -1; o <= 1; ++o )
            {
                AddComponent( new AddonComponent( 1007 ), o, 2, 0 );
                AddComponent( new AddonComponent( 1008 ), 2, o, 0 );
                AddComponent( new AddonComponent( 1009 ), o, -2, 0 );
                AddComponent( new AddonComponent( 1010 ), -2, o, 0 );
            }

            AddComponent( new AddonComponent( 1007 ), 0, 1, 5 );
            AddComponent( new AddonComponent( 1008 ), 1, 0, 5 );
            AddComponent( new AddonComponent( 1009 ), 0, -1, 5 );
            AddComponent( new AddonComponent( 1010 ), -1, 0, 5 );
        }

        public PyramidAddon( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }
}
