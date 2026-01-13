/* ***************************************************************************
 * CrystalSeaSerpent.cs
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
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "a crystal sea serpent corpse" )]
    public class CrystalSeaSerpent : SeaSerpent
    {
        [Constructable]
        public CrystalSeaSerpent()
        {
            Name = "a crystal sea serpent";
            Hue = 0x47E;

            SetStr( 250, 450 );
            SetDex( 100, 150 );
            SetInt( 90, 190 );

            SetHits( 230, 330 );

            SetDamage( 10, 18 );

            SetDamageType( ResistanceType.Physical, 10 );
            SetDamageType( ResistanceType.Cold, 45 );
            SetDamageType( ResistanceType.Energy, 45 );

            SetResistance( ResistanceType.Physical, 50, 70 );
            SetResistance( ResistanceType.Fire, 0 );
            SetResistance( ResistanceType.Cold, 70, 90 );
            SetResistance( ResistanceType.Poison, 20, 30 );
            SetResistance( ResistanceType.Energy, 60, 80 );
        }

        /*
        // TODO: uncomment once added
        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            if ( Utility.RandomDouble() < 0.05 )
                c.DropItem( new CrushedCrystals() );

            if ( Utility.RandomDouble() < 0.1 )
                c.DropItem( new IcyHeart() );

            if ( Utility.RandomDouble() < 0.1 )
                c.DropItem( new LuckyDagger() );
        }
        */

        public CrystalSeaSerpent( Serial serial )
            : base( serial )
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
