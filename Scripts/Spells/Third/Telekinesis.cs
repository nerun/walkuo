/* ***************************************************************************
 * Telekinesis.cs
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
using Server.Targeting;
using Server.Network;
using Server.Regions;
using Server.Items;

namespace Server.Spells.Third
{
    public class TelekinesisSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Telekinesis", "Ort Por Ylem",
                203,
                9031,
                Reagent.Bloodmoss,
                Reagent.MandrakeRoot
            );

        public override SpellCircle Circle { get { return SpellCircle.Third; } }

        public TelekinesisSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget( this );
        }

        public void Target( ITelekinesisable obj )
        {
            if ( CheckSequence() )
            {
                SpellHelper.Turn( Caster, obj );

                obj.OnTelekinesis( Caster );
            }

            FinishSequence();
        }

        public void Target( Container item )
        {
            if ( CheckSequence() )
            {
                SpellHelper.Turn( Caster, item );

                object root = item.RootParent;

                if ( !item.IsAccessibleTo( Caster ) )
                {
                    item.OnDoubleClickNotAccessible( Caster );
                }
                else if ( !item.CheckItemUse( Caster, item ) )
                {
                }
                else if ( root != null && root is Mobile && root != Caster )
                {
                    item.OnSnoop( Caster );
                }
                else if ( item is Corpse && !((Corpse)item).CheckLoot( Caster, null ) )
                {
                }
                else if ( Caster.Region.OnDoubleClick( Caster, item ) )
                {
                    Effects.SendLocationParticles( EffectItem.Create( item.Location, item.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5022 );
                    Effects.PlaySound( item.Location, item.Map, 0x1F5 );

                    item.OnItemUsed( Caster, item );
                }
            }

            FinishSequence();
        }

        public class InternalTarget : Target
        {
            private TelekinesisSpell m_Owner;

            public InternalTarget( TelekinesisSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.None )
            {
                m_Owner = owner;
            }

            protected override void OnTarget( Mobile from, object o )
            {
                if ( o is ITelekinesisable )
                    m_Owner.Target( (ITelekinesisable)o );
                else if ( o is Container )
                    m_Owner.Target( (Container)o );
                else
                    from.SendLocalizedMessage( 501857 ); // This spell won't work on that!
            }

            protected override void OnTargetFinish( Mobile from )
            {
                m_Owner.FinishSequence();
            }
        }
    }
}

namespace Server
{
    public interface ITelekinesisable : IPoint3D
    {
        void OnTelekinesis( Mobile from );
    }
}
