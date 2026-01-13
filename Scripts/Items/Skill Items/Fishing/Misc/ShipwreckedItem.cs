/* ***************************************************************************
 * ShipwreckedItem.cs
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
    public interface IShipwreckedItem
    {
        bool IsShipwreckedItem { get; set; }
    }

    public class ShipwreckedItem : Item, IDyable, IShipwreckedItem
    {
        public ShipwreckedItem( int itemID ) : base( itemID )
        {
            int weight = this.ItemData.Weight;

            if ( weight >= 255 )
                weight = 1;

            this.Weight = weight;
        }

        public override void OnSingleClick( Mobile from )
        {
            this.LabelTo( from, 1050039, String.Format( "#{0}\t#1041645", LabelNumber ) );
        }

        public override void AddNameProperties( ObjectPropertyList list )
        {
            base.AddNameProperties( list );
            list.Add( 1041645 ); // recovered from a shipwreck
        }

        public ShipwreckedItem( Serial serial ) : base( serial )
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

        public bool Dye( Mobile from, DyeTub sender )
        {
            if ( Deleted )
                return false;

            if ( ItemID >= 0x13A4 && ItemID <= 0x13AE )
            {
                Hue = sender.DyedHue;
                return true;
            }

            from.SendLocalizedMessage( sender.FailMessage );
            return false;
        }

        #region IShipwreckedItem Members

        public bool IsShipwreckedItem
        {
            get
            {
                return true;    //It's a ShipwreckedItem item.  'Course it's gonna be a Shipwreckeditem
            }
            set
            {
            }
        }

        #endregion
    }
}
