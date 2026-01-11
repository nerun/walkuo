/* ***************************************************************************
 * ShadowWisp.cs
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
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a shadow wisp corpse" )]
	public class ShadowWispFamiliar : BaseFamiliar
	{
		public ShadowWispFamiliar()
		{
			Name = "a shadow wisp";
			Body = 165;
			Hue = 0x901;
			BaseSoundID = 466;

			SetStr( 50 );
			SetDex( 60 );
			SetInt( 100 );

			SetHits( 50 );
			SetStam( 60 );
			SetMana( 0 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Energy, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 99 );

			SetSkill( SkillName.Wrestling, 40.0 );
			SetSkill( SkillName.Tactics, 40.0 );

			ControlSlots = 1;
		}

		private DateTime m_NextFlare;

		public override void OnThink()
		{
			base.OnThink();

			if ( DateTime.UtcNow < m_NextFlare )
				return;

			m_NextFlare = DateTime.UtcNow + TimeSpan.FromSeconds( 5.0 + (25.0 * Utility.RandomDouble()) );

			this.FixedEffect( 0x37C4, 1, 12, 1109, 6 );
			this.PlaySound( 0x1D3 );

			Timer.DelayCall( TimeSpan.FromSeconds( 0.5 ), new TimerCallback( Flare ) );
		}

		private void Flare()
		{
			Mobile caster = this.ControlMaster;

			if ( caster == null )
				caster = this.SummonMaster;

			if ( caster == null )
				return;

			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 5 ) )
			{
				if ( m.Player && m.Alive && !m.IsDeadBondedPet && m.Karma <= 0 && m.AccessLevel < AccessLevel.Counselor )
					list.Add( m );
			}

			for ( int i = 0; i < list.Count; ++i )
			{
				Mobile m = (Mobile)list[i];
				bool friendly = true;

				for ( int j = 0; friendly && j < caster.Aggressors.Count; ++j )
					friendly = ( caster.Aggressors[j].Attacker != m );

				for ( int j = 0; friendly && j < caster.Aggressed.Count; ++j )
					friendly = ( caster.Aggressed[j].Defender != m );

				if ( friendly )
				{
					m.FixedEffect( 0x37C4, 1, 12, 1109, 3 ); // At player
					m.Mana += 1 - (m.Karma / 1000);
				}
			}
		}

		public ShadowWispFamiliar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
