/* ***************************************************************************
 * CandleSkull.cs
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
    public class CandleSkull : BaseLight
    {
        public override int LitItemID
        {
            get
            {
                if ( ItemID == 0x1583 || ItemID == 0x1854 )
                    return 0x1854;

                return 0x1858;
            }
        }

        public override int UnlitItemID
        {
            get
            {
                if ( ItemID == 0x1853 || ItemID == 0x1584 )
                    return 0x1853;

                return 0x1857;
            }
        }

        [Constructable]
        public CandleSkull() : base( 0x1853 )
        {
            if ( Burnout )
                Duration = TimeSpan.FromMinutes( 25 );
            else
                Duration = TimeSpan.Zero;

            Burning = false;
            Light = LightType.Circle150;
            Weight = 5.0;
        }

        public CandleSkull( Serial serial ) : base( serial )
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
