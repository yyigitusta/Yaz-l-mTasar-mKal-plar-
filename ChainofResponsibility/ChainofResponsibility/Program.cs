using System;

public class OyuncuTaramaIstegi
{
    public string OyuncuAdi { get; set; }
    public int Yas { get; set; }
    public double OrtalamaKosuMesafesiKm { get; set; }
    public string OyuncuRolu { get; set; }
    public string TakimTaktikIhtiyaci { get; set; }
}

public abstract class TaramaIsleyicisi
{
    protected TaramaIsleyicisi _sonrakiIsleyici;

    public TaramaIsleyicisi SonrakiniBelirle(TaramaIsleyicisi sonrakiIsleyici)
    {
        _sonrakiIsleyici = sonrakiIsleyici;
        return sonrakiIsleyici;
    }

    public virtual void Isle(OyuncuTaramaIstegi istek)
    {
        if (_sonrakiIsleyici != null)
        {
            _sonrakiIsleyici.Isle(istek);
        }
        else
        {
            Console.WriteLine($"[BAŞARILI] Zincir tamamlandı: {istek.OyuncuAdi} ana transfer listesine eklendi!");
        }
    }
}

public class YasIsleyicisi : TaramaIsleyicisi
{
    public override void Isle(OyuncuTaramaIstegi istek)
    {
        Console.WriteLine("1. Yaş ve Potansiyel Kontrolü yapılıyor...");
        if (istek.Yas > 24)
        {
            Console.WriteLine($"[RED] {istek.OyuncuAdi} 24 yaşından büyük ({istek.Yas}). Kulüp vizyonuna uygun değil. İşlem sonlandırıldı.");
            return;
        }

        Console.WriteLine("   -> Yaş kriteri uygun.");
        base.Isle(istek);
    }
}

public class FizikselMetrikIsleyicisi : TaramaIsleyicisi
{
    public override void Isle(OyuncuTaramaIstegi istek)
    {
        Console.WriteLine("2. Fiziksel Metrik (Dayanıklılık) Kontrolü yapılıyor...");
        double minimumGerekliMesafe = 10.5;

        if (istek.OrtalamaKosuMesafesiKm < minimumGerekliMesafe)
        {
            Console.WriteLine($"[RED] {istek.OyuncuAdi} yetersiz fiziksel veri. Ort. Koşu: {istek.OrtalamaKosuMesafesiKm}km. Beklenen min: {minimumGerekliMesafe}km. İşlem sonlandırıldı.");
            return;
        }

        Console.WriteLine("   -> Fiziksel metrikler uygun.");
        base.Isle(istek);
    }
}

public class TaktikselUyumIsleyicisi : TaramaIsleyicisi
{
    public override void Isle(OyuncuTaramaIstegi istek)
    {
        Console.WriteLine("3. Taktiksel Uyum Kontrolü yapılıyor...");
        if (istek.OyuncuRolu != istek.TakimTaktikIhtiyaci)
        {
            Console.WriteLine($"[RED] {istek.OyuncuAdi} taktiksel sisteme uymuyor. İhtiyaç: {istek.TakimTaktikIhtiyaci}, Oyuncu Rolü: {istek.OyuncuRolu}. İşlem sonlandırıldı.");
            return;
        }

        Console.WriteLine("   -> Taktiksel profile tam uyum sağlandı.");
        base.Isle(istek);
    }
}

public class Program
{
    public static void Main()
    {
        var yasIsleyicisi = new YasIsleyicisi();
        var fizikselIsleyici = new FizikselMetrikIsleyicisi();
        var taktikselIsleyici = new TaktikselUyumIsleyicisi();

        yasIsleyicisi.SonrakiniBelirle(fizikselIsleyici).SonrakiniBelirle(taktikselIsleyici);

        Console.WriteLine("--- OYUNCU 1 DEĞERLENDİRMESİ ---");
        var uygunOyuncu = new OyuncuTaramaIstegi
        {
            OyuncuAdi = "Arda Güler",
            Yas = 19,
            OrtalamaKosuMesafesiKm = 11.2,
            OyuncuRolu = "Oyun Kurucu",
            TakimTaktikIhtiyaci = "Oyun Kurucu"
        };
        yasIsleyicisi.Isle(uygunOyuncu);

        Console.WriteLine("\n--- OYUNCU 2 DEĞERLENDİRMESİ ---");
        var statikOyuncu = new OyuncuTaramaIstegi
        {
            OyuncuAdi = "Juan Riquelme",
            Yas = 22,
            OrtalamaKosuMesafesiKm = 9.1,
            OyuncuRolu = "Klasik 10 Numara",
            TakimTaktikIhtiyaci = "Klasik 10 Numara"
        };
        yasIsleyicisi.Isle(statikOyuncu);
    }
}