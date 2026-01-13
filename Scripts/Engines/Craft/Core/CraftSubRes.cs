/* ***************************************************************************
 * CraftSubRes.cs
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
    public class CraftSubRes
    {
        private Type m_Type;
        private double m_ReqSkill;
        private string m_NameString;
        private int m_NameNumber;
        private int m_GenericNameNumber;
        private object m_Message;

        public CraftSubRes( Type type, TextDefinition name, double reqSkill, object message ) : this( type, name, reqSkill, 0, message )
        {
        }

        public CraftSubRes( Type type, TextDefinition name, double reqSkill, int genericNameNumber, object message )
        {
            m_Type = type;
            m_NameNumber = name;
            m_NameString = name;
            m_ReqSkill = reqSkill;
            m_GenericNameNumber = genericNameNumber;
            m_Message = message;
        }

        public Type ItemType
        {
            get { return m_Type; }
        }

        public string NameString
        {
            get { return m_NameString; }
        }

        public int NameNumber
        {
            get { return m_NameNumber; }
        }

        public int GenericNameNumber
        {
            get { return m_GenericNameNumber; }
        }

        public object Message
        {
            get { return m_Message; }
        }

        public double RequiredSkill
        {
            get { return m_ReqSkill; }
        }
    }
}
