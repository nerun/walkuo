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

namespace Server.Engines.PartySystem
{
    public sealed class PartyEmptyList : Packet
    {
        public PartyEmptyList( Mobile m ) : base( 0xBF )
        {
            EnsureCapacity( 7 );

            m_Stream.Write( (short) 0x0006 );
            m_Stream.Write( (byte) 0x02 );
            m_Stream.Write( (byte) 0 );
            m_Stream.Write( (int) m.Serial );
        }
    }

    public sealed class PartyMemberList : Packet
    {
        public PartyMemberList( Party p ) : base( 0xBF )
        {
            EnsureCapacity( 7 + p.Count*4 );

            m_Stream.Write( (short) 0x0006 );
            m_Stream.Write( (byte) 0x01 );
            m_Stream.Write( (byte) p.Count );

            for ( int i = 0; i < p.Count; ++i )
                m_Stream.Write( (int) p[i].Mobile.Serial );
        }
    }

    public sealed class PartyRemoveMember : Packet
    {
        public PartyRemoveMember( Mobile removed, Party p ) : base( 0xBF )
        {
            EnsureCapacity( 11 + p.Count*4 );

            m_Stream.Write( (short) 0x0006 );
            m_Stream.Write( (byte) 0x02 );
            m_Stream.Write( (byte) p.Count );

            m_Stream.Write( (int) removed.Serial );

            for ( int i = 0; i < p.Count; ++i )
                m_Stream.Write( (int) p[i].Mobile.Serial );
        }
    }

    public sealed class PartyTextMessage : Packet
    {
        public PartyTextMessage( bool toAll, Mobile from, string text ) : base( 0xBF )
        {
            if ( text == null )
                text = "";

            EnsureCapacity( 12 + text.Length*2 );

            m_Stream.Write( (short) 0x0006 );
            m_Stream.Write( (byte) (toAll ? 0x04 : 0x03) );
            m_Stream.Write( (int) from.Serial );
            m_Stream.WriteBigUniNull( text );
        }
    }

    public sealed class PartyInvitation : Packet
    {
        public PartyInvitation( Mobile leader ) : base( 0xBF )
        {
            EnsureCapacity( 10 );

            m_Stream.Write( (short) 0x0006 );
            m_Stream.Write( (byte) 0x07 );
            m_Stream.Write( (int) leader.Serial );
        }
    }
}
