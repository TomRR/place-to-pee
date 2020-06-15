using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class ToiletsBerlinModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ISOwnedByWall { get; set; }
        public string IsHandycappedAccessible { get; set; }
        public string Price { get; set; }
        public string CanBePayedWithCoins { get; set; }
        public string CanBePayedWthApp { get; set; }
        public string CanBePayedWithNFC { get; set; }
        public string HasChangingTable { get; set; }
        public string LabelId { get; set; }

    }
}
