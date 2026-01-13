/* ***************************************************************************
 * ChaosShield.cs
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
using Server.Guilds;

namespace Server.Items
{
    public class ChaosShield : BaseShield
    {
        public override int BasePhysicalResistance{ get{ return 1; } }
        public override int BaseFireResistance{ get{ return 0; } }
        public override int BaseColdResistance{ get{ return 0; } }
        public override int BasePoisonResistance{ get{ return 0; } }
        public override int BaseEnergyResistance{ get{ return 0; } }

        public override int InitMinHits{ get{ return 100; } }
        public override int InitMaxHits{ get{ return 125; } }

        public override int AosStrReq{ get{ return 95; } }

        public override int ArmorBase{ get{ return 32; } }

        [Constructable]
        public ChaosShield() : base( 0x1BC3 )
        {
            if ( !Core.AOS )
                LootType = LootType.Newbied;

            Weight = 5.0;
        }

        public ChaosShield( Serial serial ) : base(serial)
        {
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 );//version
        }

        public override bool OnEquip( Mobile from )
        {
            return Validate( from ) && base.OnEquip( from );
        }

        public override void OnSingleClick( Mobile from )
        {
            if ( Validate( Parent as Mobile ) )
                base.OnSingleClick( from );
        }

        public virtual bool Validate( Mobile m )
        {
            if ( m == null || !m.Player || m.AccessLevel != AccessLevel.Player || Core.AOS )
                return true;

            Guild g = m.Guild as Guild;

            if ( g == null || g.Type != GuildType.Chaos )
            {
                m.FixedEffect( 0x3728, 10, 13 );
                Delete();

                return false;
            }

            return true;
        }
    }
}
