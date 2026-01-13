/* ***************************************************************************
 * OpenBankEntry.cs
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
using Server.Items;

namespace Server.ContextMenus
{
    public class OpenBankEntry : ContextMenuEntry
    {
        private Mobile m_Banker;

        public OpenBankEntry( Mobile from, Mobile banker ) : base( 6105, 12 )
        {
            m_Banker = banker;
        }

        public override void OnClick()
        {
            if ( !Owner.From.CheckAlive() )
                return;

            if ( Owner.From.Criminal )
            {
                m_Banker.Say( 500378 ); // Thou art a criminal and cannot access thy bank box.
            }
            else
            {
                this.Owner.From.BankBox.Open();
            }
        }
    }
}
