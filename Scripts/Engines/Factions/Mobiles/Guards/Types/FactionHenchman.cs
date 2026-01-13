/* ***************************************************************************
 * FactionHenchman.cs
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

namespace Server.Factions
{
    public class FactionHenchman : BaseFactionGuard
    {
        public override GuardAI GuardAI{ get{ return GuardAI.Melee; } }

        [Constructable]
        public FactionHenchman() : base( "the henchman" )
        {
            GenerateBody( false, true );

            SetStr( 91, 115 );
            SetDex( 61, 85 );
            SetInt( 81, 95 );

            SetDamage( 10, 14 );

            SetResistance( ResistanceType.Physical, 10, 30 );
            SetResistance( ResistanceType.Fire, 10, 30 );
            SetResistance( ResistanceType.Cold, 10, 30 );
            SetResistance( ResistanceType.Energy, 10, 30 );
            SetResistance( ResistanceType.Poison, 10, 30 );

            VirtualArmor = 8;

            SetSkill( SkillName.Fencing, 80.0, 90.0 );
            SetSkill( SkillName.Wrestling, 80.0, 90.0 );
            SetSkill( SkillName.Tactics, 80.0, 90.0 );
            SetSkill( SkillName.MagicResist, 80.0, 90.0 );
            SetSkill( SkillName.Healing, 80.0, 90.0 );
            SetSkill( SkillName.Anatomy, 80.0, 90.0 );

            AddItem( new StuddedChest() );
            AddItem( new StuddedLegs() );
            AddItem( new StuddedArms() );
            AddItem( new StuddedGloves() );
            AddItem( new StuddedGorget() );
            AddItem( new Boots() );
            AddItem( Newbied( new Spear() ) );

            PackItem( new Bandage( Utility.RandomMinMax( 10, 20 ) ) );
            PackWeakPotions( 1, 4 );
        }

        public FactionHenchman( Serial serial ) : base( serial )
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
