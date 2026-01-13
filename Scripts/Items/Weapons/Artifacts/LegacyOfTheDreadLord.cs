/* ***************************************************************************
 * LegacyOfTheDreadLord.cs
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
    public class LegacyOfTheDreadLord : Bardiche
    {
        public override int LabelNumber{ get{ return 1060860; } } // Legacy of the Dread Lord
        public override int ArtifactRarity{ get{ return 10; } }

        public override int InitMinHits{ get{ return 255; } }
        public override int InitMaxHits{ get{ return 255; } }

        [Constructable]
        public LegacyOfTheDreadLord()
        {
            Hue = 0x676;
            Attributes.SpellChanneling = 1;
            Attributes.CastRecovery = 3;
            Attributes.WeaponSpeed = 30;
            Attributes.WeaponDamage = 50;
        }

        public LegacyOfTheDreadLord( Serial serial ) : base( serial )
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

            if ( Attributes.CastSpeed == 3 )
                Attributes.CastRecovery = 3;

            if ( Hue == 0x4B9 )
                Hue = 0x676;
        }
    }
}
