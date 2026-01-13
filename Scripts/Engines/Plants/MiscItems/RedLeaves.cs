/* ***************************************************************************
 * RedLeaves.cs
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
using Server.Targeting;

namespace Server.Items
{
    public class RedLeaves : Item
    {
        public override int LabelNumber { get { return 1053123; } } // red leaves

        public override double DefaultWeight
        {
            get { return 0.1; }
        }

        [Constructable]
        public RedLeaves() : this( 1 )
        {
        }

        [Constructable]
        public RedLeaves( int amount ) : base( 0x1E85 )
        {
            Stackable = true;
            Hue = 0x21;
            Amount = amount;
        }

        public RedLeaves( Serial serial ) : base( serial )
        {
        }

        public override void OnDoubleClick( Mobile from )
        {
            if ( !IsChildOf( from.Backpack ) )
            {
                from.SendLocalizedMessage( 1042664 ); // You must have the object in your backpack to use it.
                return;
            }

            from.Target = new InternalTarget( this );
            from.SendLocalizedMessage( 1061907 ); // Choose a book you wish to seal with the wax from the red leaf.
        }

        private class InternalTarget : Target
        {
            private RedLeaves m_RedLeaves;

            public InternalTarget( RedLeaves redLeaves ) : base( 3, false, TargetFlags.None )
            {
                m_RedLeaves = redLeaves;
            }

            protected override void OnTarget( Mobile from, object targeted )
            {
                if ( m_RedLeaves.Deleted )
                    return;

                if ( !m_RedLeaves.IsChildOf( from.Backpack ) )
                {
                    from.SendLocalizedMessage( 1042664 ); // You must have the object in your backpack to use it.
                    return;
                }

                Item item = targeted as Item;

                if ( item == null || !item.IsChildOf( from.Backpack ) )
                {
                    from.SendLocalizedMessage( 1042664 ); // You must have the object in your backpack to use it.
                }
                else if ( !(item is BaseBook) )
                {
                    item.LabelTo( from, 1061911 ); // You can only use red leaves to seal the ink into book pages!
                }
                else
                {
                    BaseBook book = (BaseBook)item;

                    if ( !book.Writable )
                    {
                        book.LabelTo( from, 1061909 ); // The ink in this book has already been sealed.
                    }
                    else
                    {
                        m_RedLeaves.Consume();
                        book.Writable = false;

                        book.LabelTo( from, 1061910 ); // You seal the ink to the page using wax from the red leaf.
                    }
                }
            }
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
