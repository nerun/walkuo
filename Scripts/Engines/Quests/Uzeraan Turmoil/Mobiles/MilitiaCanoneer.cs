/* ***************************************************************************
 * MilitiaCanoneer.cs
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
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.Haven
{
    public class MilitiaCanoneer : BaseQuester
    {
        private bool m_Active;

        [CommandProperty( AccessLevel.GameMaster )]
        public bool Active
        {
            get { return m_Active; }
            set { m_Active = value; }
        }

        [Constructable]
        public MilitiaCanoneer() : base( "the Militia Canoneer" )
        {
            m_Active = true;
        }

        public override void InitBody()
        {
            InitStats( 100, 125, 25 );

            Hue = Utility.RandomSkinHue();

            Female = false;
            Body = 0x190;
            Name = NameList.RandomName( "male" );
        }

        public override void InitOutfit()
        {
            Utility.AssignRandomHair( this );
            Utility.AssignRandomFacialHair( this, HairHue );

            AddItem( new PlateChest() );
            AddItem( new PlateArms() );
            AddItem( new PlateGloves() );
            AddItem( new PlateLegs() );

            Torch torch = new Torch();
            torch.Movable = false;
            AddItem( torch );
            torch.Ignite();
        }

        public override bool CanTalkTo( PlayerMobile to )
        {
            return false;
        }

        public override void OnTalk( PlayerMobile player, bool contextMenu )
        {
        }

        public override bool IsEnemy( Mobile m )
        {
            if ( m.Player || m is BaseVendor )
                return false;

            if ( m is BaseCreature )
            {
                BaseCreature bc = (BaseCreature)m;

                Mobile master = bc.GetMaster();
                if( master != null )
                    return IsEnemy( master );
            }

            return m.Karma < 0;
        }

        public bool WillFire( Cannon cannon, Mobile target )
        {
            if ( m_Active && IsEnemy( target ) )
            {
                Direction = GetDirectionTo( target );
                Say( Utility.RandomList( 500651, 1049098, 1049320, 1043149 ) );
                return true;
            }

            return false;
        }

        public MilitiaCanoneer( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version

            writer.Write( (bool) m_Active );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            m_Active = reader.ReadBool();
        }
    }
}
