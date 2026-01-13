/* ***************************************************************************
 * ResGate.cs
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
using Server.Gumps;

namespace Server.Items
{
    public class ResGate : Item
    {
        public override string DefaultName
        {
            get { return "a resurrection gate"; }
        }

        [Constructable]
        public ResGate() : base( 0xF6C )
        {
            Movable = false;
            Hue = 0x2D1;
            Light = LightType.Circle300;
        }

        public ResGate( Serial serial ) : base( serial )
        {
        }

        public override bool OnMoveOver( Mobile m )
        {
            if ( !m.Alive && m.Map != null && m.Map.CanFit( m.Location, 16, false, false ) )
            {
                m.PlaySound( 0x214 );
                m.FixedEffect( 0x376A, 10, 16 );

                m.CloseGump( typeof( ResurrectGump ) );
                m.SendGump( new ResurrectGump( m ) );
            }
            else
            {
                m.SendLocalizedMessage( 502391 ); // Thou can not be resurrected there!
            }

            return false;
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
