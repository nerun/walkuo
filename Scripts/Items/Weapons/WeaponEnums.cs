/* ***************************************************************************
 * WeaponEnums.cs
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

namespace Server.Items
{
	public enum WeaponQuality
	{
		Low,
		Regular,
		Exceptional
	}

	public enum WeaponType
	{
		Axe,		// Axes, Hatches, etc. These can give concussion blows
		Slashing,	// Katana, Broadsword, Longsword, etc. Slashing weapons are poisonable
		Staff,		// Staves
		Bashing,	// War Hammers, Maces, Mauls, etc. Two-handed bashing delivers crushing blows
		Piercing,	// Spears, Warforks, Daggers, etc. Two-handed piercing delivers paralyzing blows
		Polearm,	// Halberd, Bardiche
		Ranged,		// Bow, Crossbows
		Fists		// Fists
	}

	public enum WeaponDamageLevel
	{
		Regular,
		Ruin,
		Might,
		Force,
		Power,
		Vanq
	}

	public enum WeaponAccuracyLevel
	{
		Regular,
		Accurate,
		Surpassingly,
		Eminently,
		Exceedingly,
		Supremely
	}

	public enum WeaponDurabilityLevel
	{
		Regular,
		Durable,
		Substantial,
		Massive,
		Fortified,
		Indestructible
	}

	public enum WeaponAnimation
	{
		Slash1H = 9,
		Pierce1H = 10,
		Bash1H = 11,
		Bash2H = 12,
		Slash2H = 13,
		Pierce2H = 14,
		ShootBow = 18,
		ShootXBow = 19,
		Wrestle = 31
	}
}
