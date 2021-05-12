using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace ProgramManager.FileSystem
{
    public static class DiskManager
    {
        private static CosmosVFS vfs = new CosmosVFS();

        public static void Initialize()
        {
            VFSManager.RegisterVFS(vfs);
        }

        public static void Format(int driveID)
        {
            vfs.Format(driveID + @":\", "FAT32", true);
        }

        public static long GetSpace(int driveID) => VFSManager.GetAvailableFreeSpace(driveID + ":/");
        public static string GetFileSystem(int driveID) => VFSManager.GetFileSystemType(driveID + ":/");
    }
}
