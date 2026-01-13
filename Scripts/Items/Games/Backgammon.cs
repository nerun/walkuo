/* ***************************************************************************
 * Backgammon.cs
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
    [Flipable( 0xE1C, 0xFAD )]
    public class Backgammon : BaseBoard
    {
        [Constructable]
        public Backgammon() : base( 0xE1C )
        {
        }

        public override void CreatePieces()
        {
            for ( int i = 0; i < 5; i++ )
            {
                CreatePiece( new PieceWhiteChecker( this ), 42, ( 17 * i ) + 6 );
                CreatePiece( new PieceBlackChecker( this ), 42, ( 17 * i ) + 119 );

                CreatePiece( new PieceBlackChecker( this ), 142, ( 17 * i ) + 6 );
                CreatePiece( new PieceWhiteChecker( this ), 142, ( 17 * i ) + 119 );
            }

            for ( int i = 0; i < 3; i++ )
            {
                CreatePiece( new PieceBlackChecker( this ), 108, ( 17 * i ) + 6 );
                CreatePiece( new PieceWhiteChecker( this ), 108, ( 17 * i ) + 153 );
            }

            for ( int i = 0; i < 2; i++ )
            {
                CreatePiece( new PieceWhiteChecker( this ), 223, ( 17 * i ) + 6 );
                CreatePiece( new PieceBlackChecker( this ), 223, ( 17 * i ) + 170 );
            }
        }

        public Backgammon( Serial serial ) : base( serial )
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
