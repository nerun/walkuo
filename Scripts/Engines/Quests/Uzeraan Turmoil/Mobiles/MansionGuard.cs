/* ***************************************************************************
 * MansionGuard.cs
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
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.Haven
{
    public class MansionGuard : BaseQuester
    {
        [Constructable]
        public MansionGuard() : base( "the Mansion Guard" )
        {
        }

        public override void InitBody()
        {
            InitStats( 100, 100, 25 );

            Hue = Utility.RandomSkinHue();

            Female = false;
            Body = 0x190;
            Name = NameList.RandomName( "male" );
        }

        public override void InitOutfit()
        {
            AddItem( new PlateChest() );
            AddItem( new PlateArms() );
            AddItem( new PlateGloves() );
            AddItem( new PlateLegs() );

            Utility.AssignRandomHair( this );
            Utility.AssignRandomFacialHair( this, HairHue );

            Bardiche weapon = new Bardiche();
            weapon.Movable = false;
            AddItem( weapon );
        }

        public override int GetAutoTalkRange( PlayerMobile pm )
        {
            return 3;
        }

        public override bool CanTalkTo( PlayerMobile to )
        {
            return ( to.Quest == null && QuestSystem.CanOfferQuest( to, typeof( UzeraanTurmoilQuest ) ) );
        }

        public override void OnTalk( PlayerMobile player, bool contextMenu )
        {
            if ( player.Quest == null && QuestSystem.CanOfferQuest( player, typeof( UzeraanTurmoilQuest ) ) )
            {
                Direction = GetDirectionTo( player );

                new UzeraanTurmoilQuest( player ).SendOffer();
            }
        }

        public MansionGuard( Serial serial ) : base( serial )
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
