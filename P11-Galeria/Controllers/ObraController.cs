using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P11_Galeria.Data;
using System.Threading.Tasks;
using System.Linq;
using System;
using P11_Galeria.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace P11_Galeria.Controllers
{
    public class ObraController : Controller
    {
        //Variables de solo lectura para control de flujo de datos y tipo de 
        //archivo especial.
        private readonly ObraContext _context;
        private readonly IWebHostEnvironment _environment;
        //Constructor para la generalizacion del uso de variables de control
        public ObraController(ObraContext context,IWebHostEnvironment enviroment)
        {
            _context= context;
            _environment= enviroment;
        }

        //Motores de búsqueda y ordenadores alfabeticos de la informacion mostrada
        public async Task<IActionResult> Index(string oName, string oArtist, string sName,string sArt, string sType)
        {
            //recuperer toda la información de la base de datos a una variable generica
            var gallery = from art in _context.ObraColl
                       select art;

            //Recuperar todas las obras por artista
            IQueryable<string> artistq=from art in _context.ObraColl
                                       orderby art.Artist
                                       select art.Artist;

            //Recuperar todos los tipos de obra
            IQueryable<string> typeq = from art in _context.ObraColl
                                         orderby art.ArtType
                                         select art.ArtType;

            //recuperar el metodo de ordenamiento de tipo nombre
            ViewData["name"] = String.IsNullOrEmpty(oName) ||
                oName == "des" ? "as" : "des";
            //recuperar el metodo de ordenamiento de tipo nombre
            ViewData["artist"] = String.IsNullOrEmpty(oArtist) ||
                oArtist == "des" ? "as" : "des";
            //Validacion de los metodos de ordenamiento
            switch (oName)
            {
                case "des":
                    gallery=gallery.OrderByDescending(n => n.Name);
                    break;
                case "as":
                    gallery = gallery.OrderBy(n => n.Name);
                    break;
                default:
                    break;
            }
            switch (oArtist)
            {
                case "des":
                    gallery = gallery.OrderByDescending(n => n.Artist);
                    break;
                case "as":
                    gallery = gallery.OrderBy(n => n.Artist);
                    break;
                default:
                    break;
            }
            //Validaciones para las busquedas
            if (!String.IsNullOrEmpty(sName))
            { gallery = gallery.Where(n => n.Name.Contains(sName)); }
            if (!String.IsNullOrEmpty(sArt))
            { gallery = gallery.Where(a => a.Artist == sArt); }
            if (!String.IsNullOrEmpty(sType))
            { gallery = gallery.Where(n => n.ArtType==sType); }

            var searchVM = new SearchVM
            {
                LosArtistas=new SelectList(await artistq.Distinct().ToListAsync()),
                LosTipos=new SelectList(await typeq.Distinct().ToListAsync()),
                LasObras= await gallery.ToListAsync()
            };

            return View(searchVM);
        }


    }
}
