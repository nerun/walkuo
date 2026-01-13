/* ***************************************************************************
 * GlobalCommandImplementor.cs
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
using Server;

namespace Server.Commands.Generic
{
    public class GlobalCommandImplementor : BaseCommandImplementor
    {
        public GlobalCommandImplementor()
        {
            Accessors = new string[]{ "Global" };
            SupportRequirement = CommandSupport.Global;
            SupportsConditionals = true;
            AccessLevel = AccessLevel.Administrator;
            Usage = "Global <command> [condition]";
            Description = "Invokes the command on all appropriate objects in the world. Optional condition arguments can further restrict the set of objects.";
        }

        public override void Compile( Mobile from, BaseCommand command, ref string[] args, ref object obj )
        {
            try
            {
                Extensions ext = Extensions.Parse( from, ref args );

                bool items, mobiles;

                if ( !CheckObjectTypes( from, command, ext, out items, out mobiles ) )
                    return;

                ArrayList list = new ArrayList();

                if ( items )
                {
                    foreach ( Item item in World.Items.Values )
                    {
                        if ( ext.IsValid( item ) )
                            list.Add( item );
                    }
                }

                if ( mobiles )
                {
                    foreach ( Mobile mob in World.Mobiles.Values )
                    {
                        if ( ext.IsValid( mob ) )
                            list.Add( mob );
                    }
                }

                ext.Filter( list );

                obj = list;
            }
            catch ( Exception ex )
            {
                from.SendMessage( ex.Message );
            }
        }
    }
}
