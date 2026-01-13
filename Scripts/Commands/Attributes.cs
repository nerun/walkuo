/* ***************************************************************************
 * Attributes.cs
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

namespace Server
{
    public class UsageAttribute : Attribute
    {
        private string m_Usage;

        public string Usage{ get{ return m_Usage; } }

        public UsageAttribute( string usage )
        {
            m_Usage = usage;
        }
    }

    public class DescriptionAttribute : Attribute
    {
        private string m_Description;

        public string Description{ get{ return m_Description; } }

        public DescriptionAttribute( string description )
        {
            m_Description = description;
        }
    }

    public class AliasesAttribute : Attribute
    {
        private string[] m_Aliases;

        public string[] Aliases{ get{ return m_Aliases; } }

        public AliasesAttribute( params string[] aliases )
        {
            m_Aliases = aliases;
        }
    }
}
