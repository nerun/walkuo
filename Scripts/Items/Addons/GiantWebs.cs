/* ***************************************************************************
 * GiantWebs.cs
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
using System.Text;
using System.Net;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class GiantWeb1 : BaseAddon
    {
        [Constructable]
        public GiantWeb1()
        {
            int itemID = 4280;
            int count = 5;
            bool leftToRight = false;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb1( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }

    public class GiantWeb2 : BaseAddon
    {
        [Constructable]
        public GiantWeb2()
        {
            int itemID = 4285;
            int count = 5;
            bool leftToRight = true;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb2( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }

    public class GiantWeb3 : BaseAddon
    {
        [Constructable]
        public GiantWeb3()
        {
            int itemID = 4290;
            int count = 4;
            bool leftToRight = true;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb3( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }

    public class GiantWeb4 : BaseAddon
    {
        [Constructable]
        public GiantWeb4()
        {
            int itemID = 4294;
            int count = 4;
            bool leftToRight = false;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb4( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }

    public class GiantWeb5 : BaseAddon
    {
        [Constructable]
        public GiantWeb5()
        {
            int itemID = 4298;
            int count = 4;
            bool leftToRight = true;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb5( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }

    public class GiantWeb6 : BaseAddon
    {
        [Constructable]
        public GiantWeb6()
        {
            int itemID = 4302;
            int count = 4;
            bool leftToRight = false;

            for ( int i = 0; i < count; ++i )
                AddComponent( new AddonComponent( itemID++ ), leftToRight ? i : count - 1 - i, -( leftToRight ? i : count - 1 - i ), 0 );
        }

        public GiantWeb6( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (byte) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadByte();
        }
    }
}
