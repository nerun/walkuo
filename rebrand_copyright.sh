#!/usr/bin/env zsh

# Script for copyright rebranding. Make a backup snapshot before using!
# This script would have been nearly impossible for a normal person to create
# without the help of an AI like ChatGPT (January 11, 2026).

HEADER_TEMPLATE='/* ***************************************************************************
 * SCRIPTNAME
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C)SYYYY  The RunUO Software Team
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
 ***************************************************************************/'

for file in Scripts/**/*.cs Server/**/*.cs; do
    [[ -f $file ]] || continue
    filename=$(basename "$file")

    # Extracts the year from the old header, if present.
    year=$(grep -m1 -E 'begin\s*:\s*[A-Za-z]+\s+[0-9]+,\s+([0-9]{4})' "$file" \
            | sed -E 's/.*,\s([0-9]{4}).*/\1/')
    [[ -n $year ]] && syyyy=" $year" || syyyy=""

    # Assemble the updated header.
    header=$(echo "$HEADER_TEMPLATE" | sed "s/SCRIPTNAME/$filename/" | sed "s/SYYYY/$syyyy/")

    # Remove all initial comment blocks until you find actual code.
    awk '
    BEGIN {skip=1}
    {
        if (skip) {
            # If a line starts with /* or *, it continues skipping lines.
            if ($0 ~ /^[[:space:]]*\/\*/ || $0 ~ /^[[:space:]]*\*/) { next }
            # If the line is empty, skip as well.
            if ($0 ~ /^[[:space:]]*$/) { next }
            # Found a line of code, stop jumping.
            skip=0
        }
        print
    }' "$file" > "$file.content"

    # Write the final file with the new header at the top.
    {
        printf "%s\n" "$header"
        cat "$file.content"
    } > "$file"

    rm "$file.content"
    echo "Updated header: $file"
done
