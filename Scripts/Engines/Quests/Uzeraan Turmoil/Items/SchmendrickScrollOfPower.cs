/* ***************************************************************************
 * SchmendrickScrollOfPower.cs
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
using Server.Engines.Quests;

namespace Server.Engines.Quests.Haven
{
	public class SchmendrickScrollOfPower : QuestItem
	{
		public override int LabelNumber { get { return 1049118; } } // a scroll with ancient markings

		public SchmendrickScrollOfPower() : base( 0xE34 )
		{
			Weight = 1.0;
			Hue = 0x34D;
		}

		public SchmendrickScrollOfPower( Serial serial ) : base( serial )
		{
		}

		public override bool CanDrop( PlayerMobile player )
		{
			UzeraanTurmoilQuest qs = player.Quest as UzeraanTurmoilQuest;

			if ( qs == null )
				return true;

			return !qs.IsObjectiveInProgress( typeof( ReturnScrollOfPowerObjective ) );
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
