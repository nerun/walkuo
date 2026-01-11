/* ***************************************************************************
 * GrizzledMareStatuette.cs
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

namespace Server.Items
{
	public class GrizzledMareStatuette : BaseImprisonedMobile
	{
		public override int LabelNumber{ get{ return 1074475; } } // Grizzled Mare Statuette
		public override BaseCreature Summon{ get { return new GrizzledMare(); } }
	
		[Constructable]
		public GrizzledMareStatuette() : base( 0x2617 )
		{
			Weight = 1.0;
		}

		public GrizzledMareStatuette( Serial serial ) : base( serial )
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

namespace Server.Mobiles
{
	public class GrizzledMare : HellSteed
	{
		public override bool DeleteOnRelease { get { return true; } }

		private static readonly string m_Myname = "a grizzled mare";

		[Constructable]
		public GrizzledMare()
			: base( m_Myname  )
		{
		}

		public virtual void OnAfterDeserialize_Callback()
		{
			HellSteed.SetStats( this );

			Name = m_Myname;
		}

		public GrizzledMare( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();

			if( version < 1 )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 0 ), new TimerCallback( OnAfterDeserialize_Callback ) );
			}
		}
	}
}
