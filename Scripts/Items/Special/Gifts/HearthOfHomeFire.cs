/* ***************************************************************************
 * HearthOfHomeFire.cs
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
using Server.Network;

namespace Server.Items
{
	public class HearthOfHomeFire : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new HearthOfHomeFireDeed(); } }

		[Constructable]
		public HearthOfHomeFire( bool east )
		{
			if ( east )
			{
				AddLightComponent( new AddonComponent( 0x2352 ), 0, 0, 0 );
				AddLightComponent( new AddonComponent( 0x2358 ), 0, -1, 0 );
			}
			else
			{
				AddLightComponent( new AddonComponent( 0x2360 ), 0, 0, 0 );
				AddLightComponent( new AddonComponent( 0x2366 ), -1, 0, 0 );
			}
		}

		private void AddLightComponent( AddonComponent component, int x, int y, int z )
		{
			component.Light = LightType.Circle150;

			AddComponent( component, x, y, z );
		}

		public HearthOfHomeFire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class HearthOfHomeFireDeed : BaseAddonDeed
	{
		private bool m_East;

		public override BaseAddon Addon{ get{ return new HearthOfHomeFire( m_East ); } }

		public override int LabelNumber{ get{ return 1062919; } } // Hearth of the Home Fire

		[Constructable]
		public HearthOfHomeFireDeed()
		{
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.CloseGump( typeof( InternalGump ) );
				from.SendGump( new InternalGump( this ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		private void SendTarget( Mobile m )
		{
			base.OnDoubleClick( m );
		}

		private class InternalGump : Gump
		{
			private HearthOfHomeFireDeed m_Deed;

			public InternalGump( HearthOfHomeFireDeed deed ) : base( 150, 50 )
			{
				m_Deed = deed;

				AddBackground( 0, 0, 350, 250, 0xA28 );

				AddItem( 90, 52, 0x2367 );
				AddItem( 112, 35, 0x2360 );
				AddButton( 70, 35, 0x868, 0x869, 1, GumpButtonType.Reply, 0 ); // South

				AddItem( 220, 35, 0x2352 );
				AddItem( 242, 52, 0x2358 );
				AddButton( 185, 35, 0x868, 0x869, 2, GumpButtonType.Reply, 0 ); // East
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Deed.Deleted || info.ButtonID == 0 )
					return;

				m_Deed.m_East = (info.ButtonID != 1);
				m_Deed.SendTarget( sender.Mobile );
			}
		}

		public HearthOfHomeFireDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
