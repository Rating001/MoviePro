namespace MoviePro.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> EncodeImageAsync(IFormFile poster);
        Task<byte[]> EncodeImageURLAsyc(string imageURL);
        string DecodeImage(byte[] poster, string contentType);
    }
}
