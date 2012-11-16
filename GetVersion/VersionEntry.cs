using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace GetVersion
{
    public class VersionEntry
    {
        public String Path { get; private set; }
        public FileVersionInfo VersionInfo { get; private set; }

        public VersionEntry(String path, FileVersionInfo versionInfo)
        {
            VersionInfo = versionInfo;
            Path = path;
        }

        public static List<VersionEntry> GetVersionEntriesFromDirectoryScan(string scanDir)
        {
            var list = new List<VersionEntry>();
            foreach (var dir in Directory.GetDirectories(scanDir))
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    list.Add(new VersionEntry(file, FileVersionInfo.GetVersionInfo(file)));
                }
                list.AddRange(GetVersionEntriesFromDirectoryScan(dir));
            }
            return list;
        }
        
    }
}
