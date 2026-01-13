/* ***************************************************************************
 * SmallDragonBoat.cs
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
using Server.Items;

namespace Server.Multis
{
    public class SmallDragonBoat : BaseBoat
    {
        public override int NorthID{ get{ return 0x4; } }
        public override int  EastID{ get{ return 0x5; } }
        public override int SouthID{ get{ return 0x6; } }
        public override int  WestID{ get{ return 0x7; } }

        public override int HoldDistance{ get{ return 4; } }
        public override int TillerManDistance{ get{ return -4; } }

        public override Point2D StarboardOffset{ get{ return new Point2D(  2, 0 ); } }
        public override Point2D      PortOffset{ get{ return new Point2D( -2, 0 ); } }

        public override Point3D MarkOffset{ get{ return new Point3D( 0, 1, 3 ); } }

        public override BaseDockedBoat DockedBoat{ get{ return new SmallDockedDragonBoat( this ); } }

        [Constructable]
        public SmallDragonBoat()
        {
        }

        public SmallDragonBoat( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 );
        }
    }

    public class SmallDragonBoatDeed : BaseBoatDeed
    {
        public override int LabelNumber{ get{ return 1041206; } } // small dragon ship deed
        public override BaseBoat Boat{ get{ return new SmallDragonBoat(); } }

        [Constructable]
        public SmallDragonBoatDeed() : base( 0x4, Point3D.Zero )
        {
        }

        public SmallDragonBoatDeed( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 );
        }
    }

    public class SmallDockedDragonBoat : BaseDockedBoat
    {
        public override BaseBoat Boat{ get{ return new SmallDragonBoat(); } }

        public SmallDockedDragonBoat( BaseBoat boat ) : base( 0x4, Point3D.Zero, boat )
        {
        }

        public SmallDockedDragonBoat( Serial serial ) : base( serial )
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 );
        }
    }
}
