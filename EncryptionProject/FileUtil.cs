using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EncryptionProject
{
    class FileUtil
    {
        public static string RenameFile(string path, string newName)
        {
            return new StringBuilder().Append(Path.GetDirectoryName(Path.GetFullPath(path))).Append(Path.DirectorySeparatorChar).Append(Path.GetFileNameWithoutExtension(path)).Append("-encrypted").Append(Path.GetExtension(path)).ToString();
        }
    }
}
