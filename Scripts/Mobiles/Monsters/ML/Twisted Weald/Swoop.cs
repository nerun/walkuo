/* ***************************************************************************
 * Swoop.cs
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
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName( "a Swoop corpse" )]
    public class Swoop : Eagle
    {
        [Constructable]
        public Swoop()
        {
            IsParagon = true;

            Name = "Swoop";
            Hue = 0xE0;

            AI = AIType.AI_Melee;

            SetStr( 100, 150 );
            SetDex( 400, 500 );
            SetInt( 80, 90 );

            SetHits( 1500, 2000 );

            SetDamage( 20, 30 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 75, 90 );
            SetResistance( ResistanceType.Fire, 60, 77 );
            SetResistance( ResistanceType.Cold, 70, 85 );
            SetResistance( ResistanceType.Poison, 55, 85 );
            SetResistance( ResistanceType.Energy, 50, 60 );

            SetSkill( SkillName.Wrestling, 120.0, 140.0 );
            SetSkill( SkillName.Tactics, 120.0, 140.0 );
            SetSkill( SkillName.MagicResist, 95.0, 105.0 );

            Fame = 18000;
            Karma = 0;

            PackReg( 4 );
            PackArcaneScroll( 0, 1 );
        }

        public override void GenerateLoot()
        {
            AddLoot( LootPack.UltraRich, 2 );
        }

        // TODO: Put this attack shared with Hiryu and Lesser Hiryu in one place
        public override void OnGaveMeleeAttack( Mobile defender )
        {
            base.OnGaveMeleeAttack( defender );

            if( 0.1 > Utility.RandomDouble() )
            {
                ExpireTimer timer = (ExpireTimer)m_Table[defender];

                if( timer != null )
                {
                    timer.DoExpire();
                    defender.SendLocalizedMessage( 1070837 ); // The creature lands another blow in your weakened state.
                }
                else
                    defender.SendLocalizedMessage( 1070836 ); // The blow from the creature's claws has made you more susceptible to physical attacks.

                int effect = -(defender.PhysicalResistance * 15 / 100);

                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, effect );

                defender.FixedEffect( 0x37B9, 10, 5 );
                defender.AddResistanceMod( mod );

                timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 5.0 ) );
                timer.Start();
                m_Table[defender] = timer;
            }
        }

        private static Hashtable m_Table = new Hashtable();

        private class ExpireTimer : Timer
        {
            private Mobile m_Mobile;
            private ResistanceMod m_Mod;

            public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay )
                : base( delay )
            {
                m_Mobile = m;
                m_Mod = mod;
                Priority = TimerPriority.TwoFiftyMS;
            }

            public void DoExpire()
            {
                m_Mobile.RemoveResistanceMod( m_Mod );
                Stop();
                m_Table.Remove( m_Mobile );
            }

            protected override void OnTick()
            {
                m_Mobile.SendLocalizedMessage( 1070838 ); // Your resistance to physical attacks has returned.
                DoExpire();
            }
        }

        public override bool CanFly { get { return true; } }
        public override bool GivesMLMinorArtifact{ get{ return true; } }
        public override int Feathers{ get{ return 72; } }

        /*
        // TODO: uncomment once added
        public override void OnDeath( Container c )
        {
            base.OnDeath( c );

            if ( Utility.RandomDouble() < 0.025 )
            {
                switch ( Utility.Random( 18 ) )
                {
                    case 0: c.DropItem( new AssassinChest() ); break;
                    case 1: c.DropItem( new AssassinArms() ); break;
                    case 2: c.DropItem( new DeathChest() );    break;
                    case 3: c.DropItem( new MyrmidonArms() ); break;
                    case 4: c.DropItem( new MyrmidonLegs() ); break;
                    case 5: c.DropItem( new MyrmidonGorget() ); break;
                    case 6: c.DropItem( new LeafweaveGloves() ); break;
                    case 7: c.DropItem( new LeafweaveLegs() ); break;
                    case 8: c.DropItem( new LeafweavePauldrons() ); break;
                    case 9: c.DropItem( new PaladinGloves() ); break;
                    case 10: c.DropItem( new PaladinGorget() ); break;
                    case 11: c.DropItem( new PaladinArms() ); break;
                    case 12: c.DropItem( new HunterArms() ); break;
                    case 13: c.DropItem( new HunterGloves() ); break;
                    case 14: c.DropItem( new HunterLegs() ); break;
                    case 15: c.DropItem( new HunterChest() ); break;
                    case 16: c.DropItem( new GreymistArms() ); break;
                    case 17: c.DropItem( new GreymistGloves() ); break;
                }
            }

            if ( Utility.RandomDouble() < 0.1 )
                c.DropItem( new ParrotItem() );
        }
        */

        public Swoop( Serial serial )
            : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
