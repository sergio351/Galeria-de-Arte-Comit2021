using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using ProyectoGaleria.Data;
using ProyectoGaleria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoGaleria.Controllers
{
    [Authorize]
    public class ArtistasController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArtistasController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)

        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //get y post permiten enviar información al servidor
        //http get index
        public IActionResult Index()
        {
            IEnumerable<Artista> listArtistas = _context.Artista;
            return View(listArtistas);
        }
        //http get create
        public IActionResult Create()
        {

            return View();
        }
        //http post create( transferencia de información y datos)
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Artista artista)
        {

            if (ModelState.IsValid)
            {
                //agregar imagenes
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        artista.Imagen = dataStream.ToArray();
                    }

                }

                //agregar imagen perfil
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[1];
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        artista.ImgPerfil = dataStream.ToArray();
                    }

                }
                _context.Artista.Add(artista);
                _context.SaveChanges();
                TempData["mensaje"] = "se guardo exitosamente";
                return RedirectToAction("Index");

            }
            return View();
        }

        //http get edit
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            //obtenemos el artista
            var usuario = _context.Artista.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        //http post edit ( transferencia de información y datos)
        [HttpPost]
        public IActionResult Edit(Artista artista)
        {
            if (ModelState.IsValid)
            {
                _context.Artista.Update(artista);
                _context.SaveChanges();
                TempData["mensaje"] = "se actualizó exitosamente";
                return RedirectToAction("Index");

            }
            return View();
        }
        //http get delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            var artista = _context.Artista.Find(id);
            if (artista == null)
            {
                return NotFound();
            }
            return View(artista);
        }

        //http Post Delete( transferencia de información y datos)
        [HttpPost]
        public IActionResult Deleteartista(int? id)
        {
            var artista = _context.Artista.Find(id);
            if (artista == null)
            {
                return NotFound();
            }
            _context.Artista.Remove(artista);
            _context.SaveChanges();
            TempData["mensaje"] = "El usuario se elimino correctamente";
            return RedirectToAction("Index");
        }


        public IActionResult ListArtista()
        {
            IEnumerable<Artista> listArtistas = _context.Artista;
            return View(listArtistas);
        }
        public async Task <IActionResult> ListObra(int id)
        {
            IEnumerable<Artista> listArtistas = _context.Artista;
            return View("ListObra", await _context.Artista.Where(a => a.Id == id).ToListAsync());
        }

        public async Task <IActionResult> Buscar(string filtroapellido)
        {
            return View("Index",await _context.Artista.Where(a =>a.Apellido.Contains(filtroapellido)).ToListAsync());
            
        }
    }

}
