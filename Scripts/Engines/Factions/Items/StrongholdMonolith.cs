/* ***************************************************************************
 * StrongholdMonolith.cs
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

namespace Server.Factions
{
    public class StrongholdMonolith : BaseMonolith
    {
        public override int DefaultLabelNumber{ get{ return 1041042; } } // A Faction Sigil Monolith

        public override void OnTownChanged()
        {
            AssignName( Town == null ? null : Town.Definition.StrongholdMonolithName );
        }

        public StrongholdMonolith() : this( null, null )
        {
        }

        public StrongholdMonolith( Town town, Faction faction ) : base( town, faction )
        {
        }

        public StrongholdMonolith( Serial serial ) : base( serial )
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
