using System;
using System.Collections.Generic;
using System.Text;
using TRIALTEST.Attributes;

namespace TRIALTEST.Models
{
    class Product
    {
        [DisplayName("Megnevezés")]
        public string Name { get; set; }
        [DisplayName("Mennyiség")]
        public int Amount { get; set; }
    }
}
