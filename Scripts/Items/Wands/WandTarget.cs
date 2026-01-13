/* ***************************************************************************
 * WandTarget.cs
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

namespace Server.Targeting
{
    public class WandTarget : Target
    {
        private BaseWand m_Item;

        public WandTarget( BaseWand item ) : base( 6, false, TargetFlags.None )
        {
            m_Item = item;
        }

        private static int GetOffset( Mobile caster )
        {
            return 5 + (int)(caster.Skills[SkillName.Magery].Value * 0.02 );
        }

        protected override void OnTarget( Mobile from, object targeted )
        {
            m_Item.DoWandTarget( from, targeted );
        }
    }
}
