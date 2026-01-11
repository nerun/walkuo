/* ***************************************************************************
 * ItemIdentification.cs
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
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
	public class ItemIdentification
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.ItemID].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile from )
		{
			from.SendLocalizedMessage( 500343 ); // What do you wish to appraise and identify?
			from.Target = new InternalTarget();

			return TimeSpan.FromSeconds( 1.0 );
		}

		[PlayerVendorTarget]
		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 8, false, TargetFlags.None )
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Item )
				{
					if ( from.CheckTargetSkill( SkillName.ItemID, o, 0, 100 ) )
					{
						if ( o is BaseWeapon )
							((BaseWeapon)o).Identified = true;
						else if ( o is BaseArmor )
							((BaseArmor)o).Identified = true;

						if ( !Core.AOS )
							((Item)o).OnSingleClick( from );
					}
					else
					{
						from.SendLocalizedMessage( 500353 ); // You are not certain...
					}
				}
				else if ( o is Mobile )
				{
					((Mobile)o).OnSingleClick( from );
				}
				else
				{
					from.SendLocalizedMessage( 500353 ); // You are not certain...
				}
			}
		}
	}
}
