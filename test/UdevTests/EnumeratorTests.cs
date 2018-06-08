using System;
using Xunit;

using Dandy.Linux.Udev;

namespace Dandy.Linux.Test.UdevTests
{
    public class EnumeratorTests
    {
        [Fact]
        public void TestContext()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                Assert.True(ReferenceEquals(e.Context, udev));
            }
        }

        [Fact]
        public void TestAddMatchSubsystem()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchSubsystem("mem");
                e.ScanDevices();
                Assert.Contains(e, d => d.DevNode == "/dev/null");
            }
        }

        [Fact]
        public void TestAddNoMatchSubsystem()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddNoMatchSubsystem("mem");
                e.ScanDevices();
                Assert.NotEmpty(e);
                Assert.DoesNotContain(e, d => d.DevNode == "/dev/null");
            }
        }

        [Fact]
        public void TestAddMatchSysAttribute()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchSysAttribute("uevent");
                e.ScanDevices();
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestAddNoMatchSysAttribute()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                // every device has a uevent attribute
                e.AddNoMatchSysAttribute("uevent");
                e.ScanDevices();
                Assert.Empty(e);
            }
        }

        [Fact]
        public void TestAddMatchProperty()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchProperty("DEVNAME", "/dev/null");
                e.ScanDevices();
                Assert.Single(e);
            }
        }

        [Fact]
        public void TestAddMatchTag()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                // FIXME: this will fail on systems not running systemd
                e.AddMatchTag("systemd");
                e.ScanDevices();
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestAddMatchParent()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchParent(null);
                e.ScanDevices();
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestAddMatchIsInitialized()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchIsInitialized();
                e.ScanDevices();
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestAddMatchSysName()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddMatchSysName("null");
                e.ScanDevices();
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestAddSysPath()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.AddSysPath("/sys/devices/virtual/mem/null");
                Assert.NotEmpty(e);
            }
        }

        [Fact]
        public void TestScanSubsystems()
        {
            using (var udev = new Context())
            using (var e = new Enumerator(udev)) {
                e.ScanSubsystems();
                Assert.NotEmpty(e);
            }
        }
    }
}
