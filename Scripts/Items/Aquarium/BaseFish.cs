/* ***************************************************************************
 * BaseFish.cs
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
using Server.Items;

namespace Server.Items
{
    public class BaseFish : Item
    {
        private static readonly TimeSpan DeathDelay = TimeSpan.FromMinutes( 5 );

        private Timer m_Timer;

        [CommandProperty( AccessLevel.GameMaster )]
        public bool Dead
        {
            get{ return ( ItemID == 0x3B0C ); }
        }

        [Constructable]
        public BaseFish( int itemID ) : base( itemID )
        {
            StartTimer();
        }

        public BaseFish( Serial serial ) : base( serial )
        {
        }

        public virtual void StartTimer()
        {
            if ( m_Timer != null )
                m_Timer.Stop();

            m_Timer = Timer.DelayCall( DeathDelay, new TimerCallback( Kill ) );

            InvalidateProperties();
        }

        public virtual void StopTimer()
        {
            if ( m_Timer != null )
                m_Timer.Stop();

            m_Timer = null;

            InvalidateProperties();
        }

        public override void OnDelete()
        {
            StopTimer();
        }

        public virtual void Kill()
        {
            ItemID = 0x3B0C;
            StopTimer();

            InvalidateProperties();
        }

        public int GetDescription()
        {
            // TODO: This will never return "very unusual dead aquarium creature" due to the way it is killed
            if ( ItemID > 0x3B0F )
                return Dead ? 1074424 : 1074422; // A very unusual [dead/live] aquarium creature
            else if ( Hue != 0 )
                return Dead ? 1074425 : 1074423; // A [dead/live] aquarium creature of unusual color

            return Dead ? 1073623 : 1073622; // A [dead/live] aquarium creature
        }

        public override void GetProperties( ObjectPropertyList list )
        {
            base.GetProperties( list );

            list.Add( GetDescription() );

            if ( !Dead && m_Timer != null )
                list.Add( 1074507 ); // Gasping for air
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

            if ( !( Parent is Aquarium ) && !( Parent is FishBowl ) )
                StartTimer();
        }
    }
}
