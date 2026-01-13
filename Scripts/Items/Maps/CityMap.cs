/* ***************************************************************************
 * CityMap.cs
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
    public class CityMap : MapItem
    {
        [Constructable]
        public CityMap()
        {
            SetDisplay( 0, 0, 5119, 4095, 400, 400 );
        }

        public override void CraftInit( Mobile from )
        {
            double skillValue = from.Skills[SkillName.Cartography].Value;
            int dist = 64 + (int)(skillValue * 4);

            if ( dist < 200 )
                dist = 200;

            int size = 32 + (int)(skillValue * 2);

            if ( size < 200 )
                size = 200;
            else if ( size > 400 )
                size = 400;

            SetDisplay( from.X - dist, from.Y - dist, from.X + dist, from.Y + dist, size, size );
        }

        public override int LabelNumber{ get{ return 1015231; } } // city map

        public CityMap( Serial serial ) : base( serial )
        {
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
