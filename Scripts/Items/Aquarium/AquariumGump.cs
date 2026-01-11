/* ***************************************************************************
 * AquariumGump.cs
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
using System.Collections;
using Server.Gumps;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class AquariumGump : Gump
	{
		private Aquarium m_Aquarium;

		public AquariumGump( Aquarium aquarium, bool edit ) : base( 100, 100 )
		{
			m_Aquarium = aquarium;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );
			AddBackground( 0, 0, 350, 323, 0xE10 );
			AddImage( 0, 0, 0x2C96 );

			if ( m_Aquarium.Items.Count == 0 )
				return;

			for ( int i = 1; i <= m_Aquarium.Items.Count; i ++ )
				DisplayPage( i, edit );
		}

		public virtual void DisplayPage( int page, bool edit )
		{
			AddPage( page );

			Item item = m_Aquarium.Items[ page - 1 ];

			// item name
			if ( item.LabelNumber != 0 )
				AddHtmlLocalized( 20, 217, 250, 20, item.LabelNumber, 0xFFFFFF, false, false ); // Name

			// item details
			if ( item is BaseFish )
				AddHtmlLocalized( 20, 239, 315, 20, ( (BaseFish) item ).GetDescription(), 0xFFFFFF, false, false );
			else
				AddHtmlLocalized( 20, 239, 315, 20, 1073634, 0xFFFFFF, false, false ); // An aquarium decoration

			// item image
			AddItem( 150, 80, item.ItemID, item.Hue );

			// item number / all items
			AddHtml( 20, 195, 250, 20, String.Format( "<BASEFONT COLOR=#FFFFFF>{0}/{1}</BASEFONT>", page, m_Aquarium.Items.Count ), false, false );

			// remove item
			if ( edit )
			{
				AddBackground( 230, 195, 100, 26, 0x13BE );
				AddButton( 235, 200, 0x845, 0x846, page, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 260, 198, 60, 26, 1073838, 0x0, false, false ); // Remove
			}

			// next page
			if ( page < m_Aquarium.Items.Count )
			{
				AddButton( 195, 280, 0xFA5, 0xFA7, 0, GumpButtonType.Page, page + 1 );
				AddHtmlLocalized( 230, 283, 100, 18, 1044045, 0xFFFFFF, false, false ); // NEXT PAGE
			}

			// previous page
			if ( page > 1 )
			{
				AddButton( 45, 280, 0xFAE, 0xFAF, 0, GumpButtonType.Page, page - 1 );
				AddHtmlLocalized( 80, 283, 100, 18, 1044044, 0xFFFFFF, false, false ); // PREV PAGE
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Aquarium == null || m_Aquarium.Deleted )
				return;

			bool edit = m_Aquarium.HasAccess( sender.Mobile );

			if ( info.ButtonID > 0 && info.ButtonID <= m_Aquarium.Items.Count && edit )
				m_Aquarium.RemoveItem( sender.Mobile, info.ButtonID - 1 );

			if ( info.ButtonID > 0 )
				sender.Mobile.SendGump( new AquariumGump( m_Aquarium, edit ) );
		}
	}
}
