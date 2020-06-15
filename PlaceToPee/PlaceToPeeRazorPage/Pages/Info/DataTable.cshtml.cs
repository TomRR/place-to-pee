using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlaceToPeeRazorPage.Pages.Info
{
    public class DataTableModel : PageModel
    {
        private readonly IToiletsBerlinData _locationData;
        public List<DataLibrary.Models.ToiletsBerlinModel> LocationsBerlin { get; set; }

        public DataTableModel(IToiletsBerlinData locationData)
        {
            _locationData = locationData;
        }
        public async Task OnGet()
        {
            LocationsBerlin = await _locationData.GetAllToiletsBerlin();
        }
    }
}