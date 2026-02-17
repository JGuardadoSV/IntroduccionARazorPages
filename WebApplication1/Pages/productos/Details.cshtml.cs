using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entidades;

namespace WebApplication1.Pages.productos
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Entidades.Contexto _context;

        public DetailsModel(WebApplication1.Entidades.Contexto context)
        {
            _context = context;
        }

        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (producto is not null)
            {
                Producto = producto;

                return Page();
            }

            return NotFound();
        }
    }
}
