using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //CarMessages
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silme başarılı";
        public static string CarUpdated = "Araba güncellemesi başarılı";
        public static string MinDailyPriceError = "Günlük fiyat 100den büyük olmalı";
        

        //BrandMessages
        public static string BrandsListed = "Markalar Listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silme başarılı";
        public static string BrandUpdated = "Marka güncellemesi başarılı";
        public static string BrandRetrieved="Brand Id'si";

        //ColorMessages
        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silme başarılı";
        public static string ColorUpdated = "Renk güncellemesi başarılı";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ColorRetrieved="Renk Id'si";
        public static string DailyPriceInvalid="Geçersiz fiyat";
        public static string CarImageListed="Araba resim Id'leri listelendi";

        //CarImageMessages
        public static string ImageAdded = "başarılı";
        public static string ImageListed = "listelendi";
        public static string ImageCountExceded = "limit aşıldı";
        public static string AuthorizationDenied ="Yetkiniz Yok";
        public static string UserRegistered="Kullanıcı Kaydedildi";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError="Hatalı Şifre";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string UserCreated="Kullanıcı oluşturuldu";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UserUpdated="Kullanıcı Güncellendi";
    }
}
