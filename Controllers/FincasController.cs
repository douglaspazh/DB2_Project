using DB2_Project.Data;
using DB2_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DB2_Project.Controllers
{
    public class FincasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FincasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fincas
        public async Task<IActionResult> Index()
        {
            // Cargar las fincas con sus productores relacionados
            var fincas = await _context.Fincas
                .Include(f => f.Productor)
                .ToListAsync();
            return View(fincas);
        }

        // GET: Fincas/Registrar
        public async Task<IActionResult> Registrar()
        {
            ViewBag.Productores = await _context.Productores.Select(p => new SelectListItem
            {
                Value = p.ProductorID.ToString(),
                Text = p.Nombre
            }).ToListAsync();
            return View();
        }

        // POST: Fincas/Registrar
        [HttpPost]
        public async Task<IActionResult> Registrar(Finca finca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Fincas.Add(finca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Manejo de excepciones, por ejemplo, si hay un error de duplicado
                    ModelState.AddModelError("", "Error al registrar la finca: " + ex.InnerException?.Message ?? ex.Message);
                    Console.WriteLine( ex.ToString() );
                }
                catch (Exception ex)
                {
                    // Manejo de otras excepciones
                    ModelState.AddModelError("", "Error inesperado: " + ex.Message);
                    Console.WriteLine( ex.ToString() );
                }
            }
            else
            {
                ModelState.AddModelError("", "Por favor, corrija los errores en el formulario.");
                foreach ( var modelStateEntry in ModelState )
                {
                    foreach ( var error in modelStateEntry.Value.Errors )
                    {
                        Console.WriteLine( $"Error en campo '{modelStateEntry.Key}': {error.ErrorMessage}" );
                    }
                }
            }
            ViewBag.Productores = await _context.Productores.Select( p => new SelectListItem
                {
                    Value = p.ProductorID.ToString(),
                    Text = p.Nombre
                } ).ToListAsync();

            return View(finca);
        }

        // GET: Fincas/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var finca = await _context.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }
            var productores = await _context.Productores.ToListAsync();
            ViewBag.Productores = productores;
            return View(finca);
        }

        // POST: Fincas/Editar/5
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Finca finca)
        {
            if (id != finca.FincaID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FincaExists(finca.FincaID))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var productores = await _context.Productores.ToListAsync();
            ViewBag.Productores = productores;
            return View(finca);
        }

        // GET: Fincas/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var finca = await _context.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }
            return View(finca);
        }

        // POST: Fincas/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmed(int id)
        {
            var finca = await _context.Fincas.FindAsync(id);
            if (finca != null)
            {
                _context.Fincas.Remove(finca);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Método auxiliar para verificar si una finca existe
        private bool FincaExists( int id )
        {
            return _context.Fincas.Any( e => e.FincaID == id );
        }
    }
}
