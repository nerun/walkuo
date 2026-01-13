/* ***************************************************************************
 * BladedItemTarget.cs
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
using Server.Targeting;
using Server.Items;
using Server.Engines.Harvest;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Engines.Quests.Hag;

namespace Server.Targets
{
    public class BladedItemTarget : Target
    {
        private Item m_Item;

        public BladedItemTarget( Item item ) : base( 2, false, TargetFlags.None )
        {
            m_Item = item;
        }

        protected override void OnTargetOutOfRange( Mobile from, object targeted )
        {
            if ( targeted is UnholyBone && from.InRange( ((UnholyBone)targeted), 12 ) )
                ((UnholyBone)targeted).Carve( from, m_Item );
            else
                base.OnTargetOutOfRange (from, targeted);
        }

        protected override void OnTarget( Mobile from, object targeted )
        {
            if ( m_Item.Deleted )
                return;

            if ( targeted is ICarvable )
            {
                ((ICarvable)targeted).Carve( from, m_Item );
            }
            else if ( targeted is SwampDragon && ((SwampDragon)targeted).HasBarding )
            {
                SwampDragon pet = (SwampDragon)targeted;

                if ( !pet.Controlled || pet.ControlMaster != from )
                    from.SendLocalizedMessage( 1053022 ); // You cannot remove barding from a swamp dragon you do not own.
                else
                    pet.HasBarding = false;
            }
            else
            {
                if ( targeted is StaticTarget )
                {
                    int itemID = ((StaticTarget)targeted).ItemID;

                    if ( itemID == 0xD15 || itemID == 0xD16 ) // red mushroom
                    {
                        PlayerMobile player = from as PlayerMobile;

                        if ( player != null )
                        {
                            QuestSystem qs = player.Quest;

                            if ( qs is WitchApprenticeQuest )
                            {
                                FindIngredientObjective obj = qs.FindObjective( typeof( FindIngredientObjective ) ) as FindIngredientObjective;

                                if ( obj != null && !obj.Completed && obj.Ingredient == Ingredient.RedMushrooms )
                                {
                                    player.SendLocalizedMessage( 1055036 ); // You slice a red cap mushroom from its stem.
                                    obj.Complete();
                                    return;
                                }
                            }
                        }
                    }
                }

                HarvestSystem system = Lumberjacking.System;
                HarvestDefinition def = Lumberjacking.System.Definition;

                int tileID;
                Map map;
                Point3D loc;

                if ( !system.GetHarvestDetails( from, m_Item, targeted, out tileID, out map, out loc ) )
                {
                    from.SendLocalizedMessage( 500494 ); // You can't use a bladed item on that!
                }
                else if ( !def.Validate( tileID ) )
                {
                    from.SendLocalizedMessage( 500494 ); // You can't use a bladed item on that!
                }
                else
                {
                    HarvestBank bank = def.GetBank( map, loc.X, loc.Y );

                    if ( bank == null )
                        return;

                    if ( bank.Current < 5 )
                    {
                        from.SendLocalizedMessage( 500493 ); // There's not enough wood here to harvest.
                    }
                    else
                    {
                        bank.Consume( 5, from );

                        Item item = new Kindling();

                        if ( from.PlaceInBackpack( item ) )
                        {
                            from.SendLocalizedMessage( 500491 ); // You put some kindling into your backpack.
                            from.SendLocalizedMessage( 500492 ); // An axe would probably get you more wood.
                        }
                        else
                        {
                            from.SendLocalizedMessage( 500490 ); // You can't place any kindling into your backpack!

                            item.Delete();
                        }
                    }
                }
            }
        }
    }
}
