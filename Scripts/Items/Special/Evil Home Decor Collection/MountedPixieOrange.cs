/* ***************************************************************************
 * MountedPixieOrange.cs
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
    [Flipable( 0x2A73, 0x2A74 )]
    public class MountedPixieOrangeComponent : AddonComponent
    {
        public override int LabelNumber { get { return 1074482; } } // Mounted pixie

        public MountedPixieOrangeComponent() : base( 0x2A73 )
        {
        }

        public MountedPixieOrangeComponent( Serial serial ) : base( serial )
        {
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( Utility.InRange( Location, from.Location, 2 ) )
                Effects.PlaySound( Location, Map, Utility.RandomMinMax( 0x558, 0x55B ) );
            else
                from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }

    public class MountedPixieOrangeAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new MountedPixieOrangeDeed(); } }

        public MountedPixieOrangeAddon() : base()
        {
            AddComponent( new MountedPixieOrangeComponent(), 0, 0, 0 );
        }

        public MountedPixieOrangeAddon( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }

    public class MountedPixieOrangeDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new MountedPixieOrangeAddon(); } }
        public override int LabelNumber { get { return 1074482; } } // Mounted pixie

        [Constructable]
        public MountedPixieOrangeDeed() : base()
        {
            LootType = LootType.Blessed;
        }

        public MountedPixieOrangeDeed( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
