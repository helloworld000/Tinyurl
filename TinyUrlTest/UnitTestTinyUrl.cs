using Moq;
using NUnit.Framework;
using SystemDesign.TinyUrl;
using Tinyurl.Controllers;
using Tinyurl.Models;

namespace TinyUrlTest
{
    public class Tests
    {
        Mock<ITinyUrl>? _moq;
        TinyurlController _ctrlr;
        [SetUp]
        public void Setup()
        {
            _moq = new Mock<ITinyUrl>();            
            _moq.Setup(p => p.CreateTinyUrl(It.IsAny<string>())).Returns("1B097B7D");
            _moq.Setup(p=>p.GetLongUrl(It.IsAny<string>())).Returns("https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences#:~:text=AddScoped()%20%2D%20This%20method%20creates,within%20that%20same%20web%20request.");
            _ctrlr = new TinyurlController(_moq.Object);
        }

        [Test]
        public void TestGetLongUrl()
        {
            _ctrlr.Get("1B097B7D");//500E7370

            _moq.Verify(p => p.GetLongUrl(It.IsAny<string>()), Times.Once());
            
        }
        [Test]
        public void TestCreateTinyUrl()
        {
            _ctrlr.Post(new Url { longUrl = "https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences#:~:text=AddScoped()%20%2D%20This%20method%20creates,within%20that%20same%20web%20request." });

            _moq.Verify(p => p.CreateTinyUrl(It.IsAny<string>()), Times.Once());
        }
    }
}