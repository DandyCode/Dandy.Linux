using System;

namespace Dandy.Linux.Input
{
    /// <summary>
    /// Indicates the type of bus an input device is connected to.
    /// </summary>
    public enum Bus
    {
        /// <summary>
        /// The PCI bus.
        /// </summary>
        PCI = 0x01,

        /// <summary>
        /// The ISA plug-and-play bus.
        /// </summary>
        ISAPNP = 0x02,

        /// <summary>
        /// The USB bus.
        /// </summary>
        USB = 0x03,

        /// <summary>
        /// The HIL bus.
        /// </summary>
        HIL = 0x04,

        /// <summary>
        /// The Bluetooth bus.
        /// </summary>
        BLUETOOTH = 0x05,

        /// <summary>
        /// The virtual bus.
        /// </summary>
        VIRTUAL = 0x06,

        /// <summary>
        /// The PCI bus.
        /// </summary>
        ISA = 0x10,

        /// <summary>
        /// The I8042 bus.
        /// </summary>
        I8042 = 0x11,

        /// <summary>
        /// The XTKBD bus.
        /// </summary>
        XTKBD = 0x12,

        /// <summary>
        /// The RS232 bus.
        /// </summary>
        RS232 = 0x13,

        /// <summary>
        /// The game port bus.
        /// </summary>
        GAMEPORT = 0x14,

        /// <summary>
        /// The par port bus.
        /// </summary>
        PARPORT = 0x15,

        /// <summary>
        /// The Amiga bus.
        /// </summary>
        AMIGA = 0x16,

        /// <summary>
        /// The ADB bus.
        /// </summary>
        ADB = 0x17,

        /// <summary>
        /// The I2C bus.
        /// </summary>
        I2C = 0x18,

        /// <summary>
        /// The host bus.
        /// </summary>
        HOST = 0x19,

        /// <summary>
        /// The GSC bus.
        /// </summary>
        GSC = 0x1A,

        /// <summary>
        /// The Atari bus.
        /// </summary>
        ATARI = 0x1B,

        /// <summary>
        /// The SPI bus.
        /// </summary>
        SPI = 0x1C,

        /// <summary>
        /// The RMI bus.
        /// </summary>
        RMI = 0x1D,

        /// <summary>
        /// The CEC bus.
        /// </summary>
        CEC = 0x1E,

        /// <summary>
        /// The Intel ISH bus.
        /// </summary>
        INTEL_ISHTP = 0x1F,
    }
}
