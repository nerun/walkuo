/* ***************************************************************************
 * InvisibilityPotion.cs
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
using Server;

namespace Server.Items
{
    public class InvisibilityPotion : BasePotion
    {        
        public override int LabelNumber{ get{ return 1072941; } } // Potion of Invisibility

        [Constructable]
        public InvisibilityPotion() : base( 0xF0A, PotionEffect.Invisibility )
        {
            Hue = 0x48D;
        }

        public InvisibilityPotion( Serial serial ) : base( serial )
        {
        }
        
        public override void Drink( Mobile from )
        {
            if ( from.Hidden )
            {
                from.SendLocalizedMessage( 1073185 ); // You are already unseen.
                return;
            }
            
            if ( HasTimer( from ) )
            {
                from.SendLocalizedMessage( 1073186 ); // An invisibility potion is already taking effect on your person.
                return;
            }
            
            Consume();
            m_Table[ from ] = Timer.DelayCall( TimeSpan.FromSeconds( 2 ), new TimerStateCallback( Hide_Callback ), from );            
            PlayDrinkEffect( from );
        }
        
        private static void Hide_Callback( object obj )
        {
            if ( obj is Mobile )
                Hide( (Mobile) obj );
        }
        
        public static void Hide( Mobile m )
        {
            Effects.SendLocationParticles( EffectItem.Create( new Point3D( m.X, m.Y, m.Z + 16 ), m.Map, EffectItem.DefaultDuration ), 0x376A, 10, 15, 5045 );
            m.PlaySound( 0x3C4 );
            
            m.Hidden = true;
        
            BuffInfo.RemoveBuff( m, BuffIcon.HidingAndOrStealth );
            BuffInfo.AddBuff( m, new BuffInfo( BuffIcon.Invisibility, 1075825 ) );    //Invisibility/Invisible
            
            RemoveTimer( m );
            
            Timer.DelayCall( TimeSpan.FromSeconds( 30 ), new TimerStateCallback( EndHide_Callback ), m );
        }
        
        private static void EndHide_Callback( object obj )
        {
            if ( obj is Mobile )
                EndHide( (Mobile) obj );
        }
        
        public static void EndHide( Mobile m )
        {
            m.RevealingAction();
            RemoveTimer( m );
        }
        
        private static Hashtable m_Table = new Hashtable();

        public static bool HasTimer( Mobile m )
        {
            return m_Table[ m ] != null;
        }

        public static void RemoveTimer( Mobile m )
        {
            Timer t = (Timer) m_Table[ m ];

            if ( t != null )
            {
                t.Stop();
                m_Table.Remove( m );
            }
        }
        
        public static void Iterrupt( Mobile m )
        {
            m.SendLocalizedMessage( 1073187 ); // The invisibility effect is interrupted.
            RemoveTimer( m );            
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
