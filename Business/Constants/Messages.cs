using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        //Product Messages
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ProductUpdated = "Ürün Güncellendi.";
        public static string ProductListed = "Ürün Listelendi.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductNameInvalid = "Ürün ismi 2 karakterden daha az olamaz!";
        public static string ProductPriceInvalid = "Ürün Fiyatı 0(sıfır)'dan fazla olmalıdır.";

        //Brand Messages
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka İsmi Güncellendi.";
        public static string BrandListed = "Marka Listelendi.";
        public static string BrandsListed = "Markalar Listelendi.";
        public static string BrandNameInvalid = "Marka ismi 2 karakterden daha az olamaz!";

        //Category Messages
        public static string CategoryAdded = "Kategori Eklendi.";
        public static string CategoryDeleted = "Kategori Silindi.";
        public static string CategoryUpdated = "Kategori ismi güncellendi.";
        public static string CategoryListed = "Kategori Listelendi.";
        public static string CategoriesListed = "Kategoriler Listelendi.";
        public static string CategoryNameInvalid = "Kategori ismi 2 karakterden daha az olamaz!";

        //Animal Messages
        public static string AnimalAdded = "Pet Eklendi.";
        public static string AnimalDeleted = "Pet Silindi.";
        public static string AnimalUpdated = "Pet İsmi Güncellendi.";
        public static string AnimalListed = "Pet Listelendi.";
        public static string AnimalsListed = "Petler Listelendi.";
        public static string AnimalNameInvalid = "Pet ismi 2 karakterden daha az olamaz!";

        //Order Messages
        public static string OrderAdded = "Sipariş Eklendi.";
        public static string OrderDeleted = "Sipariş Silindi.";
        public static string OrderUpdated = "Sipariş Güncellendi.";
        public static string OrderListed = "Sipariş Listelendi.";
        public static string OrdersListed = "Siparişler Listelendi.";
        public static string OrdersCanceled = "Sipariş İptal Edildi.";

        //Customer Messages
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Bilgileri Güncellendi.";
        public static string CustomerListed = "Müşteri Listelendi.";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string CustomerMissingInfo = "Müşteri bilgileri eksiksiz doldurulmalıdır! ";
        public static string CustomerRegistered = "Kayıtlı Kullanıcı!";
        public static string CustomerPasswordInvalid = "Parola 6 karakterden az veya 20 karakterden fazla olamaz!";
        public static string CustomerNotFound = "Müşteri Bulunamadı!";

        //User Messages
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Bilgileri Güncellendi.";
        public static string UserListed = "Kullanıcı Listelendi.";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserMissingInfo = "Kullanıcı bilgileri eksiksiz doldurulmalıdır! ";
        public static string UserRegistered = "Kayıtlı Kullanıcı!";
        public static string UserPasswordInvalid = "Parola 6 karakterden az veya 20 karakterden fazla olamaz!";
        public static string UserNotFound = "Kullanıcı Bulunamadı!";

        //Image Messages
        public static string ImageAdded = "Fotoğraf Eklendi";
        public static string ImageDeleted = "Fotoğraf Silindi";
        public static string ImageUpdated = "Fotoğraf Güncellendi";
        public static string ImageListed = "Fotoğraf Listelendi";
        public static string ImagesListed = "Fotoğraflar Listelendi";
        public static string ImagesLimitExceeded = "Bir Ürün En Fazla 5 Fotoğrafa Sahip Olabilir!";
        public static string ImageNotFound = "Fotoğraf bulunamadı!";
        public static string ImageNotUpdated = "Güncellenme esnasında bir hata oluştu!";
    }
}
