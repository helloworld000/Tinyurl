using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SystemDesign.TinyUrl
{
    //models
    public class UrlMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? ShortUrl { get; set; }
        public string? LongUrl { get; set; }
    }
}
