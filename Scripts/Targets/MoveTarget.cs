/* ***************************************************************************
 * MoveTarget.cs
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
using Server.Targeting;
using Server.Commands;
using Server.Commands.Generic;

namespace Server.Targets
{
    public class MoveTarget : Target
    {
        private object m_Object;

        public MoveTarget( object o ) : base( -1, true, TargetFlags.None )
        {
            m_Object = o;
        }

        protected override void OnTarget( Mobile from, object o )
        {
            IPoint3D p = o as IPoint3D;

            if ( p != null )
            {
                if ( !BaseCommand.IsAccessible( from, m_Object ) )
                {
                    from.SendMessage( "That is not accessible." );
                    return;
                }

                if ( p is Item )
                    p = ((Item)p).GetWorldTop();

                CommandLogging.WriteLine( from, "{0} {1} moving {2} to {3}", from.AccessLevel, CommandLogging.Format( from ), CommandLogging.Format( m_Object ), new Point3D( p ) );

                if ( m_Object is Item )
                {
                    Item item = (Item)m_Object;

                    if ( !item.Deleted )
                        item.MoveToWorld( new Point3D( p ), from.Map );
                }
                else if ( m_Object is Mobile )
                {
                    Mobile m = (Mobile)m_Object;

                    if ( !m.Deleted )
                        m.MoveToWorld( new Point3D( p ), from.Map );
                }
            }
        }
    }
}
