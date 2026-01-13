/* ***************************************************************************
 * MelisandesFermentedWine.cs
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
    public class MelisandesFermentedWine : GreaterExplosionPotion
    {
        public override int LabelNumber{ get{ return 1072114; } } // Melisande's Fermented Wine

        [Constructable]
        public MelisandesFermentedWine()
        {
            Stackable = false;
            ItemID = 0x99B;
            Hue = Utility.RandomList( 0xB, 0xF, 0x48D ); // TODO update
        }

        public MelisandesFermentedWine( Serial serial ) : base( serial )
        {
        }

        public override void Drink( Mobile from )
        {
            if ( MondainsLegacy.CheckML( from ) )
                base.Drink( from );
        }

        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            list.Add( 1074502 ); // It looks explosive.
            list.Add( 1075085 ); // Requirement: Mondain's Legacy
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


