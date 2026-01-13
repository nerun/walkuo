/* ***************************************************************************
 * Reagent.cs
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

namespace Server.Spells
{
    public class Reagent
    {
        private static Type[] m_Types = {
                typeof( BlackPearl ),
                typeof( Bloodmoss ),
                typeof( Garlic ),
                typeof( Ginseng ),
                typeof( MandrakeRoot ),
                typeof( Nightshade ),
                typeof( SulfurousAsh ),
                typeof( SpidersSilk ),
                typeof( BatWing ),
                typeof( GraveDust ),
                typeof( DaemonBlood ),
                typeof( NoxCrystal ),
                typeof( PigIron ),
                typeof( Bone ),
                typeof( FertileDirt ),
                typeof( DragonsBlood ),
                typeof( DaemonBone )
            };

        public Type[] Types
        {
            get{ return m_Types; }
        }

        public static Type BlackPearl
        {
            get{ return m_Types[0]; }
            set{ m_Types[0] = value; }
        }

        public static Type Bloodmoss
        {
            get{ return m_Types[1]; }
            set{ m_Types[1] = value; }
        }

        public static Type Garlic
        {
            get{ return m_Types[2]; }
            set{ m_Types[2] = value; }
        }

        public static Type Ginseng
        {
            get{ return m_Types[3]; }
            set{ m_Types[3] = value; }
        }

        public static Type MandrakeRoot
        {
            get{ return m_Types[4]; }
            set{ m_Types[4] = value; }
        }

        public static Type Nightshade
        {
            get{ return m_Types[5]; }
            set{ m_Types[5] = value; }
        }

        public static Type SulfurousAsh
        {
            get{ return m_Types[6]; }
            set{ m_Types[6] = value; }
        }

        public static Type SpidersSilk
        {
            get{ return m_Types[7]; }
            set{ m_Types[7] = value; }
        }

        public static Type BatWing
        {
            get{ return m_Types[8]; }
            set{ m_Types[8] = value; }
        }

        public static Type GraveDust
        {
            get{ return m_Types[9]; }
            set{ m_Types[9] = value; }
        }

        public static Type DaemonBlood
        {
            get{ return m_Types[10]; }
            set{ m_Types[10] = value; }
        }

        public static Type NoxCrystal
        {
            get{ return m_Types[11]; }
            set{ m_Types[11] = value; }
        }

        public static Type PigIron
        {
            get{ return m_Types[12]; }
            set{ m_Types[12] = value; }
        }

        public static Type Bone
        {
            get{ return m_Types[13]; }
            set{ m_Types[13] = value; }
        }

        public static Type FertileDirt
        {
            get{ return m_Types[14]; }
            set{ m_Types[14] = value; }
        }

        public static Type DragonsBlood
        {
            get{ return m_Types[15]; }
            set{ m_Types[15] = value; }
        }

        public static Type DaemonBone
        {
            get{ return m_Types[16]; }
            set{ m_Types[16] = value; }
        }
    }
}
