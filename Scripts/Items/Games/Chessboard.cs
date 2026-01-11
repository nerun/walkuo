/* ***************************************************************************
 * Chessboard.cs
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
	public class Chessboard : BaseBoard
	{
		public override int LabelNumber{ get{ return 1016450; } } // a chessboard

		[Constructable]
		public Chessboard() : base( 0xFA6 )
		{
		}

		public override void CreatePieces()
		{
			for ( int i = 0; i < 8; i++ )
			{
				CreatePiece( new PieceBlackPawn( this ), 67, ( 25 * i ) + 17 );
				CreatePiece( new PieceWhitePawn( this ), 192, ( 25 * i ) + 17 );
			}

			// Rook
			CreatePiece( new PieceBlackRook( this ), 42, 5 );
			CreatePiece( new PieceBlackRook( this ), 42, 180 );

			CreatePiece( new PieceWhiteRook( this ), 216, 5 );
			CreatePiece( new PieceWhiteRook( this ), 216, 180 );

			// Knight
			CreatePiece( new PieceBlackKnight( this ), 42, 30 );
			CreatePiece( new PieceBlackKnight( this ), 42, 155 );

			CreatePiece( new PieceWhiteKnight( this ), 216, 30 );
			CreatePiece( new PieceWhiteKnight( this ), 216, 155 );
					
			// Bishop
			CreatePiece( new PieceBlackBishop( this ), 42, 55 );
			CreatePiece( new PieceBlackBishop( this ), 42, 130 );

			CreatePiece( new PieceWhiteBishop( this ), 216, 55 );
			CreatePiece( new PieceWhiteBishop( this ), 216, 130 );
			
			// Queen
			CreatePiece( new PieceBlackQueen( this ), 42, 105 );
			CreatePiece( new PieceWhiteQueen( this ), 216, 105 );

			// King
			CreatePiece( new PieceBlackKing( this ), 42, 80 );
			CreatePiece( new PieceWhiteKing( this ), 216, 80 );
		}

		public Chessboard( Serial serial ) : base( serial )
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
