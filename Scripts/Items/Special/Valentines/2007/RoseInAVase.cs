/* ***************************************************************************
 * RoseInAVase.cs
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
﻿using System;
using Server;

namespace Server.Items
{
	public class RoseInAVase : Item /* TODO: when dye tub changes are implemented, furny dyable this */
	{
		public override int LabelNumber { get { return 1023760; } } // A Rose in a Vase	1023760

		[Constructable]
		public RoseInAVase( )
			: base( 0x0EB0 )
		{
			Hue = 0x20;
			LootType = LootType.Blessed;
		}

		public RoseInAVase( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
