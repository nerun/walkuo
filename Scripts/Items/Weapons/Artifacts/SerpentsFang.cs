/* ***************************************************************************
 * SerpentsFang.cs
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
    public class SerpentsFang : Kryss
    {
        public override int LabelNumber{ get{ return 1061601; } } // Serpent's Fang
        public override int ArtifactRarity{ get{ return 11; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public SerpentsFang()
        {
            ItemID = 0x1400;
            Hue = 0x488;
            WeaponAttributes.HitPoisonArea = 100;
            WeaponAttributes.ResistPoisonBonus = 20;
            Attributes.AttackChance = 15;
            Attributes.WeaponDamage = 50;
        }

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            fire = cold = nrgy = chaos = direct = 0;
            phys = 25;
            pois = 75;
        }

        public SerpentsFang( Serial serial ) : base( serial )
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

            if ( ItemID == 0x1401 )
                ItemID = 0x1400;
        }
    }
}
