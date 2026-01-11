/* ***************************************************************************
 * GuardianBarrier.cs
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
using Server.Mobiles;

namespace Server.Engines.Quests.Ninja
{
	public class GuardianBarrier : Item
	{
		[Constructable]
		public GuardianBarrier() : base( 0x3967 )
		{
			Movable = false;
			Visible = false; 
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m.AccessLevel > AccessLevel.Player )
				return true;

			// If the mobile is to the north of the barrier, allow him to pass
			if ( this.Y >= m.Y )
				return true;

			if ( m is BaseCreature )
			{
				Mobile master = ((BaseCreature)m).GetMaster();

				// Allow creatures to cross from the south to the north only if their master is near to the north
				if ( master != null && this.Y >= master.Y && master.InRange( this, 4 ) )
					return true;
				else
					return false;
			}

			PlayerMobile pm = m as PlayerMobile;

			if ( pm != null )
			{
				EminosUndertakingQuest qs = pm.Quest as EminosUndertakingQuest;

				if ( qs != null )
				{
					SneakPastGuardiansObjective obj = qs.FindObjective( typeof( SneakPastGuardiansObjective ) ) as SneakPastGuardiansObjective;

					if ( obj != null )
					{
						if ( m.Hidden )
							return true; // Hidden ninjas can pass

						if ( !obj.TaughtHowToUseSkills )
						{
							obj.TaughtHowToUseSkills = true;
							qs.AddConversation( new NeedToHideConversation() );
						}
					}
				}
			}

			return false;
		}

		public GuardianBarrier( Serial serial ) : base( serial )
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
