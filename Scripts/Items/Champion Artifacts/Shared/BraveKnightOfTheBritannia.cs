/* ***************************************************************************
 * BraveKnightOfTheBritannia.cs
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

namespace Server.Items
{
    public class BraveKnightOfTheBritannia : Katana
    {
        public override int LabelNumber{ get{ return 1094909; } } // Brave Knight of The Britannia [Replica]

        public override int InitMinHits{ get{ return 150; } }
        public override int InitMaxHits{ get{ return 150; } }

        public override bool CanFortify{ get{ return false; } }

        [Constructable]
        public BraveKnightOfTheBritannia()
        {
            Hue = 0x47e;

            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 35;

            WeaponAttributes.HitLeechStam = 48;
            WeaponAttributes.HitHarm = 26;
            WeaponAttributes.HitLeechHits = 22;
        }

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = chaos = direct = 0;
            fire = 40;
            cold = 30;
            pois = 10;
            nrgy = 20;
        }

        public BraveKnightOfTheBritannia( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
