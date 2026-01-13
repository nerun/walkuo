/* ***************************************************************************
 * LightningStrike.cs
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
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells.Bushido
{
    public class LightningStrike : SamuraiMove
    {
        public LightningStrike()
        {
        }

        public override int BaseMana{ get{ return 5; } }
        public override double RequiredSkill{ get{ return 50.0; } }

        public override TextDefinition AbilityMessage{ get{ return new TextDefinition( 1063167 ); } } // You prepare to strike quickly.

        public override bool DelayedContext{ get{ return true; } }

        public override int GetAccuracyBonus( Mobile attacker )
        {
            return 50;
        }

        public override bool Validate(Mobile from)
        {
            bool isValid=base.Validate(from);
            if (isValid)
            {
                PlayerMobile ThePlayer = from as PlayerMobile;
                ThePlayer.ExecutesLightningStrike = BaseMana;
            }
            return isValid;
        }

        public override bool IgnoreArmor( Mobile attacker )
        {
            double bushido = attacker.Skills[SkillName.Bushido].Value;
            double criticalChance = (bushido * bushido) / 72000.0;
            return ( criticalChance >= Utility.RandomDouble() );
        }

        public override bool OnBeforeSwing( Mobile attacker, Mobile defender )
        {
            /* no mana drain before actual hit */
            bool enoughMana = CheckMana(attacker, false);
            return Validate(attacker);
        }

        public override bool ValidatesDuringHit { get { return false; } }

        public override void OnHit( Mobile attacker, Mobile defender, int damage )
        {
            ClearCurrentMove(attacker);
            if (CheckMana(attacker, true))
            {
                attacker.SendLocalizedMessage(1063168); // You attack with lightning precision!
                defender.SendLocalizedMessage(1063169); // Your opponent's quick strike causes extra damage!
                defender.FixedParticles(0x3818, 1, 11, 0x13A8, 0, 0, EffectLayer.Waist);
                defender.PlaySound(0x51D);
                CheckGain(attacker);
                SetContext(attacker);
            }
        }

        public override void OnClearMove( Mobile attacker )
        {
            PlayerMobile ThePlayer = attacker as PlayerMobile; // this can be deletet if the PlayerMobile parts are moved to Server.Mobile 
            ThePlayer.ExecutesLightningStrike = 0;
        }
    }
}
