using System;
using System.Runtime.InteropServices;

namespace Dandy.Linux.Ioctl
{
    /// <summary>
    /// Provides common bindings for ioctl using basic types
    /// </summary>
    public static class Syscall
    {
        /// <summary>
        /// The name of the standard C library. For use with DllImport.
        /// </summary>
        public const string StandardLibraryName = "c";

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, byte value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, short value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, ushort value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, int value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, uint value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, long value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, ulong value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, IntPtr value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, UIntPtr value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out byte value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out short value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out ushort value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out int value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out uint value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out long value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out ulong value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out IntPtr value);

        /// <summary>
        /// Performs an ioctl syscall.
        /// </summary>
        [DllImport(StandardLibraryName)]
        public static extern int ioctl(int fd, int cmd, out UIntPtr value);
    }
}
