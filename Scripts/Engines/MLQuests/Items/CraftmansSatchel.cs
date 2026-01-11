/* ***************************************************************************
 * CraftmansSatchel.cs
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
﻿using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
	public abstract class BaseCraftmansSatchel : Backpack
	{
		protected static readonly Type[] m_TalismanType = new Type[] { typeof( RandomTalisman ) };

		public BaseCraftmansSatchel()
		{
			Hue = Utility.RandomBrightHue();
		}

		protected void AddBaseLoot( params Type[][] lootSets )
		{
			Item loot = Loot.Construct( lootSets[Utility.Random( lootSets.Length )] );

			if ( loot == null )
				return;

			RewardBag.Enhance( loot );
			DropItem( loot );
		}

		protected void AddRecipe( CraftSystem system )
		{
			// TODO: change craftable artifact recipes to a rarer drop
			int recipeID = system.RandomRecipe();

			if ( recipeID != -1 )
				DropItem( new RecipeScroll( recipeID ) );
		}

		public BaseCraftmansSatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class TailorSatchel : BaseCraftmansSatchel
	{
		[Constructable]
		public TailorSatchel()
		{
			AddBaseLoot( Loot.MLArmorTypes, Loot.JewelryTypes, m_TalismanType );

			if ( Utility.RandomDouble() < 0.50 )
				AddRecipe( DefTailoring.CraftSystem );
		}

		public TailorSatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class BlacksmithSatchel : BaseCraftmansSatchel
	{
		[Constructable]
		public BlacksmithSatchel()
		{
			AddBaseLoot( Loot.MLWeaponTypes, Loot.JewelryTypes, m_TalismanType );

			if ( Utility.RandomDouble() < 0.50 )
				AddRecipe( DefBlacksmithy.CraftSystem );
		}

		public BlacksmithSatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class TinkerSatchel : BaseCraftmansSatchel
	{
		[Constructable]
		public TinkerSatchel()
		{
			AddBaseLoot( Loot.MLArmorTypes, Loot.MLWeaponTypes, Loot.MLRangedWeaponTypes, Loot.JewelryTypes, m_TalismanType );

			if ( Utility.RandomDouble() < 0.50 )
			{
				// TODO: Add recipe drops (drops include inscription, alchemy and drops from non-artifact recipes for tailoring, blacksmith, carpentry and fletching.
				switch ( Utility.Random( 6 ) )
				{
					case 0: AddRecipe( DefInscription.CraftSystem ); break;
					case 1: AddRecipe( DefAlchemy.CraftSystem ); break;
					// TODO
					//case 2: AddNonArtifactRecipe( DefTailoring.CraftSystem ); break;
					//case 3: AddNonArtifactRecipe( DefBlacksmithy.CraftSystem ); break;
					//case 4: AddNonArtifactRecipe( DefCarpentry.CraftSystem ); break;
					//case 5: AddNonArtifactRecipe( DefBowFletching.CraftSystem ); break;
				}
			}
		}

		public TinkerSatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FletchingSatchel : BaseCraftmansSatchel
	{
		[Constructable]
		public FletchingSatchel()
		{
			AddBaseLoot( Loot.MLRangedWeaponTypes, Loot.JewelryTypes, m_TalismanType );

			if ( Utility.RandomDouble() < 0.50 )
				AddRecipe( DefBowFletching.CraftSystem );

			// TODO: runic fletching kit
		}

		public FletchingSatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class CarpentrySatchel : BaseCraftmansSatchel
	{
		[Constructable]
		public CarpentrySatchel()
		{
			AddBaseLoot( Loot.MLArmorTypes, Loot.MLWeaponTypes, Loot.MLRangedWeaponTypes, Loot.JewelryTypes, m_TalismanType );

			if ( Utility.RandomDouble() < 0.50 )
				AddRecipe( DefCarpentry.CraftSystem );

			// TODO: Add runic dovetail saw
		}

		public CarpentrySatchel( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
