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
using Server.Network;

namespace Server.Engines.Chat
{
	public sealed class ChatMessagePacket : Packet
	{
		public ChatMessagePacket( Mobile who, int number, string param1, string param2 ) : base( 0xB2 )
		{
			if ( param1 == null )
				param1 = String.Empty;

			if ( param2 == null )
				param2 = String.Empty;

			EnsureCapacity( 13 + ((param1.Length + param2.Length) * 2) );

			m_Stream.Write( (ushort) (number - 20) );

			if ( who != null )
				m_Stream.WriteAsciiFixed( who.Language, 4 );
			else
				m_Stream.Write( (int) 0 );

			m_Stream.WriteBigUniNull( param1 );
			m_Stream.WriteBigUniNull( param2 );
		}
	}
}
