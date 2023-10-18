using System.ComponentModel.DataAnnotations;

namespace P11_Galeria.Models
{
    public class Obra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        public string ArtType { get; set; }
        [StringLength(9)]
        public string Year { get; set; }
        public string PhotoName { get; set; }
    }
}
