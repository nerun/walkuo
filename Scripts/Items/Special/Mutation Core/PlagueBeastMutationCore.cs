/* ***************************************************************************
 * PlagueBeastMutationCore.cs
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
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
    public class PlagueBeastMutationCore : Item, IScissorable
    {
        private bool m_Cut;

        [CommandProperty( AccessLevel.GameMaster )]
        public bool Cut
        {
            get { return m_Cut; }
            set { m_Cut = value; }
        }

        [Constructable]
        public PlagueBeastMutationCore() : base( 0x1CF0 )
        {
            m_Cut = true;

            Name = "a plague beast mutation core";
            Weight = 1.0;
            Hue = 0x480;
        }

        public virtual bool Scissor( Mobile from, Scissors scissors )
        {
            if ( !m_Cut )
            {
                PlagueBeastLord owner = RootParent as PlagueBeastLord;

                m_Cut = true;
                Movable = true;

                from.AddToBackpack( this );
                from.LocalOverheadMessage( MessageType.Regular, 0x34, 1071906 ); // * You remove the plague mutation core from the plague beast, causing it to dissolve into a pile of goo *                

                if ( owner != null )
                    Timer.DelayCall<PlagueBeastLord>( TimeSpan.FromSeconds( 1 ), new TimerStateCallback<PlagueBeastLord>( KillParent ), owner );

                return true;
            }

            return false;
        }

        private void KillParent( PlagueBeastLord parent )
        {
            parent.Unfreeze();
            parent.Kill();
        }

        public PlagueBeastMutationCore( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.WriteEncodedInt( 0 ); // version

            writer.Write( (bool) m_Cut );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadEncodedInt();

            m_Cut = reader.ReadBool();
        }
    }
}
