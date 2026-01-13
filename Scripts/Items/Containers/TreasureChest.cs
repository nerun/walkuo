/* ***************************************************************************
 * TreasureChest.cs
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
using Server;
using Server.Items;
using Server.Multis;
using Server.Network;
using System;

namespace Server.Items
{
    [FlipableAttribute( 0xe43, 0xe42 )] 
    public class WoodenTreasureChest : BaseTreasureChest 
    { 
        [Constructable] 
        public WoodenTreasureChest() : base( 0xE43 ) 
        { 
        } 

        public WoodenTreasureChest( Serial serial ) : base( serial ) 
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

    [FlipableAttribute( 0xe41, 0xe40 )] 
    public class MetalGoldenTreasureChest : BaseTreasureChest 
    {
        [Constructable] 
        public MetalGoldenTreasureChest() : base( 0xE41 ) 
        { 
        } 

        public MetalGoldenTreasureChest( Serial serial ) : base( serial ) 
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

    [FlipableAttribute( 0x9ab, 0xe7c )] 
    public class MetalTreasureChest : BaseTreasureChest 
    {
        [Constructable] 
        public MetalTreasureChest() : base( 0x9AB ) 
        { 
        } 

        public MetalTreasureChest( Serial serial ) : base( serial ) 
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
