/* ***************************************************************************
 * Disrobe.cs
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
    /// <summary>
    /// This attack allows you to disrobe your foe.
    /// </summary>
    public class Disrobe : WeaponAbility
    {
        public Disrobe()
        {
        }

        public override int BaseMana{ get{ return 20; } } // Not Sure what amount of mana a creature uses.

        public static readonly TimeSpan BlockEquipDuration = TimeSpan.FromSeconds( 5.0 );

        public override void OnHit( Mobile attacker, Mobile defender, int damage )
        {
            if ( !Validate( attacker ) )
                return;

            ClearCurrentAbility( attacker );
            Item toDisrobe = defender.FindItemOnLayer(Layer.InnerTorso);            

            if ( toDisrobe == null || !toDisrobe.Movable )
                toDisrobe = defender.FindItemOnLayer( Layer.OuterTorso );

            Container pack = defender.Backpack;

            if ( pack == null || toDisrobe == null || !toDisrobe.Movable )
            {
                attacker.SendLocalizedMessage(1004001); // You cannot disarm your opponent.
            }
            else if ( CheckMana( attacker, true ) )
            {
                //attacker.SendLocalizedMessage( 1060092 ); // You disarm their weapon!
                defender.SendLocalizedMessage(1062002); // You can no longer wear your ~1_ARMOR~

                defender.PlaySound( 0x3B9 );
                //defender.FixedParticles( 0x37BE, 232, 25, 9948, EffectLayer.InnerTorso );

                pack.DropItem( toDisrobe );

                BaseWeapon.BlockEquip( defender, BlockEquipDuration );
            }
        }
    }
}
