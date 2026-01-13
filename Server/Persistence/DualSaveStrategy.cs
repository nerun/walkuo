/* ***************************************************************************
 * DualSaveStrategy.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C) 2002  The RunUO Software Team
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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

using Server;
using Server.Guilds;

namespace Server {
    public sealed class DualSaveStrategy : StandardSaveStrategy {
        public override string Name {
            get { return "Dual"; }
        }

        public DualSaveStrategy() {
        }

        public override void Save( SaveMetrics metrics, bool permitBackgroundWrite ) 
        {
            this.PermitBackgroundWrite = permitBackgroundWrite;

            Thread saveThread = new Thread( delegate() {
                SaveItems(metrics);
            } );

            saveThread.Name = "Item Save Subset";
            saveThread.Start();

            SaveMobiles(metrics);
            SaveGuilds(metrics);

            saveThread.Join();

            if (permitBackgroundWrite && UseSequentialWriters)    //If we're permitted to write in the background, but we don't anyways, then notify.
                World.NotifyDiskWriteComplete();
        }
    }
}
