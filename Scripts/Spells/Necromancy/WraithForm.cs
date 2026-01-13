/* ***************************************************************************
 * WraithForm.cs
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
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells.Necromancy
{
    public class WraithFormSpell : TransformationSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Wraith Form", "Rel Xen Um",
                203,
                9031,
                Reagent.NoxCrystal,
                Reagent.PigIron
            );

        public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

        public override double RequiredSkill{ get{ return 20.0; } }
        public override int RequiredMana{ get{ return 17; } }

        public override int Body{ get{ return Caster.Female ? 747 : 748; } }
        public override int Hue{ get{ return Caster.Female ? 0 : 0x4001; } }

        public override int PhysResistOffset{ get{ return +15; } }
        public override int FireResistOffset{ get{ return -5; } }
        public override int ColdResistOffset{ get{ return  0; } }
        public override int PoisResistOffset{ get{ return  0; } }
        public override int NrgyResistOffset{ get{ return -5; } }

        public WraithFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void DoEffect( Mobile m )
        {
            if ( m is PlayerMobile )
                ((PlayerMobile)m).IgnoreMobiles = true;
            
            m.PlaySound( 0x17F );
            m.FixedParticles( 0x374A, 1, 15, 9902, 1108, 4, EffectLayer.Waist );
        }
        
        public override void RemoveEffect( Mobile m )
        {
            if ( m is PlayerMobile && m.AccessLevel == AccessLevel.Player )
                ((PlayerMobile)m).IgnoreMobiles = false;
        }
    }
}
