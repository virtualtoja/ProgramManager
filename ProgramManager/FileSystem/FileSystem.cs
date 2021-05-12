using System.Text;
using System;
using Cosmos.System.FileSystem.VFS;

namespace ProgramManager.FileSystem
{
    public static class Filesystem
    {
        public static string ReadFile(string path)
        {
            try
            {
                var hello_file = VFSManager.GetFile(path);
                var hello_file_stream = hello_file.GetFileStream();

                if (hello_file_stream.CanRead)
                {
                    byte[] text_to_read = new byte[hello_file_stream.Length];
                    hello_file_stream.Read(text_to_read, 0, (int)hello_file_stream.Length);
                    return Encoding.Default.GetString(text_to_read);
                }
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        public static void CreateFile(string path)
        {
            VFSManager.CreateFile(path);
        }

        public static void WriteToFile(string path, string content)
        {
            var hello_file = VFSManager.GetFile(path);
            var hello_file_stream = hello_file.GetFileStream();

            if (hello_file_stream.CanWrite)
            {
                byte[] text_to_write = Encoding.ASCII.GetBytes(content);
                hello_file_stream.Write(text_to_write, 0, text_to_write.Length);
            }
        }
    }
}
