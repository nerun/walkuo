/* ***************************************************************************
 * Vagabond.cs
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
using Server.Items;

namespace Server.Mobiles
{
    public class Vagabond : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        [Constructable]
        public Vagabond() : base( "the vagabond" )
        {
            SetSkill( SkillName.ItemID, 60.0, 83.0 );
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add( new SBTinker() );
            m_SBInfos.Add( new SBVagabond() );
        }

        public override void InitOutfit()
        {
            AddItem( new FancyShirt( Utility.RandomBrightHue() ) );
            AddItem( new Shoes( GetShoeHue() ) );
            AddItem( new LongPants( GetRandomHue() ) );

            if ( Utility.RandomBool() )
                AddItem( new Cloak( Utility.RandomBrightHue() ) );

            switch ( Utility.Random( 2 ) )
            {
                case 0: AddItem( new SkullCap( Utility.RandomNeutralHue() ) ); break;
                case 1: AddItem( new Bandana( Utility.RandomNeutralHue() ) ); break;
            }


            Utility.AssignRandomHair( this );
            Utility.AssignRandomFacialHair( this, HairHue );

            PackGold( 100, 200 );
        }

        public Vagabond( Serial serial ) : base( serial )
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
