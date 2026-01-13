/* ***************************************************************************
 * JesterHatofChuckles.cs
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
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
    public class JesterHatofChuckles : BaseHat, ITokunoDyable
    {
        public override int LabelNumber { get { return 1073256; } }  //Jester Hat of Chuckles - Museum of Vesper Replica    1073256

        public override int BasePhysicalResistance { get { return 12; } }
        public override int BaseFireResistance { get { return 12; } }
        public override int BaseColdResistance { get { return 12; } }
        public override int BasePoisonResistance { get { return 12; } }
        public override int BaseEnergyResistance { get { return 12; } }

        public override int InitMinHits{ get{ return 100; } }
        public override int InitMaxHits{ get{ return 100; } }

        [Constructable]
        public JesterHatofChuckles() : this( Utility.RandomList( 0x13e, 0x03, 0x172, 0x3f ) )
        {
        }

        [Constructable]
        public JesterHatofChuckles( int hue ) : base( 0x171C, hue )
        {
            Attributes.Luck = 150;
            Weight = 1.0;
        }

        public JesterHatofChuckles( Serial serial ) : base( serial )
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
        }
    }
}
