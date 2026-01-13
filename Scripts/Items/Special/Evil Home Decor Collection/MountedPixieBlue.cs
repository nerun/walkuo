/* ***************************************************************************
 * MountedPixieBlue.cs
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
    [Flipable( 0x2A75, 0x2A76 )]
    public class MountedPixieBlueComponent : AddonComponent
    {
        public override int LabelNumber { get { return 1074482; } } // Mounted pixie

        public MountedPixieBlueComponent() : base( 0x2A75 )
        {
        }

        public MountedPixieBlueComponent( Serial serial ) : base( serial )
        {
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( Utility.InRange( Location, from.Location, 2 ) )
                Effects.PlaySound( Location, Map, Utility.RandomMinMax( 0x55C, 0x55E ) );
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

    public class MountedPixieBlueAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new MountedPixieBlueDeed(); } }

        public MountedPixieBlueAddon() : base()
        {
            AddComponent( new MountedPixieBlueComponent(), 0, 0, 0 );
        }

        public MountedPixieBlueAddon( Serial serial ) : base( serial )
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

    public class MountedPixieBlueDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new MountedPixieBlueAddon(); } }
        public override int LabelNumber { get { return 1074482; } } // Mounted pixie

        [Constructable]
        public MountedPixieBlueDeed() : base()
        {
            LootType = LootType.Blessed;
        }

        public MountedPixieBlueDeed( Serial serial ) : base( serial )
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
