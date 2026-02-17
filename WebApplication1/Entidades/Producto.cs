using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Entidades
{
    
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio ")]
        [StringLength(150)]
        [Display(Name = "Nombre del Producto ")]
        public string Nombre { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10, 2) ")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor a 0 ")]
        public decimal Precio { get; set; }
        [Display(Name = "Cantidad en Stock ")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        // Clave foránea
        [Required]
        [Display(Name = "Categoría ")]
        public int CategoriaId { get; set; }
        // Propiedad de navegación hacia Categoria
        public Categoria? Categoria { get; set; }
    }
}
