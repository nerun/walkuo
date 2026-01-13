/* ***************************************************************************
 * TransformationSpell.cs
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
using System.Collections.Generic;
using Server;
using Server.Spells.Fifth;
using Server.Spells.Seventh;

namespace Server.Spells.Necromancy
{
    public abstract class TransformationSpell : NecromancerSpell, ITransformationSpell
    {
        public abstract int Body{ get; }
        public virtual int Hue{ get{ return 0; } }

        public virtual int PhysResistOffset{ get{ return 0; } }
        public virtual int FireResistOffset{ get{ return 0; } }
        public virtual int ColdResistOffset{ get{ return 0; } }
        public virtual int PoisResistOffset{ get{ return 0; } }
        public virtual int NrgyResistOffset{ get{ return 0; } }

        public TransformationSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
        {
        }

        public override bool BlockedByHorrificBeast{ get{ return false; } }

        public override bool CheckCast()
        {
            if( !TransformationSpellHelper.CheckCast( Caster, this ) )
                return false;

            return base.CheckCast();
        }

        public override void OnCast()
        {
            TransformationSpellHelper.OnCast( Caster, this );

            FinishSequence();
        }

        public virtual double TickRate{ get{ return 1.0; } }

        public virtual void OnTick( Mobile m )
        {
        }

        public virtual void DoEffect( Mobile m )
        {
        }

        public virtual void RemoveEffect( Mobile m )
        {
        }
    }
}
