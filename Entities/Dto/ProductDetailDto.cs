using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Entites.Dto
{
    public class ProductDetailDto : IEntity
    {
        public string  CategoryName { get; set; }
        public string AnimalName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
