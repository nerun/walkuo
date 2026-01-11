# Rebranding Notes

RunUO to WalkUO

Remaining "RunUO":

```bash
$ grep --exclude-dir='.git' -Rnw 'RunUO' . | grep -v 'copyright'
./Scripts/Misc/Email.cs:56:            // Nothing to configure on MailKit side; kept for RunUO compatibility.
./Server/Persistence/SaveMetrics.cs:28:     private const string PerformanceCategoryName = "RunUO 2.1";
./Server/Persistence/SaveMetrics.cs:29:     private const string PerformanceCategoryDesc = "Performance counters for RunUO 2.1.";
./README.md:3:WalkUO is a fork of RunUO, an Ultima Online server, focused on long-term maintenance and gradual evolution.
```

"runuo" is no more:

```bash
$ grep --exclude-dir='.git' -Rnw 'runuo' . | grep -v 'info@'
```

### What else remains?

Many scripts have a header like this:

```
/***************************************************************************
 *                              ScriptName.cs
 *                            -------------------
 *   begin                : Month D, YYYY
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id$
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
```

It's curious that many scripts don't have headers.
