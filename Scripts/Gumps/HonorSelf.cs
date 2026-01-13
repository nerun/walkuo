/* ***************************************************************************
 * HonorSelf.cs
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
using Server.Mobiles;
using Server.Accounting;

namespace Server.Gumps
{
    public class HonorSelf: Gump
    {
        PlayerMobile m_from;
        public HonorSelf( PlayerMobile from ) : base( 150, 50 )
        {
            m_from = from;
            AddBackground(0, 0, 245, 145, 9250);
            AddButton(157, 101, 247, 248, 1, GumpButtonType.Reply, 0);
            AddButton(81, 100, 241, 248, 0, GumpButtonType.Reply, 0);
            AddHtml( 21, 20, 203, 70, @"Are you sure you want to use
honor points on yourself?", true, false);
        }

        public override void OnResponse( NetState sender, RelayInfo info )
        {
            
            if ( info.ButtonID == 1 )
            {
                HonorVirtue.ActivateEmbrace(m_from);
            }
            else
            {
                return;
            }
        }
    }
}
