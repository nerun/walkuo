/* ***************************************************************************
 * Gypsy.cs
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
using Server.Items;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
    public class Gypsy : BaseCreature
    {


        [Constructable]
        public Gypsy()
            : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
        {
            InitStats( 31, 41, 51 );

            SpeechHue = Utility.RandomDyedHue();

            SetSkill( SkillName.Cooking, 65, 88 );
            SetSkill( SkillName.Snooping, 65, 88 );
            SetSkill( SkillName.Stealing, 65, 88 );

            Hue = Utility.RandomSkinHue();

            if( this.Female = Utility.RandomBool() )
            {
                this.Body = 0x191;
                this.Name = NameList.RandomName( "female" );
                AddItem( new Kilt( Utility.RandomDyedHue() ) );
                AddItem( new Shirt( Utility.RandomDyedHue() ) );
                AddItem( new ThighBoots() );
                Title = "the gypsy";
            }
            else
            {
                this.Body = 0x190;
                this.Name = NameList.RandomName( "male" );
                AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
                AddItem( new Shirt( Utility.RandomDyedHue() ) );
                AddItem( new Sandals() );
                Title = "the gypsy";
            }

            AddItem( new Bandana( Utility.RandomDyedHue() ) );
            AddItem( new Dagger() );

            Utility.AssignRandomHair( this );

            Container pack = new Backpack();

            pack.DropItem( new Gold( 250, 300 ) );

            pack.Movable = false;

            AddItem( pack );
        }


        public override bool CanTeach { get { return true; } }
        public override bool ClickTitle { get { return false; } }

        public Gypsy( Serial serial )
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
