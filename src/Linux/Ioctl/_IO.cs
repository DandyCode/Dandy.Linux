using System;
using System.Runtime.InteropServices;

namespace Dandy.Linux.Ioctl
{
    /// <summary>
    /// Static functions and values for creating ioctl request values.
    /// </summary>
    public static class _IO
    {
        const int _IOC_NRBITS = 8;
        const int _IOC_TYPEBITS = 8;

        // FIXME: these 2 values are different on alpha, powerpc, mips
        const int _IOC_SIZEBITS = 14;
        // const int _IOC_DIRBITS = 2;

        // const int _IOC_NRMASK = (1 << _IOC_NRBITS) - 1;
        // const int _IOC_TYPEMASK = (1 << _IOC_TYPEBITS) - 1;
        // const int _IOC_SIZEMASK = (1 << _IOC_SIZEBITS) - 1;
        // const int _IOC_DIRMASK = (1 << _IOC_DIRBITS) - 1;

        const int _IOC_NRSHIFT = 0;
        const int _IOC_TYPESHIFT = _IOC_NRSHIFT + _IOC_NRBITS;
        const int _IOC_SIZESHIFT = _IOC_TYPESHIFT + _IOC_TYPEBITS;
        const int _IOC_DIRSHIFT = _IOC_SIZESHIFT + _IOC_SIZEBITS;

        // FIXME: these 3 values are different on alpha, powerpc, mips, sparc

        /// <summary>
        /// Empty IO direction flag value
        /// </summary>
        public const int C_NONE = 0;

        /// <summary>
        /// Write IO direction flag value
        /// </summary>
        public const int C_WRITE = 1;

        /// <summary>
        /// Read IO direction flag value
        /// </summary>
        public const int C_READ = 2;

        /// <summary>
        /// Create an ioctl request value.
        /// </summary>
        public static int C(int dir, int type, int nr, int size) =>
            (dir << _IOC_DIRSHIFT) |
             (type << _IOC_TYPESHIFT) |
             (nr << _IOC_NRSHIFT) |
             (size << _IOC_SIZESHIFT);

        // static int _IO(int type, int nr) => C(C_NONE, type, nr, 0);

        /// <summary>
        /// Creates an ioctl request for reading.
        /// </summary>
        public static int R(int type, int nr, Type size) => C(C_READ, type, nr, Marshal.SizeOf(size));

        /// <summary>
        /// Creates an ioctl request for writing.
        /// </summary>
        public static int W(int type, int nr, Type size) => C(C_WRITE, type, nr, Marshal.SizeOf(size));

        /// <summary>
        /// Creates an ioctl request for writing and reading.
        /// </summary>
        public static int WR(int type, int nr, Type size) => C(C_READ | C_WRITE, type, nr, Marshal.SizeOf(size));

        /// <summary>
        /// Creates an ioctl request for reading.
        /// </summary>
        public static int R(int type, int nr, int size) => C(C_READ, type, nr, size);

        /// <summary>
        /// Creates an ioctl request for writing.
        /// </summary>
        public static int W(int type, int nr, int size) => C(C_WRITE, type, nr, size);

        /// <summary>
        /// Creates an ioctl request for writing and reading.
        /// </summary>
        public static int WR(int type, int nr, int size) => C(C_READ | C_WRITE, type, nr, size);

        // static int _IOC_DIR(int nr) => (nr >> _IOC_DIRSHIFT) & _IOC_DIRMASK;
        // static int _IOC_TYPE(int nr) => (nr >> _IOC_TYPESHIFT) & _IOC_TYPEMASK;
        // static int _IOC_NR(int nr) => (nr >> _IOC_NRSHIFT) & _IOC_NRMASK;
        // static int _IOC_SIZE(int nr) => (nr >> _IOC_SIZESHIFT) & _IOC_SIZEMASK;

        // const int IOC_IN = C_WRITE << _IOC_DIRSHIFT;
        // const int IOC_OUT = C_READ << _IOC_DIRSHIFT;
        // const int IOC_INOUT = (C_WRITE | C_READ) << _IOC_DIRSHIFT;
        // const int IOCSIZE_MASK = _IOC_SIZEMASK << _IOC_SIZESHIFT;
        // const int IOCSIZE_SHIFT = _IOC_SIZESHIFT;
    }
}
