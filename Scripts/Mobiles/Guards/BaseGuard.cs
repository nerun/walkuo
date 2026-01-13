/* ***************************************************************************
 * BaseGuard.cs
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
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    public abstract class BaseGuard : Mobile
    {
        public static void Spawn( Mobile caller, Mobile target )
        {
            Spawn( caller, target, 1, false );
        }

        public static void Spawn( Mobile caller, Mobile target, int amount, bool onlyAdditional )
        {
            if ( target == null || target.Deleted )
                return;

            foreach ( Mobile m in target.GetMobilesInRange( 15 ) )
            {
                if ( m is BaseGuard )
                {
                    BaseGuard g = (BaseGuard)m;

                    if ( g.Focus == null ) // idling
                    {
                        g.Focus = target;

                        --amount;
                    }
                    else if ( g.Focus == target && !onlyAdditional )
                    {
                        --amount;
                    }
                }
            }

            while ( amount-- > 0 )
                caller.Region.MakeGuard( target );
        }

        public BaseGuard( Mobile target )
        {
            if ( target != null )
            {
                Location = target.Location;
                Map = target.Map;

                Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );
            }
        }

        public BaseGuard( Serial serial ) : base( serial )
        {
        }

        public override bool OnBeforeDeath()
        {
            Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );

            PlaySound( 0x1FE );

            Delete();

            return false;
        }

        public abstract Mobile Focus{ get; set; }

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
