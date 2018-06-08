using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Dandy.Linux.Udev;
using Xunit;

using static System.Reflection.BindingFlags;

namespace Dandy.Linux.Test.UdevTests
{
    public class ContextTests
    {
        const string LibraryName = "udev";

        [DllImport(LibraryName)]
        static extern IntPtr udev_ref(IntPtr udev);

        [DllImport(LibraryName)]
        static extern IntPtr udev_unref(IntPtr udev);

        [Fact]
        public void TestWeakRef()
        {
            var getInstance = typeof(Context).GetMethod("GetInstance", Static | NonPublic);
            using (var udev = new Context()) {
                var handle = udev.Handle;

                // as long as the udev object has not been disposed, we should
                // be able to retrive it from the unmanged udev context
                var udev2 = (Context)getInstance.Invoke(null, new object[]{ handle });
                Assert.True(object.ReferenceEquals(udev, udev2));

                udev_ref(handle);
                try {
                    // once the instance is disposed though, trying to get the
                    // managed instance from the unmanged context should return
                    // a new managed object.
                    udev.Dispose();
                    udev2 = (Context)getInstance.Invoke(null, new object[]{ handle });
                    Assert.False(object.ReferenceEquals(udev, udev2));
                    udev2.Dispose();
                }
                finally {
                    udev_unref(handle);
                }
            }
        }
    }
}
