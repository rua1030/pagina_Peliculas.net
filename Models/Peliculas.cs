using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Peliculas 
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]

        public string imagen { get; set; }

        [Required(ErrorMessage = "campo obligatorio")] 
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]
        public string? director { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]
        public string? duracion { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]
        public string? categoria { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]

        public int stars { get; set; }

        [Required(ErrorMessage = "campo obligatorio")]
        public DateTime FechaCreacion { get; set; }
        }
}
