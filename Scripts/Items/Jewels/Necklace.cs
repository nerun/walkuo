/* ***************************************************************************
 * Necklace.cs
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
    public abstract class BaseNecklace : BaseJewel
    {
        public override int BaseGemTypeNumber{ get{ return 1044241; } } // star sapphire necklace

        public BaseNecklace( int itemID ) : base( itemID, Layer.Neck )
        {
        }

        public BaseNecklace( Serial serial ) : base( serial )
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

    public class Necklace : BaseNecklace
    {
        [Constructable]
        public Necklace() : base( 0x1085 )
        {
            Weight = 0.1;
        }

        public Necklace( Serial serial ) : base( serial )
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

    public class GoldNecklace : BaseNecklace
    {
        [Constructable]
        public GoldNecklace() : base( 0x1088 )
        {
            Weight = 0.1;
        }

        public GoldNecklace( Serial serial ) : base( serial )
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

    public class GoldBeadNecklace : BaseNecklace
    {
        [Constructable]
        public GoldBeadNecklace() : base( 0x1089 )
        {
            Weight = 0.1;
        }

        public GoldBeadNecklace( Serial serial ) : base( serial )
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


    public class SilverNecklace : BaseNecklace
    {
        [Constructable]
        public SilverNecklace() : base( 0x1F08 )
        {
            Weight = 0.1;
        }

        public SilverNecklace( Serial serial ) : base( serial )
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

    public class SilverBeadNecklace : BaseNecklace
    {
        [Constructable]
        public SilverBeadNecklace() : base( 0x1F05 )
        {
            Weight = 0.1;
        }

        public SilverBeadNecklace( Serial serial ) : base( serial )
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
