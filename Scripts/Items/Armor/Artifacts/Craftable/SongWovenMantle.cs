/* ***************************************************************************
 * SongWovenMantle.cs
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
using Server.Items;

namespace Server.Items
{
    public class SongWovenMantle : LeafArms
    {
        public override int LabelNumber{ get{ return 1072931; } } // Song Woven Mantle

        public override int BasePhysicalResistance{ get{ return 14; } }
        public override int BaseColdResistance{ get{ return 14; } }
        public override int BaseEnergyResistance{ get{ return 16; } }

        [Constructable]
        public SongWovenMantle()
        {
            Hue = 0x493;

            SkillBonuses.SetValues( 0, SkillName.Musicianship, 10.0 );

            Attributes.Luck = 100;
            Attributes.DefendChance = 5;
        }

        public SongWovenMantle( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 );
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
