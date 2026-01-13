/* ***************************************************************************
 * RunicSewingKit.cs
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
using Server.Engines.Craft;

namespace Server.Items
{
    public class RunicSewingKit : BaseRunicTool
    {
        public override CraftSystem CraftSystem{ get{ return DefTailoring.CraftSystem; } }

        public override void AddNameProperty( ObjectPropertyList list )
        {
            string v = " ";

            if ( !CraftResources.IsStandard( Resource ) )
            {
                int num = CraftResources.GetLocalizationNumber( Resource );

                if ( num > 0 )
                    v = String.Format( "#{0}", num );
                else
                    v = CraftResources.GetName( Resource );
            }

            list.Add( 1061119, v ); // ~1_LEATHER_TYPE~ runic sewing kit
        }

        public override void OnSingleClick( Mobile from )
        {
            string v = " ";

            if ( !CraftResources.IsStandard( Resource ) )
            {
                int num = CraftResources.GetLocalizationNumber( Resource );

                if ( num > 0 )
                    v = String.Format( "#{0}", num );
                else
                    v = CraftResources.GetName( Resource );
            }

            LabelTo( from, 1061119, v ); // ~1_LEATHER_TYPE~ runic sewing kit
        }

        [Constructable]
        public RunicSewingKit( CraftResource resource ) : base( resource, 0xF9D )
        {
            Weight = 2.0;
            Hue = CraftResources.GetHue( resource );
        }

        [Constructable]
        public RunicSewingKit( CraftResource resource, int uses ) : base( resource, uses, 0xF9D )
        {
            Weight = 2.0;
            Hue = CraftResources.GetHue( resource );
        }

        public RunicSewingKit( Serial serial ) : base( serial )
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

            if ( ItemID == 0x13E4 || ItemID == 0x13E3 )
                ItemID = 0xF9D;
        }
    }
}
