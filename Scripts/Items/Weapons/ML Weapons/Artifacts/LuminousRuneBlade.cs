/* ***************************************************************************
 * LuminousRuneBlade.cs
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
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class LuminousRuneBlade : RuneBlade
    {
        public override int LabelNumber{ get{ return 1072922; } } // Luminous Rune Blade

        [Constructable]
        public LuminousRuneBlade()
        {
            WeaponAttributes.HitLightning = 40;
            WeaponAttributes.SelfRepair = 5;
            Attributes.NightSight = 1;
            Attributes.WeaponSpeed = 25;
            Attributes.WeaponDamage = 55;

            Hue = this.GetElementalDamageHue();
        }

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = fire = cold = pois = chaos = direct = 0;
            nrgy = 100;
        }

        public LuminousRuneBlade( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();
        }
    }
}
