using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlaceToPeeRazorPage.Pages.Map
{
    public class StandorteModel : PageModel
    {
        private readonly IStandorteData _standorteData;

        public List<DataLibrary.Models.StandorteModel> Standorte { get; set; }

        public StandorteModel(IStandorteData standorteData)
        {
            _standorteData = standorteData;
        }
        public async Task OnGet()
        {
            Standorte = await _standorteData.GetStandorte();
        }
    }
}