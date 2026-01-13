/* ***************************************************************************
 * NecromancerSpellbook.cs
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
using Server.Spells;

namespace Server.Items
{
    public class NecromancerSpellbook : Spellbook
    {
        public override SpellbookType SpellbookType{ get{ return SpellbookType.Necromancer; } }
        public override int BookOffset{ get{ return 100; } }
        public override int BookCount{ get{ return ((Core.SE) ? 17 : 16); } }

        [Constructable]
        public NecromancerSpellbook() : this( (ulong)0 )
        {
        }

        [Constructable]
        public NecromancerSpellbook( ulong content ) : base( content, 0x2253 )
        {
            Layer = (Core.ML ? Layer.OneHanded : Layer.Invalid);
        }

        public NecromancerSpellbook( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int)1 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            if( version == 0 && Core.ML )
                Layer = Layer.OneHanded;
        }
    }
}
