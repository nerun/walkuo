/* ***************************************************************************
 * DecayedCorpse.cs
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
    public class DecayedCorpse : Container
    {
        private Timer m_DecayTimer;
        private DateTime m_DecayTime;

        private static TimeSpan m_DefaultDecayTime = TimeSpan.FromMinutes( 7.0 );

        public DecayedCorpse( string name ) : base( Utility.Random( 0xECA, 9 ) )
        {
            Movable = false;
            Name = name;

            BeginDecay( m_DefaultDecayTime );
        }

        public void BeginDecay( TimeSpan delay )
        {
            if ( m_DecayTimer != null )
                m_DecayTimer.Stop();

            m_DecayTime = DateTime.UtcNow + delay;

            m_DecayTimer = new InternalTimer( this, delay );
            m_DecayTimer.Start();
        }

        public override void OnAfterDelete()
        {
            if ( m_DecayTimer != null )
                m_DecayTimer.Stop();

            m_DecayTimer = null;
        }

        private class InternalTimer : Timer
        {
            private DecayedCorpse m_Corpse;

            public InternalTimer( DecayedCorpse c, TimeSpan delay ) : base( delay )
            {
                m_Corpse = c;
                Priority = TimerPriority.FiveSeconds;
            }

            protected override void OnTick()
            {
                m_Corpse.Delete();
            }
        }

        // Do not display (x items, y stones)
        public override bool CheckContentDisplay( Mobile from )
        {
            return false;
        }

        // Do not display (x items, y stones)
        public override bool DisplaysContent{ get{ return false; } }

        public override void AddNameProperty( ObjectPropertyList list )
        {
            list.Add( 1046414, Name ); // the remains of ~1_NAME~
        }

        public override void OnSingleClick( Mobile from )
        {
            this.LabelTo( from, 1046414, Name ); // the remains of ~1_NAME~
        }

        public DecayedCorpse( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version

            writer.Write( m_DecayTimer != null );

            if ( m_DecayTimer != null )
                writer.WriteDeltaTime( m_DecayTime );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                {
                    BeginDecay( m_DefaultDecayTime );

                    break;
                }
                case 1:
                {
                    if ( reader.ReadBool() )
                        BeginDecay( reader.ReadDeltaTime() - DateTime.UtcNow );

                    break;
                }
            }
        }
    }
}
