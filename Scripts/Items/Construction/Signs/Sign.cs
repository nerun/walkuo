/* ***************************************************************************
 * Sign.cs
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
    public enum SignFacing
    {
        North,
        West
    }

    public enum SignType
    {
        Library,
        DarkWoodenPost,
        LightWoodenPost,
        MetalPostC,
        MetalPostB,
        MetalPostA,
        MetalPost,
        Bakery,
        Tailor,
        Tinker,
        Butcher,
        Healer,
        Mage,
        Woodworker,
        Customs,
        Inn,
        Shipwright,
        Stables,
        BarberShop,
        Bard,
        Fletcher,
        Armourer,
        Jeweler,
        Tavern,
        ReagentShop,
        Blacksmith,
        Painter,
        Provisioner,
        Bowyer,
        WoodenSign,
        BrassSign,
        ArmamentsGuild,
        ArmourersGuild,
        BlacksmithsGuild,
        WeaponsGuild,
        BardicGuild,
        BartersGuild,
        ProvisionersGuild,
        TradersGuild,
        CooksGuild,
        HealersGuild,
        MagesGuild,
        SorcerersGuild,
        IllusionistGuild,
        MinersGuild,
        ArchersGuild,
        SeamensGuild,
        FishermensGuild,
        SailorsGuild,
        ShipwrightsGuild,
        TailorsGuild,
        ThievesGuild,
        RoguesGuild,
        AssassinsGuild,
        TinkersGuild,
        WarriorsGuild,
        CavalryGuild,
        FightersGuild,
        MerchantsGuild,
        Bank,
        Theatre
    }

    public class Sign : BaseSign
    {
        [Constructable]
        public Sign( SignType type, SignFacing facing ) : base( ( 0xB95 + (2 * (int)type) ) + (int)facing )
        {
        }

        [Constructable]
        public Sign( int itemID ) : base( itemID )
        {
        }

        public Sign( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
