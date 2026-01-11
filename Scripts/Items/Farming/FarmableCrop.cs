/* ***************************************************************************
 * FarmableCrop.cs
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
using Server.Network;
using Server.Regions;

namespace Server.Items
{
	public abstract class FarmableCrop : Item
	{
		private bool m_Picked;

		public abstract Item GetCropObject();
		public abstract int GetPickedID();

		public FarmableCrop( int itemID ) : base( itemID )
		{
			Movable = false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			Map map = this.Map;
			Point3D loc = this.Location;

			if ( Parent != null || Movable || IsLockedDown || IsSecure || map == null || map == Map.Internal )
				return;

			if ( !from.InRange( loc, 2 ) || !from.InLOS( this ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( !m_Picked )
				OnPicked( from, loc, map );
		}

		public virtual void OnPicked( Mobile from, Point3D loc, Map map )
		{
			ItemID = GetPickedID();

			Item spawn = GetCropObject();

			if ( spawn != null )
				spawn.MoveToWorld( loc, map );

			m_Picked = true;

			Unlink();

			Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerCallback( Delete ) );
		}

		public void Unlink()
		{
			ISpawner se = this.Spawner;

			if ( se != null )
			{
				this.Spawner.Remove( this );
				this.Spawner = null;
			}

		}

		public FarmableCrop( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version

			writer.Write( m_Picked );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
					m_Picked = reader.ReadBool();
					break;
			}
			if ( m_Picked )
			{
				Unlink();
				Delete();
			}
		}
	}
}
