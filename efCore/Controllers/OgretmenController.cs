using efCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efCore.Controllers
{
    public class OgretmenController : Controller{

         private readonly DataContext _context;

        public OgretmenController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Ogretmenler.ToListAsync());
        }

        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model){

            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id){

            if(id == null){
                return NotFound();
            }
            var ogr = await _context
            .Ogretmenler
            .FirstOrDefaultAsync(o => o.OgretmenId == id);
            if(ogr == null){
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogretmen model){
            if(id != model.OgretmenId){
                return NotFound();
            }

            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id){

            if(id == null){
                return NotFound();
            }
            var ogr = await _context.Ogretmenler.FindAsync(id);

            if(ogr == null){
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id){
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if(ogretmen == null){
                return NotFound();
            }
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}