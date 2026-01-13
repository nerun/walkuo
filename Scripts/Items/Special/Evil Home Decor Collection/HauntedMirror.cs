/* ***************************************************************************
 * HauntedMirror.cs
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
    [Flipable( 0x2A7B, 0x2A7D )]
    public class HaunterMirrorComponent : AddonComponent
    {
        public override int LabelNumber { get { return 1074800; } } // Haunted Mirror
        public override bool HandlesOnMovement { get { return true; } }

        public HaunterMirrorComponent() : base( 0x2A7B )
        {
        }

        public HaunterMirrorComponent( Serial serial ) : base( serial )
        {
        }

        public override void OnMovement( Mobile m, Point3D old )
        {
            base.OnMovement( m, old );

            if ( m.Alive && m.Player && ( m.AccessLevel == AccessLevel.Player || !m.Hidden ) )
            {
                if ( !Utility.InRange( old, Location, 2 ) && Utility.InRange( m.Location, Location, 2 ) )
                {
                    if ( ItemID == 0x2A7B || ItemID == 0x2A7D )
                    {
                        Effects.PlaySound( Location, Map, Utility.RandomMinMax( 0x551, 0x553 ) );
                        ItemID += 1;
                    }
                }
                else if ( Utility.InRange( old, Location, 2 ) && !Utility.InRange( m.Location, Location, 2 ) )
                {
                    if ( ItemID == 0x2A7C || ItemID == 0x2A7E )
                        ItemID -= 1;
                }
            }
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

    public class HaunterMirrorAddon : BaseAddon
    {
        public override BaseAddonDeed Deed { get { return new HaunterMirrorDeed(); } }

        [Constructable]
        public HaunterMirrorAddon() : base()
        {
            AddComponent( new HaunterMirrorComponent(), 0, 0, 0 );
        }

        public HaunterMirrorAddon( Serial serial ) : base( serial )
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

    public class HaunterMirrorDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new HaunterMirrorAddon(); } }
        public override int LabelNumber { get { return 1074800; } } // Haunted Mirror

        [Constructable]
        public HaunterMirrorDeed() : base()
        {
            LootType = LootType.Blessed;
        }

        public HaunterMirrorDeed( Serial serial ) : base( serial )
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
