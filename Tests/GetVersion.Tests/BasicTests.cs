using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace GetVersion.Tests
{
    [TestFixture]
    public class BasicTests
    {
        [Test]
        public void TestParseDirectorStructureToListFiles()
        {
            Console.WriteLine("Getting version information from file in path: " + Path.GetFullPath("./"));

            var list = VersionEntry.GetVersionEntriesFromDirectoryScan("./");

            foreach (var entry in list)
            {
                Console.WriteLine("{0}\t({1})", entry.Path, entry.VersionInfo.FileVersion);
            }

        }
    }
}
