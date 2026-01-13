/* ***************************************************************************
 * Blood.cs
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
    public class Blood : Item
    {
        [Constructable]
        public Blood() : this( Utility.RandomList( 0x1645, 0x122A, 0x122B, 0x122C, 0x122D, 0x122E, 0x122F ))
        {
        }

        [Constructable]
        public Blood( int itemID ) : base( itemID )
        {
            Movable = false;

            new InternalTimer( this ).Start();
        }

        public Blood( Serial serial ) : base( serial )
        {
            new InternalTimer( this ).Start();
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
            private Item m_Blood;

            public InternalTimer( Item blood ) : base( TimeSpan.FromSeconds( 5.0 ) )
            {
                Priority = TimerPriority.OneSecond;

                m_Blood = blood;
            }

            protected override void OnTick()
            {
                m_Blood.Delete();
            }
        }
    }
}
