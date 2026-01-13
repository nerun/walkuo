/* ***************************************************************************
 * PaintedImage.cs
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
using Server.Gumps;
using Server.Network;

namespace Server.Engines.Quests.Collector
{
    public class PaintedImage : Item
    {
        private ImageType m_Image;

        [CommandProperty( AccessLevel.GameMaster )]
        public ImageType Image
        {
            get { return m_Image; }
            set { m_Image = value; InvalidateProperties(); } 
        }

        [Constructable]
        public PaintedImage( ImageType image ) : base( 0xFF3 )
        {
            Weight = 1.0;
            Hue = 0x8FD;

            m_Image = image;
        }

        public override void AddNameProperty( ObjectPropertyList list )
        {
            ImageTypeInfo info = ImageTypeInfo.Get( m_Image );
            list.Add( 1060847, "#1055126\t#" + info.Name ); // a painted image of:
        }

        public override void OnSingleClick( Mobile from )
        {
            ImageTypeInfo info = ImageTypeInfo.Get( m_Image );
            LabelTo( from, 1060847, "#1055126\t#" + info.Name ); // a painted image of:
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( !from.InRange( GetWorldLocation(), 2 ) )
            {
                from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
                return;
            }

            from.SendGump( new InternalGump( m_Image ) );
        }

        private class InternalGump : Gump
        {
            public InternalGump( ImageType image ) : base( 75, 25 )
            {
                ImageTypeInfo info = ImageTypeInfo.Get( image );

                AddBackground( 45, 20, 100, 100, 0xA3C );
                AddBackground( 52, 29, 86, 82, 0xBB8 );

                AddItem( info.X, info.Y, info.Figurine );
            }
        }

        public PaintedImage( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version

            writer.WriteEncodedInt( (int) m_Image );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            m_Image = (ImageType) reader.ReadEncodedInt();
        }
    }
}
