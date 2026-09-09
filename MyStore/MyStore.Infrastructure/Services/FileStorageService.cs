using Microsoft.Extensions.Options;
using MyStore.Application.Interfaces;
using MyStore.Infrastructure.Options;

namespace MyStore.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        // Storage settings (base path and images folder) injected from configuration
        private readonly FileStorageOption _options;

        public FileStorageService(IOptions<FileStorageOption> options)
        {
            _options = options.Value;
        }

        // Saves an image stream to disk and returns its public relative URL
        public async Task<string> SaveImageAsync(Stream imageStream, string fileName)
        {
            // Get the file extension in lowercase to keep names consistent
            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            // Build a unique name with a GUID to avoid overwriting existing files
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";

            // Physical folder where images are stored
            var folderPath = Path.Combine(_options.BaseUrl, _options.ImagesFolder);

            // Full physical path of the file to write
            var filePath = Path.Combine(folderPath, fileName);

            // Create the images folder if it does not exist yet
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Copy the incoming stream into the file; 'using' closes the file handle afterwards
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(fileStream);
            }

            // Return the relative URL used by clients to request the image
            return $"/{_options.ImagesFolder}/{uniqueFileName}";
           
        }

        // Deletes an image given its relative URL; returns true only if the file was removed
        public async Task<bool> DeleteImageAsync(string imagePath)
        {
            // Nothing to delete when no path is provided
            if (string.IsNullOrEmpty(imagePath))
                return false;

            // Remove the leading '/' so the path can be combined with the base folder
            var relativePath = imagePath.TrimStart('/');

            // Build the physical path, converting URL separators to the OS separator
            var physicalPath = Path.Combine(_options.BaseUrl, relativePath.Replace('/', Path.DirectorySeparatorChar));

            // Only delete if the file actually exists on disk
            if (File.Exists(physicalPath))
            {
                // Remove the file from disk
                File.Delete(physicalPath);
                // Deletion succeeded
                return await Task.FromResult(true);
            }

            // File was not found, so nothing was deleted
            return await Task.FromResult(false);
        }

    }    
}
