using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int  AnimalId { get; set; }
        public int CategoryId{ get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
