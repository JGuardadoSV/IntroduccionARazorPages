using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Entidades
{
    
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio ")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Nombre de Categoría ")]
        public string Nombre { get; set; } = string.Empty;
        [StringLength(250)]
        public string? Descripcion { get; set; }
        // Propiedad de navegación: una categoría tiene muchos productos
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
