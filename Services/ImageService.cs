using MoviePro.Services.Interfaces;

namespace MoviePro.Services
{
    public class ImageService : IImageService
    {
        private readonly IHttpClientFactory _httpClient;

        public ImageService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public string DecodeImage(byte[] poster, string contentType)
        {
            if (poster is null || contentType is null) return null;
            return $"data:image/{contentType};base64,{Convert.ToBase64String(poster)}";
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile poster)
        {
            if (poster is null) return null;
            using var stream = new MemoryStream() ;
            await poster.CopyToAsync(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> EncodeImageURLAsyc(string imageURL)
        {
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync(imageURL);

            using Stream stream = await response.Content.ReadAsStreamAsync();
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
