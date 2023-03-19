using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comporate :IEntity
    {
        
        [Key]
        public int UserId { get; set; }
        public User User;
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }
}
