/* ***************************************************************************
 * GypsyMaiden.cs
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
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;

namespace Server.Mobiles
{
    public class GypsyMaiden : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        [Constructable]
        public GypsyMaiden() : base( "the gypsy maiden" )
        {
        }

        public override bool GetGender()
        {
            return true; // always female
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add( new SBProvisioner() );
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            switch ( Utility.Random( 4 ) )
            {
                case 0: AddItem( new JesterHat( Utility.RandomBrightHue() ) ); break;
                case 1: AddItem( new Bandana( Utility.RandomBrightHue() ) ); break;
                case 2: AddItem( new SkullCap( Utility.RandomBrightHue() ) ); break;
            }

            if ( Utility.RandomBool() )
                AddItem( new HalfApron( Utility.RandomBrightHue() ) );

            Item item = FindItemOnLayer( Layer.Pants );

            if ( item != null )
                item.Hue = Utility.RandomBrightHue();

            item = FindItemOnLayer( Layer.OuterLegs );

            if ( item != null )
                item.Hue = Utility.RandomBrightHue();

            item = FindItemOnLayer( Layer.InnerLegs );

            if ( item != null )
                item.Hue = Utility.RandomBrightHue();
        }

        public GypsyMaiden( Serial serial ) : base( serial )
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
