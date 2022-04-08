using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.GuidHelper
{
    public class GuidHelpers
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString(); // Guid.NewGuid() ile eşsiz bir değer oluşturduk.
        }
    }
}
/*
 *  Yüklediğimiz dosya içerisinde eşsiz bir isim olurduk. Yani dosya eklerken dosyanın adı kendi olmasın. Biz ona bir isim oluşturalım ki aynı isimde başka bir dosya çakışmasınlar
 */
