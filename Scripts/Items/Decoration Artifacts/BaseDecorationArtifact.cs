/* ***************************************************************************
 * BaseDecorationArtifact.cs
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
	public abstract class BaseDecorationArtifact : Item
	{
		public abstract int ArtifactRarity{ get; }

		public override bool ForceShowProperties{ get{ return true; } }

		public BaseDecorationArtifact( int itemID ) : base( itemID )
		{
			Weight = 10.0;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1061078, this.ArtifactRarity.ToString() ); // artifact rarity ~1_val~
		}

		public BaseDecorationArtifact( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public abstract class BaseDecorationContainerArtifact : BaseContainer
	{
		public abstract int ArtifactRarity{ get; }

		public override bool ForceShowProperties{ get{ return true; } }

		public BaseDecorationContainerArtifact( int itemID ) : base( itemID )
		{
			Weight = 10.0;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			list.Add( 1061078, this.ArtifactRarity.ToString() ); // artifact rarity ~1_val~
		}

		public BaseDecorationContainerArtifact( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
