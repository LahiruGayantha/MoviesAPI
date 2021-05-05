using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class InAppStorageService : IFilesStorageService
    {
        private readonly string connection;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InAppStorageService(IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            this.connection = configuration.GetConnectionString("");
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string fileRoute, string containerName,string ContentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extention, string containerName, string fileRoute, string ContentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(byte[] content, string extention, string container,string ContentType)
        {
            throw new NotImplementedException();
        }
    }
}
