/* ***************************************************************************
 * MushroomTrap.cs
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
using Server.Regions;

namespace Server.Items
{
	public class MushroomTrap : BaseTrap
	{
		[Constructable]
		public MushroomTrap() : base( 0x1125 )
		{
		}

		public override bool PassivelyTriggered{ get{ return true; } }
		public override TimeSpan PassiveTriggerDelay{ get{ return TimeSpan.Zero; } }
		public override int PassiveTriggerRange{ get{ return 2; } }
		public override TimeSpan ResetDelay{ get{ return TimeSpan.Zero; } }

		public override void OnTrigger( Mobile from )
		{
			if ( !from.Alive || ItemID != 0x1125 || from.AccessLevel > AccessLevel.Player )
				return;

			ItemID = 0x1126;
			Effects.PlaySound( Location, Map, 0x306 );

			Spells.SpellHelper.Damage( TimeSpan.FromSeconds( 0.5 ), from, from, Utility.Dice( 2, 4, 0 ) );

			Timer.DelayCall( TimeSpan.FromSeconds( 2.0 ), new TimerCallback( OnMushroomReset ) );
		}

		public virtual void OnMushroomReset()
		{
			if ( Region.Find( Location, Map ).IsPartOf( typeof( DungeonRegion ) ) )
				ItemID = 0x1125; // reset
			else
				Delete();
		}

		public MushroomTrap( Serial serial ) : base( serial )
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

			if ( ItemID == 0x1126 )
				OnMushroomReset();
		}
	}
}
