using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(Stream imageStream, string fileName);

        Task <bool> DeleteImageAsync(string imagePath);
    }
}
