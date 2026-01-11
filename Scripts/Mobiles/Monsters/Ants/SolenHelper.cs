/* ***************************************************************************
 * SolenHelper.cs
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
using Server.Network;

namespace Server.Mobiles
{
	public class SolenHelper
	{
		public static void PackPicnicBasket( BaseCreature solen )
		{
			if ( 1 > Utility.Random( 100 ) )
			{
				PicnicBasket basket = new PicnicBasket();

				basket.DropItem( new BeverageBottle( BeverageType.Wine ) );
				basket.DropItem( new CheeseWedge() );

				solen.PackItem( basket );
			}
		}

		public static bool CheckRedFriendship( Mobile m )
		{
			if ( m is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)m;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					return CheckRedFriendship( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					return CheckRedFriendship( bc.SummonMaster );
			}

			PlayerMobile player = m as PlayerMobile;

			return player != null && player.SolenFriendship == SolenFriendship.Red;
		}

		public static bool CheckBlackFriendship( Mobile m )
		{
			if ( m is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)m;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					return CheckBlackFriendship( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					return CheckBlackFriendship( bc.SummonMaster );
			}

			PlayerMobile player = m as PlayerMobile;

			return player != null && player.SolenFriendship == SolenFriendship.Black;
		}

		public static void OnRedDamage( Mobile from )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					OnRedDamage( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					OnRedDamage( bc.SummonMaster );
			}

			PlayerMobile player = from as PlayerMobile;

			if ( player != null && player.SolenFriendship == SolenFriendship.Red )
			{
				player.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1054103 ); // The solen revoke their friendship. You will now be considered an intruder.

				player.SolenFriendship = SolenFriendship.None;
			}
		}

		public static void OnBlackDamage( Mobile from )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled && bc.ControlMaster is PlayerMobile )
					OnBlackDamage( bc.ControlMaster );
				else if ( bc.Summoned && bc.SummonMaster is PlayerMobile )
					OnBlackDamage( bc.SummonMaster );
			}

			PlayerMobile player = from as PlayerMobile;

			if ( player != null && player.SolenFriendship == SolenFriendship.Black )
			{
				player.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1054103 ); // The solen revoke their friendship. You will now be considered an intruder.

				player.SolenFriendship = SolenFriendship.None;
			}
		}
	}
}
