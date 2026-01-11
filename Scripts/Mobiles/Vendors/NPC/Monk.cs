/* ***************************************************************************
 * Monk.cs
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
	public class Monk : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
		
		[Constructable]
		public Monk() : base( "the Monk" )
		{
			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Tactics, 70.0, 90.0 );
			SetSkill( SkillName.Wrestling, 70.0, 90.0 );
			SetSkill( SkillName.MagicResist, 70.0, 90.0 );
			SetSkill( SkillName.Macing, 70.0, 90.0 );
		}
		
		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMonk() );
		}
		public override void InitOutfit()
		{
			AddItem( new Sandals() );
			AddItem( new MonkRobe() );
		}

		public Monk( Serial serial ) : base( serial )
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
