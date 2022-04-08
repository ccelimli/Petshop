using Core.Utilities.Helper.GuidHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Utilities.Helper
{
    public class ImageHelper : IImageHelper
    {
        public void Delete(string imagePath) //imagePath: ProductImageManager'dan gelen dosyanın kaydedildiği adres ve adı;
        {
            if (File.Exists(imagePath)) // Dosyanın varlığı kontrol edildi.
            {
                File.Delete(imagePath);
            }
        }

        public string Update(IFormFile image, string imagePath, string root) //Güncellenecek yeni dosya, Eski dosyanın kayıt dizini ve yeni bir kayıt dizini
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath); // Güncelleme için öncelikle eski dosya silindi.
            }
            return Add(image, root); // Eski dosya silindikten sonra yeni dosya için alttaki Add methodu kullanılarak yeni dosyayı ekledik
        }

        public string Add(IFormFile image, string root)
        {
            if (image.Length>0) // image.leght dosya uzunluğunu  bayt olarak alır. Dosyayı test eder.
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(image.FileName);
                string guid = GuidHelpers.CreateGuid();
                string imagePath = guid + extension;

                using(FileStream imageStream = File.Create(root + imagePath))
                {
                    image.CopyTo(imageStream);
                    imageStream.Flush();
                    return imagePath;
                }
            }
            return null;
        }
    }
}
