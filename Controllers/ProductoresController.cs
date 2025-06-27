using DB2_Project.Data;
using DB2_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB2_Project.Controllers
{
    public class ProductoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoresController( ApplicationDbContext context )
        {
            _context = context;
        }

        // GET: Productores
        public async Task<IActionResult> Index()
        {
            var productores = await _context.Productores.ToListAsync();
            return View(productores);
        }

        // GET: Productores/Registrar
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Productores/Registrar
        [HttpPost]
        public async Task<IActionResult> Registrar( Productor productor )
        {
            if ( ModelState.IsValid )
            {
                _context.Productores.Add( productor );
                await _context.SaveChangesAsync();
                return RedirectToAction( nameof(Index) );
            }
            return View( productor );
        }

        // GET: Productores/Editar/5
        public async Task<IActionResult> Editar( int id )
        {
            var productor = await _context.Productores.FindAsync( id );
            if ( productor == null )
            {
                return NotFound();
            }
            return View( productor );
        }

        // POST: Productores/Editar/5
        [HttpPost]
        public async Task<IActionResult> Editar( int id, Productor productor )
        {
            if ( id != productor.ProductorID )
            {
                return NotFound();
            }
            if ( ModelState.IsValid )
            {
                _context.Update( productor );
                await _context.SaveChangesAsync();
                return RedirectToAction( nameof(Index) );
            }
            return View( productor );
        }

        // GET: Productores/Eliminar/5
        public async Task<IActionResult> Eliminar( int id )
        {
            var productor = await _context.Productores.FindAsync( id );
            if ( productor == null )
            {
                return NotFound();
            }
            return View( productor );
        }

        // POST: Productores/Eliminar/5
        [HttpPost, ActionName( "Eliminar" )]
        public async Task<IActionResult> EliminarConfirmed( int id )
        {
            var productor = await _context.Productores.FindAsync( id );
            if ( productor != null )
            {
                _context.Productores.Remove( productor );
                await _context.SaveChangesAsync();
            }
            return RedirectToAction( nameof(Index) );
        }
    }
}
