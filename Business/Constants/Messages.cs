using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductNameAlreadyExists;
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt Olundu";
        public static string UserNotFound = "Kayıt Bulunamadı";
        public static string PasswordError="Sifre Yanliş";
        public static string SuccessfulLogin = "Giriş Yapıldı";
        public static string AccessTokenCreated = "Giriş ";
        public static string UserAlreadyExists = "Kullanıcı Bulunuyor";
        public static string CategoryLimitExcededs = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";

    }
}
