using System;
using System.Collections.Generic;
using System.IO.Hashing;
using System.Linq;


namespace SystemDesign.TinyUrl
{
    public class TinyUrl : ITinyUrl
    {
        private readonly TinyUrlDbContext _db;
       
        public TinyUrl(TinyUrlDbContext tinyUrlDbContext)
        {
            _db = tinyUrlDbContext;
            
        }
        public string CreateTinyUrl(string LongUrl)
        {
            ICollection<byte> lubytes = new List<byte>();
            foreach(char ch in LongUrl)
            {
                foreach(byte b in BitConverter.GetBytes(ch))
                    lubytes.Add(b);
            }
            var hashValue = Crc32.Hash(lubytes.ToArray());            
            string stringHashValue = BitConverter.ToString(hashValue).Replace("-","");

            //Select and check if short url already exist
            var url = _db.UrlMaster.SingleOrDefault(x => x.ShortUrl == stringHashValue);
            if (url != null)
            {
                Console.WriteLine("ShortUrl already Exist!!");
                return url.ShortUrl;
            }                    
            else
            {
                _db.UrlMaster.Add(new UrlMaster { ShortUrl = stringHashValue, LongUrl = LongUrl });
                _db.SaveChanges();

                return stringHashValue;
            }
            
        }

        public string GetLongUrl(string TinyUrl)
        {
            var longUrl = _db.UrlMaster.SingleOrDefault(x => x.ShortUrl == TinyUrl);
            
            if (longUrl != null)
                return longUrl.LongUrl;
            else
                return "Tiny Url Does Not Exist!!";
        }
    }
}
