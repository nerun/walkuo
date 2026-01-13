/* ***************************************************************************
 * Info.cs
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
using Server.Accounting;
using Server.Engines;
using Server.Engines.Help;

namespace Server.Engines.Reports
{
    public abstract class BaseInfo : IComparable
    {
        private static TimeSpan m_SortRange;

        public static TimeSpan SortRange{ get{ return m_SortRange; } set{ m_SortRange = value; } }

        private string m_Account;
        private string m_Display;
        private PageInfoCollection m_Pages;

        public string Account{ get{ return m_Account; } set{ m_Account = value; } }
        public PageInfoCollection Pages{ get{ return m_Pages; } set{ m_Pages = value; } }

        public string Display
        {
            get
            {
                if ( m_Display != null )
                    return m_Display;

                if ( m_Account != null )
                {
                    IAccount acct = Accounts.GetAccount( m_Account );

                    if ( acct != null )
                    {
                        Mobile mob = null;

                        for ( int i = 0; i < acct.Length; ++i )
                        {
                            Mobile check = acct[i];

                            if ( check != null && (mob == null || check.AccessLevel > mob.AccessLevel) )
                                mob = check;
                        }

                        if ( mob != null && mob.Name != null && mob.Name.Length > 0 )
                            return ( m_Display = mob.Name );
                    }
                }

                return ( m_Display = m_Account );
            }
        }

        public int GetPageCount( PageResolution res, DateTime min, DateTime max )
        {
            return StaffHistory.GetPageCount( m_Pages, res, min, max );
        }

        public BaseInfo( string account )
        {
            m_Account = account;
            m_Pages = new PageInfoCollection();
        }

        public void Register( PageInfo page )
        {
            m_Pages.Add( page );
        }

        public void Unregister( PageInfo page )
        {
            m_Pages.Remove( page );
        }

        public int CompareTo( object obj )
        {
            BaseInfo cmp = obj as BaseInfo;

            int v = cmp.GetPageCount( cmp is StaffInfo ? PageResolution.Handled : PageResolution.None, DateTime.UtcNow - m_SortRange, DateTime.UtcNow )
                - this.GetPageCount( this is StaffInfo ? PageResolution.Handled : PageResolution.None, DateTime.UtcNow - m_SortRange, DateTime.UtcNow );

            if ( v == 0 )
                v = String.Compare( this.Display, cmp.Display );

            return v;
        }
    }

    public class StaffInfo : BaseInfo
    {
        public StaffInfo( string account ) : base( account )
        {
        }
    }

    public class UserInfo : BaseInfo
    {
        public UserInfo( string account ) : base( account )
        {
        }
    }
}
