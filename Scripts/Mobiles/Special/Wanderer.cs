/* ***************************************************************************
 * Wanderer.cs
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

namespace Server.Mobiles
{
    public class Wanderer : Mobile
    {
        private Timer m_Timer;

        [Constructable]
        public Wanderer()
        {
            this.Name = "Me";
            this.Body = 0x1;
            this.AccessLevel = AccessLevel.Counselor;

            m_Timer = new InternalTimer( this );
            m_Timer.Start();
        }

        public Wanderer( Serial serial ) : base( serial )
        {
            m_Timer = new InternalTimer( this );
            m_Timer.Start();
        }

        public override void OnDelete()
        {
            m_Timer.Stop();

            base.OnDelete();
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

        private class InternalTimer : Timer
        {
            private Wanderer m_Owner;
            private int m_Count = 0;

            public InternalTimer( Wanderer owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
            {
                m_Owner = owner;
            }

            protected override void OnTick()
            {
                if ( (m_Count++ & 0x3) == 0 )
                {
                    m_Owner.Direction = (Direction)(Utility.Random( 8 ) | 0x80);
                }

                m_Owner.Move( m_Owner.Direction );
            }
        }
    }
}
