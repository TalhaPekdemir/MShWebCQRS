using Microsoft.AspNetCore.Http;

namespace MShWeb.Application.Services.Files
{
    public interface IFileService
    {
        Task<FileInfo> SaveFileAsync(IFormFile file);

        Task<ICollection<FileInfo>> SaveFilesAsync(ICollection<IFormFile> files);
        
        Task<FileInfo> SaveFile(IFormFile file);

        Task<ICollection<FileInfo>> SaveFiles(ICollection<IFormFile> files);
    }
}
