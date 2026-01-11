/* ***************************************************************************
 * MelisandesHairDye.cs
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
using Server.Gumps;

namespace Server.Items
{
	public class MelisandesHairDye : Item
	{
		public override int LabelNumber{ get{ return 1041088; } } // Hair Dye

		[Constructable]
		public MelisandesHairDye() : base( 0xEFF )
		{
			Hue = Utility.RandomMinMax( 0x47E, 0x499 );
		}

		public MelisandesHairDye( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				if ( MondainsLegacy.CheckML( from ) )
					from.SendGump( new ConfirmGump( this ) );
			}
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1075085 ); // Requirement: Mondain's Legacy
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

		private class ConfirmGump : BaseConfirmGump
		{
			public override int TitleNumber{ get{ return 1074395; } } // <div align=right>Use Permanent Hair Dye</div>
			public override int LabelNumber{ get{ return 1074396; } } // This special hair dye is made of a unique mixture of leaves, permanently changing one's hair color until another dye is used.

			private Item m_Item;

			public ConfirmGump( Item item ) : base()
			{
				m_Item = item;
			}

			public override void Confirm( Mobile from )
			{
				if ( m_Item != null && !m_Item.Deleted && m_Item.IsChildOf( from.Backpack ) )
				{
					if ( from.HairItemID != 0 )
					{
						from.HairHue = m_Item.Hue;
						from.PlaySound( 0x240 );
						from.SendLocalizedMessage( 502622 ); // You dye your hair.
						m_Item.Delete();
					}
					else
						from.SendLocalizedMessage( 502623 ); // You have no hair to dye and you cannot use this.
				}
				else
					from.SendLocalizedMessage( 1073461 ); // You don't have enough dye.
			}

			public override void Refuse( Mobile from )
			{
				from.SendLocalizedMessage( 502620 ); // You decide not to dye your hair.
			}
		}
	}
}

