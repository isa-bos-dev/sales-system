namespace MyStore.Application.Interfaces
{
    public interface IFileStorageService
    {
        // Saves an image and returns the path used to retrieve it later
        Task<string> SaveImageAsync(Stream imageStream, string fileName);

        // Deletes a stored image, returns false when there was nothing to delete
        Task <bool> DeleteImageAsync(string imagePath);
    }
}
