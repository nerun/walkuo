/* ***************************************************************************
 * RedVelvetGiftBox.cs
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

/*
 * Simply add this box with param true to create the entire valentine's 2007 package.
 * Adding it with no params or false will create an empty box.
 */

namespace Server.Items
{
    public class RedVelvetGiftBox : BaseContainer
    {
        public override int DefaultGumpID { get { return 0x3f; } }
        public override int LabelNumber { get { return 1077596; } } // A Red Velvet Box

        [Constructable]
        public RedVelvetGiftBox()
            : this( false )
        {
        }

        [Constructable]
        public RedVelvetGiftBox( bool fill )
            : base( 0xE7A )
        {
            Hue = 0x20;

            if (fill)
            {
                for (int i = 0; i < 5; i++)
                {
                    AddToBox(new ValentinesCardSouth(), new Point3D(60 + (i * 10), 47, 0));
                    AddToBox(new ValentinesCardEast(), new Point3D(20 + (i * 10), 72, 0));
                }
                AddToBox(new Bacon(), new Point3D(90, 85, 0));
                AddToBox(new RoseInAVase(), new Point3D(130, 55, 0));
            }
        }

        public virtual void AddToBox(Item item, Point3D loc)
        {
            DropItem(item);
            item.Location = loc;
        }

        public RedVelvetGiftBox( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
