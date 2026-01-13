/* ***************************************************************************
 * Candle.cs
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
    public class Candle : BaseEquipableLight
    {
        public override int LitItemID{ get { return 0xA0F; } }
        public override int UnlitItemID{ get { return 0xA28; } }

        [Constructable]
        public Candle() : base( 0xA28 )
        {
            if ( Burnout )
                Duration = TimeSpan.FromMinutes( 20 );
            else
                Duration = TimeSpan.Zero;

            Burning = false;
            Light = LightType.Circle150;
            Weight = 1.0;
        }

        public Candle( Serial serial ) : base( serial )
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
