/* ***************************************************************************
 * ChaosGuard.cs
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
using Server.Misc;
using Server.Items;
using Server.Guilds;

namespace Server.Mobiles
{
    public class ChaosGuard : BaseShieldGuard
    {
        public override int Keyword{ get{ return 0x22; } } // *chaos shield*
        public override BaseShield Shield{ get{ return new ChaosShield(); } }
        public override int SignupNumber{ get{ return 1007140; } } // Sign up with a guild of chaos if thou art interested.
        public override GuildType Type{ get{ return GuildType.Chaos; } }

        public override bool BardImmune{ get{ return true; } } 

        [Constructable]
        public ChaosGuard()
        {
        }

        public ChaosGuard( Serial serial ) : base( serial )
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
