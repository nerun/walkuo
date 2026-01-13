/* ***************************************************************************
 * DynamicTeleporter.cs
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
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public abstract class DynamicTeleporter : Item
    {
        public override int LabelNumber{ get{ return 1049382; } } // a magical teleporter

        public DynamicTeleporter() : this( 0x1822, 0x482 )
        {
        }

        public DynamicTeleporter( int itemID, int hue ) : base( itemID )
        {
            Movable = false;
            Hue = hue;
        }

        public abstract bool GetDestination( PlayerMobile player, ref Point3D loc, ref Map map );

        public virtual int NotWorkingMessage{ get{ return 500309; } } // Nothing Happens.

        public override bool OnMoveOver( Mobile m )
        {
            PlayerMobile pm = m as PlayerMobile;

            if ( pm != null )
            {
                Point3D loc = Point3D.Zero;
                Map map = null;

                if ( GetDestination( pm, ref loc, ref map ) )
                {
                    BaseCreature.TeleportPets( pm, loc, map );

                    pm.PlaySound( 0x1FE );
                    pm.MoveToWorld( loc, map );

                    return false;
                }
                else
                {
                    pm.SendLocalizedMessage( this.NotWorkingMessage );
                }
            }

            return base.OnMoveOver( m );
        }

        public DynamicTeleporter( Serial serial ) : base( serial )
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
    }
}
