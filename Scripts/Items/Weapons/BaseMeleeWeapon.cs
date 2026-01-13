/* ***************************************************************************
 * BaseMeleeWeapon.cs
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
using Server.Spells.Spellweaving;

namespace Server.Items
{
    public abstract class BaseMeleeWeapon : BaseWeapon
    {
        public BaseMeleeWeapon( int itemID ) : base( itemID )
        {
        }

        public BaseMeleeWeapon( Serial serial ) : base( serial )
        {
        }

        public override int AbsorbDamage( Mobile attacker, Mobile defender, int damage )
        {
            damage = base.AbsorbDamage( attacker, defender, damage );

            AttuneWeaponSpell.TryAbsorb( defender, ref damage );

            if ( Core.AOS )
                return damage;

            int absorb = defender.MeleeDamageAbsorb;

            if ( absorb > 0 )
            {
                if ( absorb > damage )
                {
                    int react = damage / 5;

                    if ( react <= 0 )
                        react = 1;

                    defender.MeleeDamageAbsorb -= damage;
                    damage = 0;

                    attacker.Damage( react, defender );

                    attacker.PlaySound( 0x1F1 );
                    attacker.FixedEffect( 0x374A, 10, 16 );
                }
                else
                {
                    defender.MeleeDamageAbsorb = 0;
                    defender.SendLocalizedMessage( 1005556 ); // Your reactive armor spell has been nullified.
                    DefensiveSpell.Nullify( defender );
                }
            }

            return damage;
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
        }
    }
}
