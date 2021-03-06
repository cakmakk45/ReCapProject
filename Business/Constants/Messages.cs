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
        public static string Added = "Ekleme işlemi başarılı.";
        public static string Deleted = "Silme işlemi başarılı.";
        public static string Updated = "Güncelleme işlemi başarılı.";
        public static string MaintenanceTime = "Sistem bakım sebebiyle hizmet veremiyor.";
        public static string Error = "Beklenmedik bir hata oluştu";
        public static string IdError = "Girdiğiniz ID numarası veritabanında bulunamadı";
        public static string NotEmpty = "Alanlar boş geçilemez";

        public static string DailyPriceInvalid = "Araç günlük ücreti 0'dan büyük olmalıdır.";
        public static string CarNameInvalid = "Araç ismi en az 2 karakter olmalıdır";
        public static string DescriptionInvalid = "Araç açıklaması en az 2 karakter olmalıdır";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakter olmalıdır.";
        public static string ColorNameInvalid = "Renk ismi en az 2 karakter olmalıdır.";
        public static string CompanyNameInvalid = "şirket ismi en az 2 karakter olmalıdır.";

        public static string CarAdded = "Yeni araç ekleme işlemi başarıyla gerçekleşti.";
        public static string CarDeleted = "Araç bilgileri sistemden silindi.";
        public static string CarUpdated = "Araç bilgisi güncelleme işlemi başarılı.";
        public static string CarListed = "Araç bilgileri listelendi.";
        public static string CarNotFound = "Araç bulunamadı.";

        public static string BrandAdded = "Yeni marka bilgisi ekleme işlemi başarılı.";
        public static string BrandDeleted = "Marka bilgileri sistemden silindi.";
        public static string BrandUpdated = "Marka bilgisi güncelleme işlemi başarılı.";
        public static string BrandListed = "Marka bilgileri listelendi.";

        public static string ColorAdded = "Yeni renk bilgisi ekleme işlemi başarılı.";
        public static string ColorDeleted = "Renk bilgileri sistemden silindi.";
        public static string ColorUpdated = "Renk bilgisi güncelleme işlemi başarılı.";
        public static string ColorListed = "Renk bilgileri listelendi.";

        public static string CustomerAdded = "Müşteri kaydı ekleme işlemi başarılı.";
        public static string CustomerDeleted = "Müşteri kaydı silme işlemi başarılı.";
        public static string CustomerUpdated = "Müşteri kaydı güncelleme işlemi başarılı.";
        public static string CustomerListed = "Müşteri bilgileri listelendi";

        public static string RentalAdded = "Yeni araç kiralama işlemi başarılı.";
        public static string RentalDeleted = "Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Kiralama işlemi güncellemesi başarılı.";
        public static string RentalListed = "Kiralanan araç bilgileri listelendi.";
        public static string RentalFailed = "Bu araç şuan başka müşteri tarafından kiralandığı için kiralanamaz.";
        public static string RentalReturn = "Araç teslim alındı.";
        public static string RentalCarIdError = "Araç id si bulunamadı";

        public static string UserAdded = "Kullanıcı kaydı başarılı.";
        public static string UserDeleted = "Kullanıcı kaydı silindi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi";
        public static string UserListed = "Kullanıcı bilgileri listelendi";

        public static string CarImageAdded = "Araç resmi başarıyla eklendi";
        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi";
        public static string CarImageNotFound = "Araca ait resim bulunamadı";
        public static string NotCarImageDeleted = "Araç silinemedi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string ColorsListed ="Renkler Listelendi";
        internal static string AuthorizationDenied = "Yetkiniz yok";
        internal static string UserRegistered ="Kayıt olundu";
        internal static string UserNotFound ="Kullanıcı bulunamadı";
        internal static string PasswordError ="Parola hatası";
        internal static string SuccessfulLogin ="Başarılı giriş";
        internal static string UserAlreadyExists ="Kullanıcı Mevcut";
        internal static string AccessTokenCreated ="Token Oluşturuldu";
    }
}
