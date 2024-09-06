using System;
using System.IO;
using System.Security.AccessControl;

namespace HB_Shell.Parents
{
    class DirectoryAccessControl
    {
        protected private void LockDirectory(string path)
        {
            DirectorySecurity ds = Directory.GetAccessControl(path);
            FileSystemAccessRule fsar = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.AddAccessRule(fsar);
            Directory.SetAccessControl(path, ds);
        }
        protected private void UnLockDirectory(string path)
        {
            DirectorySecurity ds = Directory.GetAccessControl(path);
            FileSystemAccessRule fsar = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            ds.RemoveAccessRule(fsar);
            Directory.SetAccessControl(path, ds);
        }
    }
}
