using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Kategori için belirlenen ürün sayısını aştınız";
        public static string ProductNameAlreadyExists = "Bu isimde ürün zaten var.";
        internal static string CategoryLimitExceded = "Kategori Limiti Aşıldı";
    }
}
