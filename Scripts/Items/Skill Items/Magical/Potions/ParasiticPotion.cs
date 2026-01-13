/* ***************************************************************************
 * ParasiticPotion.cs
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
    public class ParasiticPotion : BasePoisonPotion
    {
        public override Poison Poison{ get{ return Poison.Greater; } }         /* public override Poison Poison{ get{ return Poison.Darkglow; } }  MUST be restored when prerequisites are done */

        public override double MinPoisoningSkill{ get{ return 95.0; } }
        public override double MaxPoisoningSkill{ get{ return 100.0; } }
        
        public override int LabelNumber{ get{ return 1072848; } } // Parasitic Poison

        [Constructable]
        public ParasiticPotion() : base( PotionEffect.Parasitic )
        {
            Hue = 0x17C;
        }

        public ParasiticPotion( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
