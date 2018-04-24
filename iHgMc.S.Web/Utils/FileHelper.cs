using System;
using System.IO;
using System.Text;

namespace iHgMc.S.Web.Utils
{
    public class FileHelper
    {
        public static void Write(string path, string message)
        {
            if (CheckDirectoryExistOrCreate(path))
            {
                using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(message);
                        sw.Flush();
                    }
                }
            }
        }
        public static bool CheckDirectoryExistOrCreate(string path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    var url = Path.GetDirectoryName(path);
                    if (!string.IsNullOrEmpty(url))
                    {
                        Directory.CreateDirectory(url);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return false;
        }
    }


}