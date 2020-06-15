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
    public class DeleteModel : PageModel
    {
        private readonly IToiletsBerlinData _toiletsBerlinData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public ToiletsBerlinModel Toilet { get; set; }

        public DeleteModel(IToiletsBerlinData toiletsBerlinData)
        {
            _toiletsBerlinData = toiletsBerlinData;
        }
        public async Task OnGet()
        {
            Toilet = await _toiletsBerlinData.GetToiletById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _toiletsBerlinData.DeleteToilet(Id);

            return RedirectToPage(".Datatable");
        }
    }
}