/* ***************************************************************************
 * Config.cs
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
using System.Text;
using System.Threading;

namespace Server.Engines.MyRunUO
{
    public class Config
    {
        // Is MyRunUO enabled?
        public static bool Enabled = false;

        // Details required for database connection string
        public const string DatabaseDriver        = "{MySQL ODBC 5.2w Driver}";
        public const string DatabaseServer        = "localhost";
        public const string DatabaseName        = "MyRunUO";
        public const string DatabaseUserID        = "username";
        public const string DatabasePassword    = "password";

        // Should the database use transactions? This is recommended
        public static bool UseTransactions = true;

        // Use optimized table loading techniques? (LOAD DATA INFILE)
        public static bool LoadDataInFile = true;

        // This must be enabled if the database server is on a remote machine.
        public static bool DatabaseNonLocal = ( DatabaseServer != "localhost" );

        // Text encoding used
        public static Encoding EncodingIO = Encoding.ASCII;

        // Database communication is done in a separate thread. This value is the 'priority' of that thread, or, how much CPU it will try to use
        public static ThreadPriority DatabaseThreadPriority = ThreadPriority.BelowNormal;

        // Any character with an AccessLevel equal to or higher than this will not be displayed
        public static AccessLevel HiddenAccessLevel    = AccessLevel.Counselor;

        // Export character database every 30 minutes
        public static TimeSpan CharacterUpdateInterval = TimeSpan.FromMinutes( 30.0 );

        // Export online list database every 5 minutes
        public static TimeSpan StatusUpdateInterval = TimeSpan.FromMinutes( 5.0 );

        public static string CompileConnectionString()
        {
            string connectionString = String.Format( "DRIVER={0};SERVER={1};DATABASE={2};UID={3};PASSWORD={4};",
                DatabaseDriver, DatabaseServer, DatabaseName, DatabaseUserID, DatabasePassword );

            return connectionString;
        }
    }
}
