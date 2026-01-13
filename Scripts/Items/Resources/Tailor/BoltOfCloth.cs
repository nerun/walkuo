/* ***************************************************************************
 * BoltOfCloth.cs
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
using Server.Network;

namespace Server.Items
{
    [FlipableAttribute( 0xF95, 0xF96, 0xF97, 0xF98, 0xF99, 0xF9A, 0xF9B, 0xF9C )]
    public class BoltOfCloth : Item, IScissorable, IDyable, ICommodity
    {
        int ICommodity.DescriptionNumber { get { return LabelNumber; } }
        bool ICommodity.IsDeedable { get { return true; } }

        [Constructable]
        public BoltOfCloth() : this( 1 )
        {
        }

        [Constructable]
        public BoltOfCloth( int amount ) : base( 0xF95 )
        {
            Stackable = true;
            Weight = 5.0;
            Amount = amount;
        }

        public BoltOfCloth( Serial serial ) : base( serial )
        {
        }

        public bool Dye( Mobile from, DyeTub sender )
        {
            if ( Deleted ) return false;

            Hue = sender.DyedHue;

            return true;
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

        public bool Scissor( Mobile from, Scissors scissors )
        {
            if ( Deleted || !from.CanSee( this ) ) return false;

            base.ScissorHelper( from, new Cloth(), 50 );

            return true;
        }

        public override void OnSingleClick( Mobile from )
        {
            int number = (Amount == 1) ? 1049122 : 1049121;

            from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, 0x3B2, 3, number, "", (Amount * 50).ToString() ) );
        }
    }
}
