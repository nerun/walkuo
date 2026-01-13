/* ***************************************************************************
 * Waist.cs
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

namespace Server.Items
{

    public abstract class BaseWaist : BaseClothing
    {
        public BaseWaist( int itemID ) : this( itemID, 0 )
        {
        }

        public BaseWaist( int itemID, int hue ) : base( itemID, Layer.Waist, hue )
        {
        }

        public BaseWaist( Serial serial ) : base( serial )
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

    [FlipableAttribute( 0x153b, 0x153c )]
    public class HalfApron : BaseWaist
    {
        [Constructable]
        public HalfApron() : this( 0 )
        {
        }

        [Constructable]
        public HalfApron( int hue ) : base( 0x153b, hue )
        {
            Weight = 2.0;
        }

        public HalfApron( Serial serial ) : base( serial )
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

    [Flipable( 0x27A0, 0x27EB )]
    public class Obi : BaseWaist
    {
        [Constructable]
        public Obi() : this( 0 )
        {
        }

        [Constructable]
        public Obi( int hue ) : base( 0x27A0, hue )
        {
            Weight = 1.0;
        }

        public Obi( Serial serial ) : base( serial )
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

    [FlipableAttribute( 0x2B68, 0x315F )]
    public class WoodlandBelt : BaseWaist
    {
        public override Race RequiredRace { get { return Race.Elf; } }

        [Constructable]
        public WoodlandBelt() : this( 0 )
        {
        }

        [Constructable]
        public WoodlandBelt( int hue ) : base( 0x2B68, hue )
        {
            Weight = 4.0;
        }

        public WoodlandBelt( Serial serial ) : base( serial )
        {
        }

        public override bool Dye( Mobile from, DyeTub sender )
        {
            from.SendLocalizedMessage( sender.FailMessage );
            return false;
        }

        public override bool Scissor( Mobile from, Scissors scissors )
        {
            from.SendLocalizedMessage( 502440 ); // Scissors can not be used on that to produce anything.
            return false;
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
