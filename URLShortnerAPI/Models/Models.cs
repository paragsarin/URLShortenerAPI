namespace URLShortnerAPI.Models
{
    public class ShortenURLRequest
    {
        public string LongURL { get; set; }
    }

    public class ShortenURLResponse
    {
        public string ShortURL { get; set; }
    }
}
