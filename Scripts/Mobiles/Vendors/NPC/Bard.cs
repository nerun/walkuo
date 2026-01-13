/* ***************************************************************************
 * Bard.cs
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
    public class Bard : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

        public override NpcGuild NpcGuild{ get{ return NpcGuild.BardsGuild; } }

        [Constructable]
        public Bard() : base( "the bard" )
        {
            SetSkill( SkillName.Discordance, 64.0, 100.0 );
            SetSkill( SkillName.Musicianship, 64.0, 100.0 );
            SetSkill( SkillName.Peacemaking, 65.0, 88.0 );
            SetSkill( SkillName.Provocation, 60.0, 83.0 );
            SetSkill( SkillName.Archery, 36.0, 68.0 );
            SetSkill( SkillName.Swords, 36.0, 68.0 );
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add( new SBBard() );
        }

        public Bard( Serial serial ) : base( serial )
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
