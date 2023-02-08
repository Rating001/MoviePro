using MoviePro.Services.Interfaces;

namespace MoviePro.Services
{
    public class ImageService : IImageService
    {
        public string DecodeImage(byte[] poster, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageAsync(IFormFile poster)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> EncodeImageURLAsyc(string imageURL)
        {
            throw new NotImplementedException();
        }
    }
}
