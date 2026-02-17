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
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Entidades.Contexto _context;

        public IndexModel(WebApplication1.Entidades.Contexto context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Producto = await _context.Productos
                .Include(p => p.Categoria).ToListAsync();
        }
    }
}
