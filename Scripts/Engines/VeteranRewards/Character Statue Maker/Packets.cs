/* ***************************************************************************
 * Packets.cs
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

namespace Server.Network
{
	public class UpdateStatueAnimation : Packet
	{
		public UpdateStatueAnimation( Mobile m, int status, int animation, int frame ) : base( 0xBF, 17 )
		{
			m_Stream.Write( (short) 0x11 );
			m_Stream.Write( (short) 0x19 );
			m_Stream.Write( (byte) 0x5 );
			m_Stream.Write( (int) m.Serial );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) 0xFF );
			m_Stream.Write( (byte) status );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) animation );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) frame );
		}
	}
}
