namespace SystemDesign.TinyUrl
{
    public class TestTinyUrl
    {
        private readonly TinyUrlDbContext _db;
        private TinyUrl _tinyUrl; 

        public TestTinyUrl()
        {
            _db = new TinyUrlDbContext();
            _tinyUrl =new TinyUrl(_db);
        }

        public void RunTest()
        {
            //Create a short url
            Console.WriteLine("Test Post / Create");
            Console.WriteLine("LongURL: https://zoro.to/watch/sword-art-online-2274?ep=26566");
            Console.WriteLine("ShortUrl: "+_tinyUrl.CreateTinyUrl("https://zoro.to/watch/sword-art-online-2274?ep=26566"));
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Test Get / LongUrl");
            Console.WriteLine("ShortUrl: 134EA069");
            Console.WriteLine("LongUrl: " + _tinyUrl.GetLongUrl("134EA069"));
            Console.WriteLine();
            Console.WriteLine("Test Get / LongUrl");
            Console.WriteLine("ShortUrl: 134EA061");
            Console.WriteLine("LongUrl: " + _tinyUrl.GetLongUrl("134EA061"));

        }
    }
}
