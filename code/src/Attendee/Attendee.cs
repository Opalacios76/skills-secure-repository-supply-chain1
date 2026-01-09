using System;
using System.IO;
using System.IO.Compression;

namespace Attendees
{

    public class Attendee
    {
        public void WriteToDirectory(ZipArchiveEntry entry, string destDirectory)
        {
            // Combine the destination directory with the entry name and resolve to a full path
            string destFileName = Path.GetFullPath(Path.Combine(destDirectory, entry.FullName));

            // Resolve the destination directory to a full path (ensure it ends with a separator)
            string fullDestDirPath = Path.GetFullPath(destDirectory + Path.DirectorySeparatorChar);

            // Prevent Zip Slip by ensuring the destination file is within the destination directory
            if (!destFileName.StartsWith(fullDestDirPath, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Entry is outside the target dir: " + destFileName);
            }

            entry.ExtractToFile(destFileName);
        }
        
        public bool AddAttendee(string added)
        {
            if (added == "exists") {
                  return true;
            }
            return false;
        }      
    }
}