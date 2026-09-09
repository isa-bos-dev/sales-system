
namespace MyStore.Infrastructure.Options
{
    public record FileStorageOption
    {
        public string BaseUrl { get; set; }

        public string ImagesFolder { get; set; }
    }
}
