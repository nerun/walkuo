/* ***************************************************************************
 * FishingPole.cs
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
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Network;

namespace Server.Items
{
    public class FishingPole : Item
    {
        [Constructable]
        public FishingPole() : base( 0x0DC0 )
        {
            Layer = Layer.TwoHanded;
            Weight = 8.0;
        }

        public override void OnDoubleClick( Mobile from )
        {
            Point3D loc = GetWorldLocation();

            if ( !from.InLOS( loc ) || !from.InRange( loc, 2 ) )
                from.LocalOverheadMessage( MessageType.Regular, 0x3E9, 1019045 ); // I can't reach that
            else
                Fishing.System.BeginHarvesting( from, this );
        }

        public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
        {
            base.GetContextMenuEntries( from, list );

            BaseHarvestTool.AddContextMenuEntries( from, this, list, Fishing.System );
        }

        public override bool CheckConflictingLayer( Mobile m, Item item, Layer layer )
        {
            if ( base.CheckConflictingLayer( m, item, layer ) )
                return true;

            if ( layer == Layer.OneHanded )
            {
                m.SendLocalizedMessage( 500214 ); // You already have something in both hands.
                return true;
            }

            return false;
        }

        public FishingPole( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if ( version < 1 && Layer == Layer.OneHanded )
                Layer = Layer.TwoHanded;
        }
    }
}
