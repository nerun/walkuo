/* ***************************************************************************
 * BaseHealPotion.cs
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

namespace Server.Items
{
    public abstract class BaseHealPotion : BasePotion
    {
        public abstract int MinHeal { get; }
        public abstract int MaxHeal { get; }
        public abstract double Delay { get; }

        public BaseHealPotion( PotionEffect effect ) : base( 0xF0C, effect )
        {
        }

        public BaseHealPotion( Serial serial ) : base( serial )
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

        public void DoHeal( Mobile from )
        {
            int min = Scale( from, MinHeal );
            int max = Scale( from, MaxHeal );

            from.Heal( Utility.RandomMinMax( min, max ) );
        }

        public override void Drink( Mobile from )
        {
            if ( from.Hits < from.HitsMax )
            {
                if ( from.Poisoned || MortalStrike.IsWounded( from ) )
                {
                    from.LocalOverheadMessage( MessageType.Regular, 0x22, 1005000 ); // You can not heal yourself in your current state.
                }
                else
                {
                    if ( from.BeginAction( typeof( BaseHealPotion ) ) )
                    {
                        DoHeal( from );

                        BasePotion.PlayDrinkEffect( from );

                        if ( !Engines.ConPVP.DuelContext.IsFreeConsume( from ) )
                            this.Consume();

                        Timer.DelayCall( TimeSpan.FromSeconds( Delay ), new TimerStateCallback( ReleaseHealLock ), from );
                    }
                    else
                    {
                        from.LocalOverheadMessage( MessageType.Regular, 0x22, 500235 ); // You must wait 10 seconds before using another healing potion.
                    }
                }
            }
            else
            {
                from.SendLocalizedMessage( 1049547 ); // You decide against drinking this potion, as you are already at full health.
            }
        }

        private static void ReleaseHealLock( object state )
        {
            ((Mobile)state).EndAction( typeof( BaseHealPotion ) );
        }
    }
}
