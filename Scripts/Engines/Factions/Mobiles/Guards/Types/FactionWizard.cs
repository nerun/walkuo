/* ***************************************************************************
 * FactionWizard.cs
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
    public class FactionWizard : BaseFactionGuard
    {
        public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }

        [Constructable]
        public FactionWizard() : base( "the wizard" )
        {
            GenerateBody( false, false );

            SetStr( 151, 175 );
            SetDex( 61, 85 );
            SetInt( 151, 175 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 40, 60 );
            SetResistance( ResistanceType.Fire, 40, 60 );
            SetResistance( ResistanceType.Cold, 40, 60 );
            SetResistance( ResistanceType.Energy, 40, 60 );
            SetResistance( ResistanceType.Poison, 40, 60 );

            VirtualArmor = 32;

            SetSkill( SkillName.Macing, 110.0, 120.0 );
            SetSkill( SkillName.Wrestling, 110.0, 120.0 );
            SetSkill( SkillName.Tactics, 110.0, 120.0 );
            SetSkill( SkillName.MagicResist, 110.0, 120.0 );
            SetSkill( SkillName.Healing, 110.0, 120.0 );
            SetSkill( SkillName.Anatomy, 110.0, 120.0 );

            SetSkill( SkillName.Magery, 110.0, 120.0 );
            SetSkill( SkillName.EvalInt, 110.0, 120.0 );
            SetSkill( SkillName.Meditation, 110.0, 120.0 );

            AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
            AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
            AddItem( Immovable( Rehued( new Robe(), 1310 ) ) );
            AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
            AddItem( Newbied( Rehued( new GnarledStaff(), 1310 ) ) );

            PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
            PackStrongPotions( 6, 12 );
        }

        public FactionWizard( Serial serial ) : base( serial )
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
