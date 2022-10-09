using Microsoft.AspNetCore.Mvc;
using SystemDesign.TinyUrl;
using Tinyurl.Models;

namespace Tinyurl.Controllers
{
    [Route("api/v1/[controller]/")]
    public class TinyurlController : ControllerBase
    {
        private readonly ITinyUrl _tinyUrl;

        public TinyurlController(ITinyUrl tinyUrl)
        {
            _tinyUrl = tinyUrl;
        }
        [HttpGet]
        [Route("{url}")]
        public IActionResult Get(string url)
        {
            var longUrl = _tinyUrl.GetLongUrl(url);
            return RedirectPermanent(longUrl);
            //return Ok(longUrl);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Url url)
        {
            var shortUrl = _tinyUrl.CreateTinyUrl(url.longUrl);
            return Ok(shortUrl);
        }
    }
}
