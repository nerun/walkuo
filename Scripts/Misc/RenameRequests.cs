/* ***************************************************************************
 * RenameRequests.cs
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

namespace Server.Misc
{
	public class RenameRequests
	{
		public static void Initialize()
		{
			EventSink.RenameRequest += new RenameRequestEventHandler( EventSink_RenameRequest );
		}

		private static void EventSink_RenameRequest( RenameRequestEventArgs e )
		{
			Mobile from = e.From;
			Mobile targ = e.Target;
			string name = e.Name;

			if ( from.CanSee( targ ) && from.InRange( targ, 12 ) && targ.CanBeRenamedBy( from ) )
			{
				name = name.Trim();

				if( NameVerification.Validate( name, 1, 16, true, false, true, 0, NameVerification.Empty, NameVerification.StartDisallowed, ( Core.ML ? NameVerification.Disallowed :  new string[]{} ) ) )
				{

					if( Core.ML )
					{
						string[] disallowed = ProfanityProtection.Disallowed;

						for( int i = 0; i < disallowed.Length; i++ )
						{
							if( name.IndexOf( disallowed[i] ) != -1 )
							{
								from.SendLocalizedMessage( 1072622 ); // That name isn't very polite.
								return;
							}
						}

						from.SendLocalizedMessage( 1072623, String.Format( "{0}\t{1}", targ.Name, name ) ); // Pet ~1_OLDPETNAME~ renamed to ~2_NEWPETNAME~.
					}

					targ.Name = name;
				}
				else
				{
					from.SendMessage( "That name is unacceptable." );
				}
			}
		}
	}
}
