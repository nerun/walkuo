/* ***************************************************************************
 * GiantSpikeTrap.cs
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
using Server.Network;

namespace Server.Items
{
	public class GiantSpikeTrap : BaseTrap
	{
		[Constructable]
		public GiantSpikeTrap() : base( 1 )
		{
		}

		public override bool PassivelyTriggered{ get{ return true; } }
		public override TimeSpan PassiveTriggerDelay{ get{ return TimeSpan.Zero; } }
		public override int PassiveTriggerRange{ get{ return 3; } }
		public override TimeSpan ResetDelay{ get{ return TimeSpan.FromSeconds( 0.0 ); } }

		public override void OnTrigger( Mobile from )
		{
			if ( from.AccessLevel > AccessLevel.Player )
				return;

			Effects.SendLocationEffect( Location, Map, 0x1D99, 48, 2, GetEffectHue(), 0 );

			if ( from.Alive && CheckRange( from.Location, 0 ) )
				Spells.SpellHelper.Damage( TimeSpan.FromTicks( 1 ), from, from, Utility.Dice( 10, 7, 0 ) );
		}

		public GiantSpikeTrap( Serial serial ) : base( serial )
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
