using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Animal : IEntity
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
    }
}
