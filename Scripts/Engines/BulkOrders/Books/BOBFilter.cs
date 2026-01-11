/* ***************************************************************************
 * BOBFilter.cs
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

namespace Server.Engines.BulkOrders
{
	public class BOBFilter
	{
		private int m_Type;
		private int m_Quality;
		private int m_Material;
		private int m_Quantity;

		public bool IsDefault
		{
			get{ return ( m_Type == 0 && m_Quality == 0 && m_Material == 0 && m_Quantity == 0 ); }
		}

		public void Clear()
		{
			m_Type = 0;
			m_Quality = 0;
			m_Material = 0;
			m_Quantity = 0;
		}

		public int Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}

		public int Quality
		{
			get{ return m_Quality; }
			set{ m_Quality = value; }
		}

		public int Material
		{
			get{ return m_Material; }
			set{ m_Material = value; }
		}

		public int Quantity
		{
			get{ return m_Quantity; }
			set{ m_Quantity = value; }
		}

		public BOBFilter()
		{
		}

		public BOBFilter( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 1:
				{
					m_Type = reader.ReadEncodedInt();
					m_Quality = reader.ReadEncodedInt();
					m_Material = reader.ReadEncodedInt();
					m_Quantity = reader.ReadEncodedInt();

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			if ( IsDefault )
			{
				writer.WriteEncodedInt( 0 ); // version
			}
			else
			{
				writer.WriteEncodedInt( 1 ); // version

				writer.WriteEncodedInt( m_Type );
				writer.WriteEncodedInt( m_Quality );
				writer.WriteEncodedInt( m_Material );
				writer.WriteEncodedInt( m_Quantity );
			}
		}
	}
}
