/* ***************************************************************************
 * HatOfTheMagi.cs
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
    public class HatOfTheMagi : WizardsHat
    {
        public override int LabelNumber{ get{ return 1061597; } } // Hat of the Magi

        public override int ArtifactRarity{ get{ return 11; } }

        public override int BasePoisonResistance{ get{ return 20; } }
        public override int BaseEnergyResistance{ get{ return 20; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public HatOfTheMagi()
        {
            Hue = 0x481;

            Attributes.BonusInt = 8;
            Attributes.RegenMana = 4;
            Attributes.SpellDamage = 10;
        }

        public HatOfTheMagi( Serial serial ) : base( serial )
        {
        }
        
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 1 );
        }
        
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                {
                    Resistances.Poison = 0;
                    Resistances.Energy = 0;
                    break;
                }
            }
        }
    }
}
