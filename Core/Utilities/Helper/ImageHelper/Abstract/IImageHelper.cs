using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper
{
    public interface IImageHelper
    {
        string Add(IFormFile image, string root);
        void Delete(string imagePath);
        string Update(IFormFile image, string imagePath, string root);
    }
}
