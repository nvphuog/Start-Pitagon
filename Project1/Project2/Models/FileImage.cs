using Microsoft.AspNetCore.Http;

namespace Project2.Models
{
    public class FileImage
    {
        public IFormFileCollection Image { get; set; }
    }
}