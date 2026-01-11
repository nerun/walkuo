/* ***************************************************************************
 * WhereExtension.cs
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
using System.Text;
using Server.Commands;

namespace Server.Commands.Generic
{
	public sealed class WhereExtension : BaseExtension
	{
		public static ExtensionInfo ExtInfo = new ExtensionInfo( 20, "Where", -1, delegate() { return new WhereExtension(); } );

		public static void Initialize()
		{
			ExtensionInfo.Register( ExtInfo );
		}

		public override ExtensionInfo Info
		{
			get { return ExtInfo; }
		}

		private ObjectConditional m_Conditional;

		public ObjectConditional Conditional
		{
			get { return m_Conditional; }
		}

		public WhereExtension()
		{
		}

		public override void Optimize( Mobile from, Type baseType, ref AssemblyEmitter assembly )
		{
			if ( baseType == null )
				throw new InvalidOperationException( "Insanity." );

			m_Conditional.Compile( ref assembly );
		}

		public override void Parse( Mobile from, string[] arguments, int offset, int size )
		{
			if ( size < 1 )
				throw new Exception( "Invalid condition syntax." );

			m_Conditional = ObjectConditional.ParseDirect( from, arguments, offset, size );
		}

		public override bool IsValid( object obj )
		{
			return m_Conditional.CheckCondition( obj );
		}
	}
}
