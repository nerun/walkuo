/* ***************************************************************************
 * ChartRenderer.cs
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
using System.Drawing;
using System.Collections;

namespace Server.Engines.Reports
{
	//*********************************************************************
	//
	// Chart Class
	//
	// Base class implementation for BarChart and PieChart
	//
	//*********************************************************************

	public abstract class ChartRenderer
	{
		private const int _colorLimit = 9;

		private Color[] _color = 
			{ 
				Color.Firebrick,
				Color.SkyBlue,
				Color.MediumSeaGreen,
				Color.MediumOrchid,
				Color.Chocolate,
				Color.SlateBlue,
				Color.LightPink,
				Color.LightGreen,
				Color.Khaki
			};

		// Represent collection of all data points for the chart
		private ChartItemsCollection _dataPoints = new ChartItemsCollection();  

		// The implementation of this method is provided by derived classes
		public abstract Bitmap Draw();	

		public ChartItemsCollection DataPoints
		{
			get{ return _dataPoints; }
			set{ _dataPoints = value; }
		}

		public void SetColor(int index, Color NewColor)
		{
			if (index < _colorLimit) 
			{
				_color[index] = NewColor;
			}
			else
			{
				throw new Exception("Color Limit is " + _colorLimit);
			}
		}

		public Color GetColor(int index)
		{
			//return _color[index%_colorLimit];

			if (index < _colorLimit) 
			{
				return _color[index];
			}
			else
			{
				return _color[(index+2)%_colorLimit];
				//throw new Exception("Color Limit is " + _colorLimit);
			}
		}
	}
}
