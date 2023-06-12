using BuscaCEP.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuscaCEP.Models;


namespace BuscaCEP.Controllers
{
    public class imagemController : Controller
    {
        private readonly AppDbContext _context;

        public imagemController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allImagens = await _context.imagems.ToListAsync();
            return View(allImagens);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(imagem imagem, IList<IFormFile> Img)
        {
            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                imagem.Foto = ms.ToArray();
            }

            _context.imagems.Add(imagem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produto = await _context.imagems.FindAsync(id);
            if (produto == null)
            {
                return BadRequest();
            }

            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produto = await _context.imagems.FindAsync(id);
            if (produto == null)
            {
                return BadRequest();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, imagem imagem, IList<IFormFile> Img)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dadosAntigos = _context.imagems.AsNoTracking().FirstOrDefault(c => c.Id == id);

            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                imagem.Foto = ms.ToArray();
            }
            else
            {
                imagem.Foto = dadosAntigos.Foto;
            }
            if (ModelState.IsValid)
            {
                _context.Update(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(imagem);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.imagems.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var cliente = await _context.imagems.FindAsync(id);
            _context.imagems.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }


}

