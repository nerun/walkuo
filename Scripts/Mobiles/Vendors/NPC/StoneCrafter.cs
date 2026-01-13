/* ***************************************************************************
 * StoneCrafter.cs
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

namespace Server.Mobiles
{
    [TypeAlias( "Server.Mobiles.GargoyleStonecrafter" )]
    public class StoneCrafter : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        public override NpcGuild NpcGuild{ get{ return NpcGuild.TinkersGuild; } }

        [Constructable]
        public StoneCrafter() : base( "the stone crafter" )
        {
            SetSkill( SkillName.Carpentry, 85.0, 100.0 );
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add( new SBStoneCrafter() );
            m_SBInfos.Add( new SBStavesWeapon() );
            m_SBInfos.Add( new SBCarpenter() );
            m_SBInfos.Add( new SBWoodenShields() );
        }

        public StoneCrafter( Serial serial ) : base( serial )
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

            if ( Title == "the stonecrafter" )
                Title = "the stone crafter";
        }
    }
}
