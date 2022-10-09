namespace SystemDesign.TinyUrl
{
    //interface
    public interface ITinyUrl
    {
        //POST
        public string CreateTinyUrl(string LongUrl);
        //GET
        public string GetLongUrl(string TinyUrl);
    }
}
