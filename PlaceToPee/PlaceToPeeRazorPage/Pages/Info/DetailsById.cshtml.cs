using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlaceToPeeRazorPage.Pages.Info
{
    public class DetailsByIdModel : PageModel
    {
        private readonly IToiletsBerlinData _toiletsBerlinData;


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }


        public ToiletsBerlinModel ToiletsModel { get; set; }
        public string ToiletName { get; set; }
        public DetailsByIdModel(IToiletsBerlinData toiletsBerlinData)
        {
            _toiletsBerlinData = toiletsBerlinData;
        }
        public async Task<IActionResult> OnGet()
        {
            ToiletsModel = await _toiletsBerlinData.GetToiletById(Id);

            return Page();
        }
    }
}