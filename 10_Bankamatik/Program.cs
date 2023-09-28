using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _10_Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sistemsel
            string kimlikno = "12345678911";
            int kimlikbeklenenhane = 11;
            string dhesapno = "12345678911";
            int hesapnobeklenenhane = 11;

            string dkredikartıno = "012345678912";
            int kkbeklenenhane = 12;

            string kayıtlıtelefon = "5395395353";

            int cepbankhak = 3;

            string iban = "TR1234"; // michael jordan iban

            Random kredikartı = new Random();      // Kredi kartı borç
            int kk = kredikartı.Next(100, 2500);

            Random efatura = new Random();      // Elektrik faturası borç
            int ef = efatura.Next(400, 800);

            Random tfatura = new Random();     // Telefon faturası borç
            int tf = tfatura.Next(220, 550);

            Random ifatura = new Random();    // İnternet faturası borç
            int inf = ifatura.Next(220, 600);

            Random sfatura = new Random();    // Su faturası 
            int sf = sfatura.Next(200, 700);

            Random oodemesi = new Random();    // Ogs ödemeleri
            int of = oodemesi.Next(10, 300);

            #endregion
            decimal bakiye = 2500.00m;
            string dogrusıfre = "ab18"; // Doğru şifre        
            int girishakki = 3;
            int kartsızkalanhak = 3;

        Don:

        BAS:
            Console.WriteLine("1.Kartlı işlemler.");
            Console.WriteLine("2.Kartsız işlemler.");
            Console.WriteLine("3.Çıkış");
            Console.WriteLine("   ");

            Console.Write("İşlem seçiniz: ");
            int secim = Convert.ToInt32(Console.ReadLine());

            #region 1. KARTLI İŞLEM

            if (secim == 1)
            {
                while (girishakki > 0)
                {
                    Console.WriteLine("              ");
                    Console.Write("Lütfen belirlediğiniz şifreyi giriniz: ");
                    string girilensifre = Console.ReadLine();

                    if (girilensifre == dogrusıfre)
                    {
                    anamenu:
                        Console.WriteLine("-----------------");
                        Console.WriteLine("ANA MENÜ");
                        Console.WriteLine("-----------------");
                        Console.WriteLine("1.Para Çekme");
                        Console.WriteLine("2.Para Yatırma");
                        Console.WriteLine("3.Para Transferi");
                        Console.WriteLine("4.Eğitim Ödemeleri");
                        Console.WriteLine("5.Borç Ödemeleri");
                        Console.WriteLine("6.Bilgi güncelleme");
                        Console.WriteLine("7.Kartlı,kartsız işlem menüsü");
                        Console.WriteLine("8.Çıkış");
                        Console.WriteLine("                          ");
                        Console.Write("İşlem seçiniz: ");
                        int anamenusecim = Convert.ToInt32(Console.ReadLine());

                        if (anamenusecim == 1) //PARA ÇEKME
                        {
                        paracekmetry:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine($"BAKİYENİZ: {bakiye} TL");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Ana menüye dönmek için '0' tuşlayınız");
                            Console.Write("Çekmek istediğiniz tutarı giriniz: ");
                            decimal cekilentutar = Convert.ToDecimal(Console.ReadLine());

                            if (cekilentutar <= bakiye && cekilentutar > 0)
                            {
                                bakiye -= cekilentutar;
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine($"GÜNCEL BAKİYENİZ : {bakiye}");
                                Thread.Sleep(1000);
                                goto anamenu;
                            }
                            else if (cekilentutar == 0)
                            {
                                goto anamenu;
                            }
                            else if (cekilentutar < 0)
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız!!!");
                                Thread.Sleep(1000);
                                goto paracekmetry;
                            }
                            else
                            {
                                Console.WriteLine("Yetersiz bakiye!!!");
                                Console.WriteLine("-------------------");
                                Thread.Sleep(1000);
                                goto paracekmetry;
                            }
                        }

                        else if (anamenusecim == 2) //PARA YATIRMA                            
                        {
                        yatırma:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("PARA YATIRMA");
                            Console.WriteLine($"Bakiyeniz: {bakiye} TL");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine($"1.Kredi kartı borcu ödeme: {kk} \n2.Kendi hesabına para yatırma");
                            Console.WriteLine("3.Ana menüye dön");
                            Console.WriteLine("                     ");
                            Console.Write("İşlem seçiniz: ");
                            int transfersecimi = Convert.ToInt32(Console.ReadLine());

                            if (transfersecimi == 1)
                            {
                                if (kk <= bakiye)
                                {
                                    bakiye -= kk;
                                    Console.WriteLine("-------------------------------");
                                    kk = 0;
                                    goto yatırma;
                                }
                                else
                                {
                                    Console.WriteLine("-------------------------------");
                                    Console.WriteLine("Yetersiz bakiye!!!");
                                    Thread.Sleep(1000);
                                    goto yatırma;
                                }

                            }
                            else if (transfersecimi == 2)
                            {
                            parayatirmatry:
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine($"BAKİYENİZ: {bakiye} TL");
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Ana menüye dönmek için '0' tuşlayınız");
                                Console.Write("Yatırmak istediğiniz tutarı giriniz: ");
                                decimal yatırılantutar = Convert.ToDecimal(Console.ReadLine());

                                if (yatırılantutar > 0)
                                {
                                    bakiye += yatırılantutar;
                                    goto yatırma;
                                }
                                else if (yatırılantutar == 0)
                                {
                                    goto anamenu;
                                }
                                else
                                {
                                    Console.WriteLine("                        ");
                                    Console.WriteLine("Hatalı bir işlem yaptınız");
                                    Thread.Sleep(1500);
                                    goto parayatirmatry;
                                }
                            }
                            else if (transfersecimi == 3)
                            {
                                goto anamenu;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız.");
                                Thread.Sleep(1000);
                                goto yatırma;
                            }
                        }

                        else if (anamenusecim == 3) //PARA TRANSFERİ                          
                        {
                        paragonderme:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine($"BAKİYENİZ: {bakiye} TL");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Ana menüye dönmek için '0' tuşlayınız");
                            Console.Write("Göndereceğiniz hesaba ait iban numarasını giriniz(tr ile giriniz): ");
                            string giban = Console.ReadLine().ToUpper();

                            if (giban == iban)
                            {
                            paragondermetry:
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("Alıcı: Michael Jordan");
                                Console.WriteLine("----------------------------------");
                                Console.WriteLine("Ana menüye dönmek için '0' tuşlayınız");
                                Console.Write("Göndereceğiniz Tutar: ");
                                decimal gönderilecektutar = Convert.ToDecimal(Console.ReadLine());

                                if (bakiye >= gönderilecektutar && gönderilecektutar > 0)
                                {
                                    bakiye -= gönderilecektutar;
                                    Console.WriteLine("---------------------------");
                                    Console.WriteLine($"YENİ BAKİYENİZ :{bakiye} TL");
                                    Thread.Sleep(2000);
                                    goto anamenu;
                                }
                                else if (gönderilecektutar == 0)
                                {
                                    goto anamenu;
                                }
                                else if (bakiye < gönderilecektutar)
                                {
                                    Console.WriteLine("---------------------------");
                                    Console.WriteLine("Yetersiz bakiye!!!");
                                    Thread.Sleep(1500);
                                    goto paragondermetry;
                                }
                                else
                                {
                                    Console.WriteLine("---------------------------");
                                    Console.WriteLine("Geçersiz bir işlem yaptınız.");
                                    Thread.Sleep(1500);
                                    goto paragondermetry;
                                }

                            }
                            else if (giban == "0")
                            {
                                goto anamenu;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı iban!!! Lütfen tekrar deneyiniz.");
                                Thread.Sleep(2000);
                                goto paragonderme;
                            }
                        }
                        else if (anamenusecim == 4)
                        {
                            Console.WriteLine("                          ");
                            Console.WriteLine("Bu sayfa henüz kullanıma hazır değil. Sizi ana menüye aktarıyorum. Anlayışınız için teşekkürler. ");
                            Console.WriteLine("                          ");
                            Thread.Sleep(2000);
                            goto anamenu;
                        }
                        else if (anamenusecim == 5) //Borç Ödemeleri
                        {
                        faturaekrani:
                            Console.WriteLine("-----------------");
                            Console.WriteLine("BORÇ ÖDEMELERİ\n");
                            Console.WriteLine($"Bakiyeniz : {bakiye} TL");
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"1.Elektrik faturası: {ef} TL");
                            Console.WriteLine($"2.Telefon faturası: {tf} TL");
                            Console.WriteLine($"3.İnternet faturası: {inf} TL");
                            Console.WriteLine($"4.Su faturası: {sf} TL");
                            Console.WriteLine($"5.Ogs faturası: {of} TL");
                            Console.WriteLine("6.Ana Menüye dön");
                            Console.WriteLine("                          ");
                            Console.Write("Ödemek istediğinizi faturayı seçiniz: ");
                            int odemesecim = Convert.ToInt32(Console.ReadLine());

                            if (odemesecim == 1) // elektrik
                            {
                                if (ef == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto faturaekrani;
                                }
                                else if (ef <= bakiye)
                                {
                                    bakiye -= ef;
                                    ef = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto faturaekrani;
                                }
                                else if (ef > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                            }
                            else if (odemesecim == 2) //Telefon faturası
                            {
                                if (tf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto faturaekrani;
                                }
                                else if (tf <= bakiye)
                                {
                                    bakiye -= tf;
                                    tf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto faturaekrani;
                                }
                                else if (tf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                            }
                            else if (odemesecim == 3) // İnternet faturası (inf)
                            {
                                if (inf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto faturaekrani;
                                }
                                else if (inf <= bakiye)
                                {
                                    bakiye -= inf;
                                    inf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto faturaekrani;
                                }
                                else if (inf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }

                            }
                            else if (odemesecim == 4) // Su faturası
                            {
                                if (sf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto faturaekrani;
                                }
                                else if (sf <= bakiye)
                                {
                                    bakiye -= sf;
                                    sf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto faturaekrani;
                                }
                                else if (sf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }

                            }
                            else if (odemesecim == 5) // Ogs ödemesi (of)
                            {
                                if (of == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto faturaekrani;
                                }
                                else if (of <= bakiye)
                                {
                                    bakiye -= of;
                                    of = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto faturaekrani;
                                }
                                else if (of > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto faturaekrani;
                                }
                            }
                            else if (odemesecim == 6)
                            {
                                goto anamenu;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız");
                                Thread.Sleep(1500);
                                goto faturaekrani;
                            }
                        }
                        else if (anamenusecim == 6) // BİLGİ GÜNCELLEME
                        {
                        bilgiguncel:
                            Console.WriteLine("--------------------\nBİLGİ GÜNCELLEME\n");
                            Console.WriteLine("1.Şifre değiştirme \n2.Ana menüye dön");
                            Console.Write("İşlem seçiniz: ");
                            int bilgiguncelleme = Convert.ToInt32(Console.ReadLine());

                            if (bilgiguncelleme == 1)
                            {
                                Console.WriteLine("İptal edip ana menüye dönmek için şifreyi '-' belirleyiniz!!!");
                                Console.Write("Belirlemek istediğiniz şifreyi giriniz: ");
                                string sifredegistirme = Console.ReadLine();

                                if (sifredegistirme == "-")
                                {
                                    Console.WriteLine("Ana menüye dönülüyor...");
                                    Thread.Sleep(1500);
                                    goto anamenu;
                                }

                                Console.Write("Belirlemek istediğiniz şifreyi tekrar giriniz: ");
                                string tekrarsifre = Console.ReadLine();


                                if (sifredegistirme == tekrarsifre)
                                {
                                    dogrusıfre = tekrarsifre;
                                    Console.WriteLine("Şifre değiştirildi!!! Çıkış yapılıyor.");
                                    Console.WriteLine("---------------------------------------\n");
                                    girishakki = 3;
                                    Thread.Sleep(2000);
                                    goto BAS;
                                }
                                else if (sifredegistirme != tekrarsifre)
                                {
                                    Console.WriteLine("Şifreler uyumlu değil.Lütfen tekrar deneyiniz...");
                                    Thread.Sleep(1500);
                                    goto bilgiguncel;
                                }

                            }
                            else if (bilgiguncelleme == 2)
                            {
                                goto anamenu;
                            }
                            else
                            {
                                Console.WriteLine("\nHatalı bir işlem yaptınız!!!");
                                Thread.Sleep(1000);
                                goto bilgiguncel;
                            }
                        }
                        else if (anamenusecim == 7)
                        {
                            Console.WriteLine("-----------------------");
                            Thread.Sleep(1500);
                            goto BAS;
                        }
                        else if (anamenusecim == 8)
                        {
                            Console.WriteLine("Güvenli çıkış yapılıyor. Lütfen bekleyiniz...");
                            Thread.Sleep(2500);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı bir işlem yaptınız!!!");
                            Thread.Sleep(1000);
                            goto anamenu;
                        }
                        break;
                    }
                    else
                    {
                        girishakki--;
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine($"Hatalı şifre! Kalan giriş hakkınız : {girishakki}");

                        if (girishakki == 0)
                        {
                            Console.WriteLine("3 Kez hatalı giriş yapıldı.Lütfen bankanız ile görüşün 444 44 44");
                            Thread.Sleep(5000);
                            return;
                        }
                    }
                }
            }

            #endregion

            #region 2.KARTSIZ İŞLEMLER
            else if (secim == 2)
            {
            kartsızislemanamenu:
                Console.WriteLine("---------------------\nKARTSIZ İŞLEM MENÜSÜ\n\n1.Cepbank para çekme\n2.Para yatırma\n3.Kredi kartı ödeme\n4.Eğitim ödemeleri\n5.Ödemeler\n6.Kartlı,kartsız işlem menüsü\n7.Çıkış");
                Console.Write("Bir işlem seçiniz: ");
                int kartsızislem = Convert.ToInt32(Console.ReadLine());

                if (kartsızislem == 1) //CEPBANK PARA ÇEKME

                    while (cepbankhak > 0)
                    {
                    cepbanktekrar:
                        Console.WriteLine("\nKartsız işlem menüsüne dönmek için '0' tuşlayınız.");
                        Console.Write("Tc kimlik numaranızı giriniz: TR");
                        string tc = Console.ReadLine();
                        if (tc == "0")
                        {
                            goto kartsızislemanamenu;
                        }
                        Console.Write("Telefon numaranızı giriniz: 0");
                        string telefon = Console.ReadLine();
                        if (telefon == "0")
                        {
                            goto kartsızislemanamenu;
                        }
                        else if (tc == kimlikno && telefon == kayıtlıtelefon)
                        {
                        YHislem:
                            Console.Write("\nKartsız islem menüsüne dönmek için '0' tuşlayınız\nBakiye sorgulamak için '01' tuşlayınız...(2 tl işlem ücreti kesilecektir.)\nÇekmek istediğiniz tutarı giriniz: ");
                            decimal cepbanktutar = Convert.ToDecimal(Console.ReadLine());
                            if (cepbanktutar == 0)
                                goto kartsızislemanamenu;
                            else if (cepbanktutar == 01)
                            {
                                bakiye -= 2;
                                Console.WriteLine($"\nBakiyeniz: {bakiye}");
                                goto YHislem;
                            }
                            else if (cepbanktutar <= bakiye && cepbanktutar > 0)
                            {
                                bakiye -= cepbanktutar;
                                Console.WriteLine($"İşleminiz gerçekleşti.Güncel bakiyeniz: {bakiye}");
                                Thread.Sleep(1500);
                                goto kartsızislemanamenu;
                            }
                            else if (cepbanktutar > bakiye)
                            {
                                Console.WriteLine("----------------\nYetersiz bakiye\n----------------");
                                Thread.Sleep(1000);
                                goto YHislem;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız");
                                Console.WriteLine();
                                goto YHislem;
                            }

                            break;
                        }

                        else if (tc != kimlikno || telefon != kayıtlıtelefon && cepbankhak != 1) // SORULACAK YER!!! hatalı giriş
                        {
                            --cepbankhak;
                            Console.WriteLine($"Tc kimlik numaranız veya telefon numaranız eşleşmedi. Kalan hakkınız : {cepbankhak}");
                            Thread.Sleep(1500);

                            if (cepbankhak == 0)
                            {
                                Console.WriteLine("3 kez hatalı giriş yaptınız. Lütfen bankanız ile görüşün 444 44 44");
                                Thread.Sleep(1500);
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("3 kez hatalı giriş yaptınız. Lütfen bankanız ile görüşün 444 44 44"); // 3 kere hatalı giriş
                            Thread.Sleep(2000);
                            return;
                        }

                    }
                else if (kartsızislem == 2)
                {
                    Console.WriteLine("Ana menüye dönmek için '0' tuşlayınız.");
                    Console.Write("Hesap numaranızı giriniz: ");
                    string hesapno = Console.ReadLine();
                    if (hesapno == "0")
                    {
                        goto kartsızislemanamenu;
                    }
                    else if (hesapno == dhesapno && hesapno.Length == hesapnobeklenenhane)
                    {
                        Console.Write("Lütfen tc kimlik numaranızı giriniz:");
                        string Tc = Console.ReadLine();
                        if (Tc == "0")
                        {
                            goto kartsızislemanamenu;
                        }
                        else if (Tc == kimlikno && Tc.Length == kimlikbeklenenhane)
                        {
                            Console.Write("\nÇıkış yapmak için '0' tuşlayınız.\nYatırmak istediğiniz tutarı giriniz: ");
                            int kartsizislemtutar = Convert.ToInt32(Console.ReadLine());
                            if (kartsizislemtutar == 0)
                            {
                                goto kartsızislemanamenu;
                            }
                            else if (kartsizislemtutar > 0)
                            {
                                bakiye += kartsizislemtutar;
                                Console.WriteLine("İşleminiz tamamlandı...");
                                Thread.Sleep(1000);
                                goto kartsızislemanamenu;
                            }
                            else
                            {
                                Console.WriteLine("Yanlış bir işlem yaptınız.");
                                Thread.Sleep(1000);
                                goto kartsızislemanamenu;
                            }


                        }
                        else if (Tc.Length != kimlikbeklenenhane)
                        {
                            Console.WriteLine("Kimlik numarası 11 haneli olmalıdır!!!");
                            Thread.Sleep(1500);
                            goto kartsızislemanamenu;
                        }
                        else if (Tc != kimlikno)
                        {
                            Console.WriteLine("Sistemde eşleşen bir kimlik numarası yok.");
                            Thread.Sleep(1500);
                            goto kartsızislemanamenu;
                        }




                    }
                    else if (hesapno.Length != hesapnobeklenenhane)
                    {
                        Console.WriteLine("Hesap numarası 11 haneli olmalıdır!!!");
                        Thread.Sleep(1500);
                        goto kartsızislemanamenu;
                    }
                    else if (hesapno != dhesapno)
                    {
                        Console.WriteLine("Sistemde eşleşen bir hesap numarası bulamadık!!!");
                        Thread.Sleep(1500);
                        goto kartsızislemanamenu;
                    }
                }
                else if (kartsızislem == 3) // KREDİ KARTI ÖDEME
                {
                kartsızkredikartı:
                    int beklenenhanesayısı = 12;
                    Console.WriteLine("---------------\n1.Nakit ödeme\n2.Hesaptan ödeme\n0.Kartsız işlemler menüsü dön");
                    Console.Write("\nİşlem seçiniz: ");
                    int kartsızislempy = Convert.ToInt32(Console.ReadLine());

                    if (kartsızislempy == 0)
                    {
                        goto kartsızislemanamenu;
                    }
                    else if (kartsızislempy == 1)
                    {
                        while (kartsızkalanhak > 0)
                        {
                            if (kartsızkalanhak > 0)
                            {
                            hata:
                                Console.Write("\nÇıkmak için '0' giriniz.\nTc kimlik numaranızı giriniz: TR");
                                string kredinakitodemetc = Console.ReadLine();
                                if (kredinakitodemetc == "0")
                                {
                                    goto kartsızkredikartı;
                                }
                                else if (kredinakitodemetc == kimlikno)
                                {
                                    Console.Write("\nKredi kartı numaranızı giriniz: ");
                                    string nkodemekredi = Console.ReadLine();
                                    if (nkodemekredi == "0")
                                    {
                                        goto kartsızkredikartı;
                                    }
                                    else if (dkredikartıno == nkodemekredi)
                                    {
                                    kartsıznakitodeme:
                                        Console.WriteLine($"\nKredi kartı borcunuz: {kk} TL\n");
                                        Console.WriteLine("0.Geri dönmek için.\n1.ödeme");
                                        Console.Write("İşlem seçiniz: ");
                                        string nakitkredikartiodeme = Console.ReadLine();

                                        if (nakitkredikartiodeme == "0")
                                        {
                                            goto kartsızkredikartı;
                                        }
                                        else if (kk == 0)
                                        {
                                            Console.WriteLine("Kredi kartı borcunuz yok.");
                                            Thread.Sleep(1000);
                                            goto kartsızislemanamenu;
                                        }
                                        else if (nakitkredikartiodeme == "1")
                                        {
                                            Console.WriteLine("Parayı yerleştiriniz...");
                                            Thread.Sleep(1000);
                                            Console.WriteLine("Teşekkürler...");
                                            Thread.Sleep(1000);
                                            kk = 0;
                                            goto kartsızislemanamenu;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Hatalı bir tuşlama yaptınız.");
                                            goto kartsıznakitodeme;
                                        }
                                        break;
                                    }
                                    else if (nkodemekredi.Length != kkbeklenenhane)
                                    {
                                        --kartsızkalanhak;
                                        Console.WriteLine($"Kredi kartı numarası 12 haneli olmalıdır. Kalan hak: {kartsızkalanhak}");
                                        Thread.Sleep(1500);
                                        if (kartsızkalanhak == 0)
                                        {
                                            Console.WriteLine("3 kere hatalı giriş yaptınız. Lütfen bankanızı ile irtibata geçiniz 444 44 44");
                                            Thread.Sleep(3000);
                                            return;
                                        }
                                        goto hata;
                                    }
                                    else if (nkodemekredi != dkredikartıno)
                                    {
                                        --kartsızkalanhak;
                                        Console.WriteLine($"Sistemde eşleşen bir kredi kartı numarası yok. Kalan hak: {kartsızkalanhak}");
                                        Thread.Sleep(1500);

                                        if (kartsızkalanhak == 0)
                                        {
                                            Console.WriteLine("3 kere hatalı giriş yaptınız. Lütfen bankanızı ile irtibata geçiniz 444 44 44");
                                            Thread.Sleep(3000);
                                            return;
                                        }
                                        goto hata;
                                    }
                                }
                                else if (kredinakitodemetc.Length != kimlikbeklenenhane)
                                {
                                    --kartsızkalanhak;
                                    Console.WriteLine($"Kimlik 11 haneli olmalıdır. Kalan hak: {kartsızkalanhak}");
                                    if (kartsızkalanhak == 0)
                                    {
                                        Console.WriteLine("3 kere hatalı giriş yaptınız. Lütfen bankanızı ile irtibata geçiniz 444 44 44");
                                        Thread.Sleep(3000);
                                        return;
                                    }
                                }
                                else if (kredinakitodemetc != kimlikno)
                                {
                                    --kartsızkalanhak;
                                    Console.WriteLine($"Sistemde eşleşen bir kimlik yok. Kalan hak: {kartsızkalanhak}");
                                    if (kartsızkalanhak == 0)
                                    {
                                        Console.WriteLine("3 kere hatalı giriş yaptınız. Lütfen bankanızı ile irtibata geçiniz 444 44 44");
                                        Thread.Sleep(3000);
                                        return;
                                    }
                                }
                            }


                        }



                    }
                    else if (kartsızislempy == 2) // 2.Hesaptan ödeme
                    {
                    kartsızislempy:
                        Console.WriteLine("Para yatırma ekranına dönmek için '0' giriniz");
                        Console.Write("11 haneli kimlik numaranızı giriniz: TR");
                        string denemekimlik = Console.ReadLine();
                        if (denemekimlik == "0")  // kimlik çıkış
                        {
                            goto kartsızkredikartı;
                        }
                        else if (denemekimlik.Length == kimlikbeklenenhane && denemekimlik == kimlikno) // Hane ve şifrenin doğru olduğu durum
                        {
                            Console.Write("\n12 haneli kredi kartı numaranızı giriniz: ");
                            string kkdeneme = Console.ReadLine();
                            if (kkdeneme == "0") // kredi kartı çıkış
                            {
                                Console.WriteLine("---------------");
                                goto kartsızkredikartı;
                            }
                            else if (kkdeneme.Length == kkbeklenenhane && kkdeneme == dkredikartıno) // Kredi kartının doğru olduğu durum.
                            {
                                Console.WriteLine("-----------------------");
                                Console.WriteLine($"Bakiyeniz : {bakiye}");
                                Console.WriteLine($"Kredi kartı borcunuz : {kk}\n");
                                Console.WriteLine("1.Ödeme\n2.Geri dönmek için");
                            hatalı:
                                Console.Write("İşlem seçiniz: ");
                                int ödeme = Convert.ToInt32(Console.ReadLine());
                                if (ödeme == 1)
                                {
                                    if (kk == 0)
                                    {
                                        Console.WriteLine("Borcunuz yok.");
                                        Thread.Sleep(1500);
                                        goto kartsızislemanamenu;
                                    }
                                    else if (bakiye > kk && bakiye > 0)
                                    {
                                        bakiye -= kk;
                                        Console.WriteLine($"Güncel bakiyeniz: {bakiye}");
                                        Thread.Sleep(1500);
                                        kk = 0;
                                        goto kartsızislemanamenu;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Yetersiz bakiye!!!");
                                        Thread.Sleep(1000);
                                        goto kartsızkredikartı;
                                    }
                                }
                                else if (ödeme == 2)
                                {
                                    Console.WriteLine("-----------------");
                                    goto kartsızkredikartı;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı bir tuşlama yaptınız...");
                                    Thread.Sleep(1500);
                                    goto hatalı;
                                }
                            }
                            else if (kkdeneme.Length != kkbeklenenhane)
                            {
                                Console.WriteLine("Kredi kartı numaranız 12 haneli olmalıdır.");
                                Thread.Sleep(1500);
                                goto kartsızkredikartı;
                            }
                            else if (kkdeneme != dkredikartıno)
                            {
                                Console.WriteLine("Sistemde eşleşen bir kredi kartı bulunamadı");
                                Thread.Sleep(1500);
                                goto kartsızkredikartı;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız");
                                Thread.Sleep(1500);
                                goto kartsızkredikartı;
                            }


                        }
                        else if (denemekimlik.Length != kimlikbeklenenhane)                     // Hane yanlış olduğu durum 
                        {
                            Console.WriteLine("Kimlik numarası 11 haneli olmalıdır.");
                            Thread.Sleep(1500);
                            goto kartsızislempy;
                        }
                        else if (denemekimlik != kimlikno)                         // şifrenin yanlış olduğu durum
                        {
                            Console.WriteLine("Sistemde eşleşen bir tc bulunamadı");
                            Thread.Sleep(1500);
                            goto kartsızkredikartı;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı bir işlem yaptınız.");
                            Thread.Sleep(1500);
                            goto kartsızkredikartı;
                        }


                    }
                    else
                    {
                        Console.WriteLine("Hatalı bir tuşlama yaptınız.");
                        Thread.Sleep(1000);
                        goto kartsızkredikartı;
                    }







                }
                else if (kartsızislem == 4)
                {
                    Console.WriteLine("Bu sayfa henüz kullanıma hazır değil. Sizi ana menüye aktarıyorum. Anlayışınız için teşekkürler. ");
                    Thread.Sleep(1500);
                    goto kartsızislemanamenu;
                }
                else if (kartsızislem == 5)
                {
                    Console.Write("Ana menüye dönmek için '0' tuşlayınız.\nHesap numaranızı giriniz: ");
                    string kartsızislemödemehesap = Console.ReadLine();
                    if (kartsızislemödemehesap == "0")
                    {
                        goto kartsızislemanamenu;
                    }
                    else if (kartsızislemödemehesap == dhesapno && kartsızislemödemehesap == dhesapno)
                    {
                        Console.Write("Lütfen kimlik numaranızı giriniz : TR");
                        string kiodeme = Console.ReadLine();

                        if (kiodeme == "0")
                        {
                            goto kartsızislemanamenu;
                        }
                        else if (kiodeme.Length == kimlikbeklenenhane && kiodeme == kimlikno) // Hesap no ve kimlik doğru 
                        {
                        kartsızislemodememenu:
                            Console.WriteLine("-----------------");
                            Console.WriteLine("BORÇ ÖDEMELERİ\n");
                            Console.WriteLine($"Bakiyeniz : {bakiye} TL");
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"1.Elektrik faturası: {ef} TL");
                            Console.WriteLine($"2.Telefon faturası: {tf} TL");
                            Console.WriteLine($"3.İnternet faturası: {inf} TL");
                            Console.WriteLine($"4.Su faturası: {sf} TL");
                            Console.WriteLine($"5.Ogs faturası: {of} TL");
                            Console.WriteLine("6.Ana Menüye dön");
                            Console.WriteLine("                          ");
                            Console.Write("Ödemek istediğinizi faturayı seçiniz: ");
                            int kartsızodeme = Convert.ToInt32(Console.ReadLine());

                            if (kartsızodeme == 1) // elektrik
                            {
                                if (ef == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto kartsızislemodememenu;
                                }
                                else if (ef <= bakiye)
                                {
                                    bakiye -= ef;
                                    ef = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto kartsızislemodememenu;
                                }
                                else if (ef > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                            }
                            else if (kartsızodeme == 2) //Telefon faturası
                            {
                                if (tf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto kartsızislemodememenu;
                                }
                                else if (tf <= bakiye)
                                {
                                    bakiye -= tf;
                                    tf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto kartsızislemodememenu;
                                }
                                else if (tf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                            }
                            else if (kartsızodeme == 3) // İnternet faturası (inf)
                            {
                                if (inf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto kartsızislemodememenu;
                                }
                                else if (inf <= bakiye)
                                {
                                    bakiye -= inf;
                                    inf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto kartsızislemodememenu;
                                }
                                else if (inf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }

                            }
                            else if (kartsızodeme == 4) // Su faturası
                            {
                                if (sf == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto kartsızislemodememenu;
                                }
                                else if (sf <= bakiye)
                                {
                                    bakiye -= sf;
                                    sf = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto kartsızislemodememenu;
                                }
                                else if (sf > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }

                            }
                            else if (kartsızodeme == 5) // Ogs ödemesi (of)
                            {
                                if (of == 0)
                                {
                                    Console.WriteLine("Borcunuz yok.");
                                    Thread.Sleep(1000);
                                    goto kartsızislemodememenu;
                                }
                                else if (of <= bakiye)
                                {
                                    bakiye -= of;
                                    of = 0;
                                    Console.WriteLine("-----------------");
                                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                                    Thread.Sleep(2000);
                                    goto kartsızislemodememenu;
                                }
                                else if (of > bakiye)
                                {
                                    Console.WriteLine("Yetersiz bakiye");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz bir işlem yaptınız!!!");
                                    Thread.Sleep(1500);
                                    goto kartsızislemodememenu;
                                }
                            }
                            else if (kartsızodeme == 6)
                            {
                                goto kartsızislemanamenu;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı bir işlem yaptınız");
                                Thread.Sleep(1500);
                                goto kartsızislemodememenu;
                            }

                        }
                        else if (kiodeme.Length != kimlikbeklenenhane)
                        {
                            Console.WriteLine("Kimlik numarası 11 haneli olmalıdır.");
                            Thread.Sleep(1000);
                            goto kartsızislemanamenu;
                        }
                        else if (kiodeme != kimlikno)
                        {
                            Console.WriteLine("Sistemde eşleşen bir kimlik bulunamadı.");
                            Thread.Sleep(1000);
                            goto kartsızislemanamenu;
                        }



                    }
                    else if (kartsızislemödemehesap.Length != hesapnobeklenenhane)
                    {
                        Console.WriteLine("Hesap numarası 11 haneli olmalıdır.");
                        Thread.Sleep(1000);
                        goto kartsızislemanamenu;
                    }
                    else if (kartsızislemödemehesap != dhesapno)
                    {
                        Console.WriteLine("Sistemde eşleşen bir hesap numarası bulunamadı.");
                        Thread.Sleep(1000);
                        goto kartsızislemanamenu;
                    }
                }
                else if (kartsızislem == 6)
                {
                    Console.WriteLine("-----------------------");
                    Thread.Sleep(1500);
                    goto BAS;
                }
                else if (kartsızislem == 7)
                {
                    Console.WriteLine("Güvenli çıkış yapılıyor. Lütfen bekleyiniz...");
                    Thread.Sleep(2500);
                    return;
                }
                else
                {
                    Console.WriteLine("Hatalı bir işlem yaptınız!!!");
                    Thread.Sleep(1000);
                    goto kartsızislemanamenu;
                }
            }
            #endregion

            #region 3. ÇIKIŞ

            else if (secim == 3)
            {
                Console.WriteLine("Güvenli çıkış yapılıyor. Lütfen bekleyiniz...");
                Thread.Sleep(2000);
                return;
            }

            #endregion

            #region 4.HATALI İŞLEM
            else
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Hatalı bir işlem yaptınız!!!");
                Console.WriteLine("----------------------------------------");
                goto Don;
            }
            #endregion


            Console.ReadLine();

        }
    }
}
