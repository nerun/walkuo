/* ***************************************************************************
 * ZyronicClaw.cs
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
    public class ZyronicClaw : ExecutionersAxe
    {
        public override int LabelNumber{ get{ return 1061593; } } // Zyronic Claw
        public override int ArtifactRarity{ get{ return 10; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public ZyronicClaw()
        {
            Hue = 0x485;
            Slayer = SlayerName.ElementalBan;
            WeaponAttributes.HitLeechMana = 50;
            Attributes.AttackChance = 30;
            Attributes.WeaponDamage = 50;
        }

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            chaos = direct = 0;
            phys = fire = cold = pois = nrgy = 20;
        }

        public ZyronicClaw( Serial serial ) : base( serial )
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

            if ( Slayer == SlayerName.None )
                Slayer = SlayerName.ElementalBan;
        }
    }
}
