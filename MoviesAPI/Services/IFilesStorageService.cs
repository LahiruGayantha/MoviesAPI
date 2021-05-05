using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IFilesStorageService
    {
        Task<string> EditFile(byte[] content, string extention, string containerName, string fileRoute, string ContentType);
        Task DeleteFile(string fileRoute, string containerName, string ContentType);
        Task<string> SaveFile(byte[] content, string extention, string container, string ContentType);
    }
}
