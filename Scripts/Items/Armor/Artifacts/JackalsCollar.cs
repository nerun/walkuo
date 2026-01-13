/* ***************************************************************************
 * JackalsCollar.cs
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
    public class JackalsCollar : PlateGorget
    {
        public override int LabelNumber{ get{ return 1061594; } } // Jackal's Collar
        public override int ArtifactRarity{ get{ return 11; } }

        public override int BaseFireResistance{ get{ return 23; } }
        public override int BaseColdResistance{ get{ return 17; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public JackalsCollar()
        {
            Hue = 0x6D1;
            Attributes.BonusDex = 15;
            Attributes.RegenHits = 2;
        }

        public JackalsCollar( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( version < 1 )
            {
                if ( Hue == 0x54B )
                    Hue = 0x6D1;

                FireBonus = 0;
                ColdBonus = 0;
            }
        }
    }
}
