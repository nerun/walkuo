/* ***************************************************************************
 * CheckerBoard.cs
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
using System.Collections;

namespace Server.Items
{
    public class CheckerBoard : BaseBoard
    {
        public override int LabelNumber{ get{ return 1016449; } } // a checker board

        [Constructable]
        public CheckerBoard() : base( 0xFA6 )
        {
        }

        public override void CreatePieces()
        {
            for ( int i = 0; i < 4; i++ )
            {
                CreatePiece( new PieceWhiteChecker( this ), ( 50 * i ) + 45, 25 );
                CreatePiece( new PieceWhiteChecker( this ), ( 50 * i ) + 70, 50 );
                CreatePiece( new PieceWhiteChecker( this ), ( 50 * i ) + 45, 75 );
                CreatePiece( new PieceBlackChecker( this ), ( 50 * i ) + 70, 150 );
                CreatePiece( new PieceBlackChecker( this ), ( 50 * i ) + 45, 175 );
                CreatePiece( new PieceBlackChecker( this ), ( 50 * i ) + 70, 200 );
            }
        }

        public CheckerBoard( Serial serial ) : base( serial )
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
