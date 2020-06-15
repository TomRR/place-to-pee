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
    public class CreateModel : PageModel
    {
        private readonly IToiletsBerlinData _toiletsBerlinData;

        [BindProperty]
        public ToiletsBerlinModel Toilet { get; set; }


        public CreateModel(IToiletsBerlinData toiletsBerlinData)
        {
            _toiletsBerlinData = toiletsBerlinData;
        }

        public async Task OnGet()
        {
            var toilet = await _toiletsBerlinData.GetAllToiletsBerlin();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            int id = await _toiletsBerlinData.CreateToilet(Toilet);

            return RedirectToPage("./DetailsById", new { Id = id });

        }
    }
}