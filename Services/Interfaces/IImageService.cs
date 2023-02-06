namespace MoviePro.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync(IFormFile poster);
        Task<byte[]> EncodeImageURLAsycn(string imageURL);
        string DecodeImage(byte[] poster, string contentType);
    }
}
