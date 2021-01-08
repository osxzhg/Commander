using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Howto { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}
