/* ***************************************************************************
 * PresetMapBuy.cs
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
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	public class PresetMapBuyInfo : GenericBuyInfo
	{
		private PresetMapEntry m_Entry;

		public override bool CanCacheDisplay{ get{ return false; } }

		public PresetMapBuyInfo( PresetMapEntry entry, int price, int amount ) : base( entry.Name.ToString(), null, price, amount, 0x14EC, 0 )
		{
			m_Entry = entry;
		}

		public override IEntity GetEntity()
		{
			return new PresetMap( m_Entry );
		}
	}
}
