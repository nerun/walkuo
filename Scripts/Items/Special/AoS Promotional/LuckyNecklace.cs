/* ***************************************************************************
 * LuckyNecklace.cs
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
﻿using System;
using Server.Mobiles;

namespace Server.Items
{
    public class LuckyNecklace : BaseJewel
    {
        public override int Hue{ get { return 1150; } }
        public override int LabelNumber{ get { return 1075239; } }  //Lucky Necklace    1075239

        [Constructable]
        public LuckyNecklace( )
            : base( 0x1088, Layer.Neck  )
        {
            base.Attributes.Luck = 200;
            LootType = LootType.Blessed;
        }

        public LuckyNecklace( Serial serial ) : base( serial )
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

            reader.ReadInt(); /* int version = reader.ReadInt(); Why? Just to have an unused var? */
        }
    }
}
