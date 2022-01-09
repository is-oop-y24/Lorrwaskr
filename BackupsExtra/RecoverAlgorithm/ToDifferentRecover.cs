using System.IO;
using System.IO.Compression;
using Backups.JobObject;
using Backups.RestorePoint;

namespace BackupsExtra.RecoverAlgorithm
{
    public class ToDifferentRecover : IRecoverAlgorithm<FileInfo, DirectoryInfo>
    {
        public void Run(IRestorePoint<FileInfo> restorePoint, DirectoryInfo repositoryDestination, DirectoryInfo destination)
        {
            string startDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory($"{repositoryDestination.FullName}/{restorePoint.Name}");
            foreach (IJobObject<FileInfo> jobObject in restorePoint.JobObjects)
            {
                ZipFile.ExtractToDirectory($"./{jobObject.Name}", destination.FullName);
            }

            Directory.SetCurrentDirectory(startDir);
        }
    }
}