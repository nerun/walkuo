/* ***************************************************************************
 * CraftRes.cs
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

namespace Server.Engines.Craft
{
    public class CraftRes
    {
        private Type m_Type;
        private int m_Amount;

        private string m_MessageString;
        private int m_MessageNumber;

        private string m_NameString;
        private int m_NameNumber;

        public CraftRes( Type type, int amount )
        {
            m_Type = type;
            m_Amount = amount;
        }

        public CraftRes( Type type, TextDefinition name, int amount, TextDefinition message ): this ( type, amount )
        {
            m_NameNumber = name;
            m_MessageNumber = message;

            m_NameString = name;
            m_MessageString = message;
        }

        public void SendMessage( Mobile from )
        {
            if ( m_MessageNumber > 0 )
                from.SendLocalizedMessage( m_MessageNumber );
            else if ( !String.IsNullOrEmpty( m_MessageString ) )
                from.SendMessage( m_MessageString );
            else
                from.SendLocalizedMessage( 502925 ); // You don't have the resources required to make that item.
        }

        public Type ItemType
        {
            get { return m_Type; }
        }

        public string MessageString
        {
            get { return m_MessageString; }
        }

        public int MessageNumber
        {
            get { return m_MessageNumber; }
        }

        public string NameString
        {
            get { return m_NameString; }
        }

        public int NameNumber
        {
            get { return m_NameNumber; }
        }

        public int Amount
        {
            get { return m_Amount; }
        }
    }
}
