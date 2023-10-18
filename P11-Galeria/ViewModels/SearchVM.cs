using Microsoft.AspNetCore.Mvc.Rendering;
using P11_Galeria.Models;
using System.Collections.Generic;

namespace P11_Galeria.ViewModels
{
    public class SearchVM
    {
        public List<Obra> LasObras { get; set; }
        public SelectList LosArtistas { get; set; }
        public SelectList LosTipos { get; set; }

        public string SArt { get; set; }
        public string SArtist { get; set; }
        public string SType { get; set; }
    }
}
