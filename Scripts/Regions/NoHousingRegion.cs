/* ***************************************************************************
 * NoHousingRegion.cs
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
using System.Xml;
using Server;

namespace Server.Regions
{
    public class NoHousingRegion : BaseRegion
    {
        /*  - False: this uses 'stupid OSI' house placement checking: part of the house may be placed here provided that the center is not in the region
         *  -  True: this uses 'smart WalkUO' house placement checking: no part of the house may be in the region
         */
        private bool m_SmartChecking;

        public bool SmartChecking{ get{ return m_SmartChecking; } }

        public NoHousingRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
        {
            ReadBoolean( xml["smartNoHousing"], "active", ref m_SmartChecking, false );
        }

        public override bool AllowHousing( Mobile from, Point3D p )
        {
            return m_SmartChecking;
        }
    }
}
