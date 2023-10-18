using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace P11_Galeria.ViewModels
{
    public class ObraVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        public string ArtType { get; set; }
        [StringLength(9)]
        public string Year { get; set; }
        public IFormFile Photo { get; set; }
    }
}
