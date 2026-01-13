/* ***************************************************************************
 * MediumDragonBoat.cs
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
    public class MediumDragonBoat : BaseBoat
    {
        public override int NorthID{ get{ return 0xC; } }
        public override int  EastID{ get{ return 0xD; } }
        public override int SouthID{ get{ return 0xE; } }
        public override int  WestID{ get{ return 0xF; } }

        public override int HoldDistance{ get{ return 4; } }
        public override int TillerManDistance{ get{ return -5; } }

        public override Point2D StarboardOffset{ get{ return new Point2D(  2, 0 ); } }
        public override Point2D      PortOffset{ get{ return new Point2D( -2, 0 ); } }

        public override Point3D MarkOffset{ get{ return new Point3D( 0, 1, 3 ); } }

        public override BaseDockedBoat DockedBoat{ get{ return new MediumDockedDragonBoat( this ); } }

        [Constructable]
        public MediumDragonBoat()
        {
        }

        public MediumDragonBoat( Serial serial ) : base( serial )
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

    public class MediumDragonBoatDeed : BaseBoatDeed
    {
        public override int LabelNumber{ get{ return 1041208; } } // medium dragon ship deed
        public override BaseBoat Boat{ get{ return new MediumDragonBoat(); } }

        [Constructable]
        public MediumDragonBoatDeed() : base( 0xC, Point3D.Zero )
        {
        }

        public MediumDragonBoatDeed( Serial serial ) : base( serial )
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

    public class MediumDockedDragonBoat : BaseDockedBoat
    {
        public override BaseBoat Boat{ get{ return new MediumDragonBoat(); } }

        public MediumDockedDragonBoat( BaseBoat boat ) : base( 0xC, Point3D.Zero, boat )
        {
        }

        public MediumDockedDragonBoat( Serial serial ) : base( serial )
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
