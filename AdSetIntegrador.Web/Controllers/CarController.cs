using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AdSetIntegrador.Data;
using AdSetIntegrador.Data.Entities;
using AdSetIntegrador.Data.Data;

namespace AdSetIntegrador.Web.Controllers
{
    

    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Car
        public async Task<IActionResult> Index(string placa, string marca, string modelo, int? anoMin, int? anoMax, string preco, string fotos, string cor)
        {
            var query = _context.Cars.AsQueryable();

           
            if (!string.IsNullOrEmpty(placa))
            {
                query = query.Where(c => c.Placa.ToLower().Contains(placa.ToLower()));
            }
            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(c => c.Marca.ToLower().Contains(marca.ToLower()));
            }
            if (!string.IsNullOrEmpty(modelo))
            {
                query = query.Where(c => c.Modelo.ToLower().Contains(modelo.ToLower()));
            }
            if (anoMin != null)
            {
                query = query.Where(c => c.Ano >= anoMin);
            }
            if (anoMax != null)
            {
                query = query.Where(c => c.Ano <= anoMax);
            }
            if (!string.IsNullOrEmpty(preco))
            {
                switch (preco)
                {
                    case "10-50":
                        query = query.Where(c => c.Preco >= 10000 && c.Preco <= 50000);
                        break;
                    case "50-90":
                        query = query.Where(c => c.Preco > 50000 && c.Preco <= 90000);
                        break;
                    case "90+":
                        query = query.Where(c => c.Preco > 90000);
                        break;
                }
            }
            if (!string.IsNullOrEmpty(fotos))
            {
                switch (fotos)
                {
                    case "com":
                        query = query.Where(c => c.Fotos.Any());
                        break;
                    case "sem":
                        query = query.Where(c => !c.Fotos.Any());
                        break;
                }
            }
            if (!string.IsNullOrEmpty(cor))
            {
                query = query.Where(c => c.Cor.ToLower() == cor.ToLower());
            }

            var cars = await query.ToListAsync();

            return View(cars);
        }


        // GET: /Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: /Car/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Modelo,Ano,Placa,Km,Cor,Preco,Opcionais,Fotos")] Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    car.Opcionais = Request.Form["Opcionais"].ToList();
                    //if (car.Fotos != null && car.Fotos.Count > 0)
                    //{
                    //    foreach (var file in car.Fotos)
                    //    {
                    //        if (file.Length > 0)
                    //        {
                    //            using (var memoryStream = new MemoryStream())
                    //            {
                    //                await file.CopyToAsync(memoryStream);
                    //                car.Fotos.Add(Convert.ToBase64String(memoryStream.ToArray()));
                    //            }
                    //        }
                    //    }
                    //}

                    _context.Add(car);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }
                else
                {

                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return Json(new { success = false, errors = errors });
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", $"Erro: {ex.Message}");

                return Json(new { success = false, message = ex.Message });
            }
        }





        // GET: /Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

    }
}