using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLibrary.Models
{
    public class ToiletsBerlinModel
    {
        public int Id { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Street")]
        public string Street { get; set; }
        [DisplayName("PostalCode")]
        public int PostalCode { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("Longitude")]
        public string Longitude { get; set; }
        [DisplayName("Latitude")]
        public string Latitude { get; set; }
        [DisplayName("Is Owned By Wall")]
        public string ISOwnedByWall { get; set; }
        [DisplayName("Is Handycapped Accessible")]
        public string IsHandycappedAccessible { get; set; }
        [DisplayName("Price")]
        public string Price { get; set; }
        [DisplayName("Can Be Payed With Coint")]
        public string CanBePayedWithCoins { get; set; }
        [DisplayName("Can Be Payed With App")]
        public string CanBePayedWthApp { get; set; }
        [DisplayName("Can Be Payed With NFC")]
        public string CanBePayedWithNFC { get; set; }
        [DisplayName("Has Changing Table")]
        public string HasChangingTable { get; set; }
        [DisplayName("Label")]
        public string LabelId { get; set; }

    }
}
