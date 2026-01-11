/* ***************************************************************************
 * NativeReader.cs
 *
 * RunUO is an open-source server emulator for Ultima Online.
 * Copyright (C) 2002  The RunUO Software Team
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
using System.Runtime.InteropServices;
using System.Threading;

namespace Server {
	public static class NativeReader {

		private static readonly INativeReader m_NativeReader;

		static NativeReader() {
			if ( Core.Unix )
				m_NativeReader = new NativeReaderUnix();
			else
				m_NativeReader = new NativeReaderWin32();
		}

		public static unsafe void Read( IntPtr ptr, void *buffer, int length ) {
			m_NativeReader.Read( ptr, buffer, length );
		}
	}

	public interface INativeReader {
		unsafe void Read( IntPtr ptr, void *buffer, int length );
	}

	public sealed class NativeReaderWin32 : INativeReader {
		internal class UnsafeNativeMethods {
			/*[DllImport("kernel32")]
			internal unsafe static extern int _lread(IntPtr hFile, void* lpBuffer, int wBytes);*/

			[DllImport("kernel32")]
			internal unsafe static extern bool ReadFile(IntPtr hFile, void* lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, NativeOverlapped* lpOverlapped);
		}

		public NativeReaderWin32() {
		}

		public unsafe void Read( IntPtr ptr, void *buffer, int length ) {
			//UnsafeNativeMethods._lread( ptr, buffer, length );
			uint lpNumberOfBytesRead = 0;
			UnsafeNativeMethods.ReadFile(ptr, buffer, (uint)length, ref lpNumberOfBytesRead, null);
		}
	}

	public sealed class NativeReaderUnix : INativeReader {
		internal class UnsafeNativeMethods {
			[DllImport("libc")]
			internal unsafe static extern int read(IntPtr ptr, void* buffer, int length);
		}

		public NativeReaderUnix() {
		}

		public unsafe void Read( IntPtr ptr, void *buffer, int length ) {
			UnsafeNativeMethods.read( ptr, buffer, length );
		}
	}
}
