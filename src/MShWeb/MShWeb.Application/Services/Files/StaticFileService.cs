using Microsoft.AspNetCore.Http;
using MShWeb.Application.Services.Helpers;

namespace MShWeb.Application.Services.Files
{
    public class StaticFileService : IFileService
    {
        public async Task<FileInfo> SaveFileAsync(IFormFile file)
        {
            // requirements: path, filename, extension
            // don't trust filename genrate guid
            // dont trust extension, can be different but can't be bothered to check right now
            // file.ContentType maybe???
            // get path somehow better

            string path = Path.Combine(HttpContextHelper.Env.WebRootPath, "uploads");
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(file.FileName);

            EnsureDirectoryExists(path);

            string pathToSave = Path.Combine(path, fileName + extension);
            using (FileStream stream = File.Create(pathToSave))
            {
                await file.CopyToAsync(stream);
            }

            return new FileInfo(pathToSave);
        }

        public async Task<ICollection<FileInfo>> SaveFilesAsync(ICollection<IFormFile> files)
        {
            List<FileInfo> fileInfos = new();

            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    fileInfos.Add(await SaveFileAsync(file));
                }
            }

            return fileInfos;
        }

        private void EnsureDirectoryExists(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }
    }
}
