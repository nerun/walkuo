/* ***************************************************************************
 * MurkyMilk.cs
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
using Server;
using Server.Mobiles;

namespace Server.Items
{
    /* 
    first seen halloween 2009.  subsequently in 2010, 
    2011 and 2012. GM Beggar-only Semi-Rare Treats
    */

    public class MurkyMilk : Pitcher
    {
        public override string DefaultName { get { return "Murky Milk";; } }
        public override int MaxQuantity { get { return 5; } }
        public override double DefaultWeight { get { return 1; } }

        [Constructable]
        public MurkyMilk( )
            : base( BeverageType.Milk )
        {
            Hue = 0x3e5;
            Quantity = MaxQuantity;
            ItemID = ( Utility.RandomBool() ) ? 0x09F0 : 0x09AD;
        }

        public MurkyMilk( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( ( int )0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
