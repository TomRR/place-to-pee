using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlaceToPeeRazorPage.Pages.Map
{
    public class WithHandicappedAccessibleModel : PageModel
    {
        private readonly IToiletsBerlinData _locationData;
        public List<DataLibrary.Models.ToiletsBerlinModel> LocationsBerlin { get; set; }

        public WithHandicappedAccessibleModel(IToiletsBerlinData locationData)
        {
            _locationData = locationData;
        }
        public async Task OnGet()
        {
            LocationsBerlin = await _locationData.GetToiletsHandicappedAccessible();
        }
    }
}