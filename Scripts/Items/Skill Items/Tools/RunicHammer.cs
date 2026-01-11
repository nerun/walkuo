/* ***************************************************************************
 * RunicHammer.cs
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
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x13E4, 0x13E3 )]
	public class RunicHammer : BaseRunicTool
	{
		public override CraftSystem CraftSystem{ get{ return DefBlacksmithy.CraftSystem; } }

		public override int LabelNumber
		{
			get
			{
				int index = CraftResources.GetIndex( Resource );

				if ( index >= 1 && index <= 8 )
					return 1049019 + index;

				return 1045128; // runic smithy hammer
			}
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			int index = CraftResources.GetIndex( Resource );

			if ( index >= 1 && index <= 8 )
				return;

			if ( !CraftResources.IsStandard( Resource ) )
			{
				int num = CraftResources.GetLocalizationNumber( Resource );

				if ( num > 0 )
					list.Add( num );
				else
					list.Add( CraftResources.GetName( Resource ) );
			}
		}

		[Constructable]
		public RunicHammer( CraftResource resource ) : base( resource, 0x13E3 )
		{
			Weight = 8.0;
			Layer = Layer.OneHanded;
			Hue = CraftResources.GetHue( resource );
		}

		[Constructable]
		public RunicHammer( CraftResource resource, int uses ) : base( resource, uses, 0x13E3 )
		{
			Weight = 8.0;
			Layer = Layer.OneHanded;
			Hue = CraftResources.GetHue( resource );
		}

		public RunicHammer( Serial serial ) : base( serial )
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
