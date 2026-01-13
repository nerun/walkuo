/* ***************************************************************************
 * TinkerTools.cs
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
using Server.Engines.Craft;

namespace Server.Items
{
    [Flipable( 0x1EB8, 0x1EB9 )]
    public class TinkerTools : BaseTool
    {
        public override CraftSystem CraftSystem{ get{ return DefTinkering.CraftSystem; } }

        [Constructable]
        public TinkerTools() : base( 0x1EB8 )
        {
            Weight = 1.0;
        }

        [Constructable]
        public TinkerTools( int uses ) : base( uses, 0x1EB8 )
        {
            Weight = 1.0;
        }

        public TinkerTools( Serial serial ) : base( serial )
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

    public class TinkersTools : BaseTool
    {
        public override CraftSystem CraftSystem { get { return DefTinkering.CraftSystem; } }

        [Constructable]
        public TinkersTools()
            : base(0x1EBC)
        {
            Weight = 1.0;
        }

        [Constructable]
        public TinkersTools(int uses)
            : base(uses, 0x1EBC)
        {
            Weight = 1.0;
        }

        public TinkersTools(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
