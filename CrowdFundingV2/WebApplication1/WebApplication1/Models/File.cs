using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class File
    {
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}