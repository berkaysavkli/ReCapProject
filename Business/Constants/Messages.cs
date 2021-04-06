using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarsListed = "Arabalar listelendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed = "Müşteriler listelendi";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalDeleted = "Kiralanan araç bilgileri silindi";
        public static string RentalUpdated = "Kiralanan araç bilgileri güncellendi";
        public static string RentalListed = "Kiralanan araçlar listelendi";
        public static string RentalInvalid = "Araç kiralama başarısız. Kiralanmak istenen araç henüz teslim edilmemiş.";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserListed = "Kullanıcılar listelendi";

        public static string DescriptionInvalid = "Araba ismi en az 2 karakter olmalı. Günlük ücret 0'dan küçük olamaz";
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated="Araba resmi güncellendi";
        public  static string FailedCarImageAdd="En fazla 5 araba resmi eklenebilir";
    }
}
