using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PlaceToPeeRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToiletsBerlinData _locationData;

        public IndexModel(ILogger<IndexModel> logger, IToiletsBerlinData locationData)
        {
            _logger = logger;
            _locationData = locationData; ;
        }
     
        public List<DataLibrary.Models.ToiletsBerlinModel> LocationsBerlin { get; set; }

        public async Task OnGet()
        {
            LocationsBerlin = await _locationData.GetAllToiletsBerlin();
        }
    }
}
