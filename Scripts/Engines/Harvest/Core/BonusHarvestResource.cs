/* ***************************************************************************
 * BonusHarvestResource.cs
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

namespace Server.Engines.Harvest
{
    public class BonusHarvestResource
    {
        private Type m_Type;
        private double m_ReqSkill, m_Chance;
        private TextDefinition m_SuccessMessage;

        public Type Type { get { return m_Type; } set { m_Type = value; } }
        public double ReqSkill { get { return m_ReqSkill; } set { m_ReqSkill = value; } }
        public double Chance { get { return m_Chance; } set { m_Chance = value; } }

        public TextDefinition SuccessMessage { get { return m_SuccessMessage; } }

        public void SendSuccessTo( Mobile m )
        {
            TextDefinition.SendMessageTo( m, m_SuccessMessage );
        }

        public BonusHarvestResource( double reqSkill, double chance, TextDefinition message, Type type )
        {
            m_ReqSkill = reqSkill;

            m_Chance = chance;
            m_Type = type;
            m_SuccessMessage = message;
        }
    }
}
