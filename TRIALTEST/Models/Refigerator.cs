using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TRIALTEST.Attributes;

namespace TRIALTEST.Models
{
    class Refigerator
    {
        [DisplayName("Márka")]
        public string Brand { get; set; }
        [DisplayName("Kapacitás")]
        public int Capacity { get; set; }
        [DisplayName("Termékek")]
        public List<Product> Products { get; set; }

        public static Refigerator CreateFromXML(string xml)
        {
            var doc = XDocument.Load(xml); // load xml to "doc" Object
            var frigo = new Refigerator() { // create new "Refigerator" Object which has default Brand,Capacity, Products see above
                Brand = doc.Root.Attribute("brand").Value, //lehel
                Capacity = int.Parse(doc.Root.Attribute("capacity").Value),//13
                Products = new List<Product>()
            };
            foreach (var product in doc.Descendants("product"))
            {
                frigo.Products.Add(new Product()
                {
                    Name = product.Value,
                    Amount = int.Parse(product.Attribute("amount").Value)
                });
            }
            return frigo;

        }
    }
}
