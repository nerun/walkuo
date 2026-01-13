/* ***************************************************************************
 * BarrelParts.cs
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

namespace Server.Items
{
    public class BarrelLid : Item
    {
        [Constructable]
        public BarrelLid() : base(0x1DB8)
        {
            Weight = 2;
        }

        public BarrelLid(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    [FlipableAttribute(0x1EB1, 0x1EB2, 0x1EB3, 0x1EB4)]
    public class BarrelStaves : Item
    {
        [Constructable]
        public BarrelStaves() : base(0x1EB1)
        {
            Weight = 1;
        }

        public BarrelStaves(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class BarrelHoops : Item
    {
        public override int LabelNumber { get { return 1011228; } } // Barrel hoops

        [Constructable]
        public BarrelHoops() : base(0x1DB7)
        {
            Weight = 5;
        }

        public BarrelHoops(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class BarrelTap : Item
    {
        [Constructable]
        public BarrelTap() : base(0x1004)
        {
            Weight = 1;
        }

        public BarrelTap(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
