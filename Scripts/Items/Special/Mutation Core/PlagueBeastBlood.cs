/* ***************************************************************************
 * PlagueBeastBlood.cs
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

namespace Server.Items
{
	public class PlagueBeastBlood : PlagueBeastComponent
	{
		public bool Patched
		{
			get { return ItemID == 0x1765; }
		}

		public bool Starting
		{
			get { return ItemID == 0x122C; }
		}

		private Timer m_Timer;

		public PlagueBeastBlood() : base( 0x122C, 0 )
		{
			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 1.5 ), TimeSpan.FromSeconds( 1.5 ), 3, new TimerCallback( Hemorrhage ) );
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null && m_Timer.Running )
				m_Timer.Stop();
		}

		public override bool OnBandage( Mobile from )
		{
			if ( IsAccessibleTo( from ) && !Patched )
			{
				if ( m_Timer != null && m_Timer.Running )
					m_Timer.Stop();

				if ( Starting )
				{
					X += 2;
					Y -= 9;

					if ( Organ is PlagueBeastRubbleOrgan )
						Y -= 5;
					else if ( Organ is PlagueBeastBackupOrgan )
						X += 7;
				}
				else
				{
					X -= 4;
					Y -= 2;
				}

				ItemID = 0x1765;

				if ( Owner != null )
				{
					Container pack = Owner.Backpack;

					if ( pack != null )
					{
						for ( int i = 0; i < pack.Items.Count; i++ )
						{
							PlagueBeastMainOrgan main = pack.Items[ i ] as PlagueBeastMainOrgan;

							if ( main != null && main.Complete )
								main.FinishOpening( from );
						}
					}
				}

				PublicOverheadMessage( MessageType.Regular, 0x3B2, 1071916 ); // * You patch up the wound with a bandage *

				return true;
			}

			return false;
		}

		private void Hemorrhage()
		{
			if ( Patched )
				return;

			if ( Owner != null )
				Owner.PlaySound( 0x25 );

			if ( ItemID == 0x122A )
			{
				if ( Owner != null )
				{
					Owner.Unfreeze();
					Owner.Kill();
				}
			}
			else
			{
				if ( Starting )
				{
					X += 8;
					Y -= 10;
				}

				ItemID--;
			}
		}		

		public PlagueBeastBlood( Serial serial ) : base( serial )
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
