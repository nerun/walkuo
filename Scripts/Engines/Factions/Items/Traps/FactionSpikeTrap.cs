/* ***************************************************************************
 * FactionSpikeTrap.cs
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

namespace Server.Factions
{
	public class FactionSpikeTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044601; } } // faction spike trap

		public override int AttackMessage{ get{ return 1010545; } } // Large spikes in the ground spring up piercing your skin!
		public override int DisarmMessage{ get{ return 1010541; } } // You carefully dismantle the trigger on the spikes and disable the trap.
		public override int EffectSound{ get{ return 0x22E; } }
		public override int MessageHue{ get{ return 0x5A; } }

		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.ControlledFactionTown; } }

		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x11A4, 12, 6 );
		}

		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}

		[Constructable]
		public FactionSpikeTrap() : this( null )
		{
		}

		public FactionSpikeTrap( Faction f ) : this( f, null )
		{
		}

		public FactionSpikeTrap( Faction f, Mobile m ) : base( f, m, 0x11A0 )
		{
		}

		public FactionSpikeTrap( Serial serial ) : base( serial )
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

	public class FactionSpikeTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionSpikeTrap ); } }
		public override int LabelNumber{ get{ return 1044605; } } // faction spike trap deed

		public FactionSpikeTrapDeed() : base( 0x11A5 )
		{
		}
		
		public FactionSpikeTrapDeed( Serial serial ) : base( serial )
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
