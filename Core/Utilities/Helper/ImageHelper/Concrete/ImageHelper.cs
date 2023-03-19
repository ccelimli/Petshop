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
        public IResult Delete(string filePath)
        {
            DeleteOldImageFile(filePath);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            DeleteOldImageFile(filePath);
            return Upload(file, root);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var extension = Path.GetExtension(file.FileName);
            var extensionValid = CheckFileExtensionValid(extension);
            string guid = GuidHelpers.CreateGuid();
            string filePath = guid + extension;

            if (extensionValid.Message != null)
            {
                return new ErrorResult(extensionValid.Message);
            }

            CheckDirectoryExists(root);
            CreateImageFile(root + filePath, file);
            return new SuccessResult(filePath);
        }

        //Control Methods

        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya yok");
        }

        private static IResult CheckFileExtensionValid(string extension)
        {
            if (extension != ".jpeg" && extension != ".png" && extension != ".jpg")
            {
                return new ErrorResult("Hatalı dosya uzantısı");
            }
            return new SuccessResult();
        }

        private static void CheckDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void DeleteOldImageFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
