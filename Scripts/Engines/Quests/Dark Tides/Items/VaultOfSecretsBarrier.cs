/* ***************************************************************************
 * VaultOfSecretsBarrier.cs
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
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Engines.Quests.Necro;

namespace Server.Engines.Quests.Necro
{
    public class VaultOfSecretsBarrier : Item
    {
        [Constructable]
        public VaultOfSecretsBarrier() : base( 0x49E )
        {
            Movable = false;
            Visible = false;
        }

        public override bool OnMoveOver( Mobile m )
        {
            if ( m.AccessLevel > AccessLevel.Player )
                return true;

            PlayerMobile pm = m as PlayerMobile;

            if ( pm != null && pm.Profession == 4 )
            {
                m.SendLocalizedMessage( 1060188, "", 0x24 ); // The wicked may not enter!
                return false;
            }

            return base.OnMoveOver( m );
        }

        public VaultOfSecretsBarrier( Serial serial ) : base( serial )
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
