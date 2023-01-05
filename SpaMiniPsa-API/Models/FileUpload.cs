using SpaMiniPsa_API.Entities;

namespace SpaMiniPsa_API.Models
{
    public class FileUpload
    {
        public IFormFile File { get; set; }
        public string Dog { get; set; }
    }
}
