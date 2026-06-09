using System;
using System.Collections.Generic;

public class FutbolcuOlayi
{
    public string FutbolcuAdi { get; set; }
    public string OlayTipi { get; set; }
    public int Dakika { get; set; }
}

public interface IGozlemci
{
    void Guncelle(FutbolcuOlayi olay);
}

public interface IYayinci
{
    void AboneEkle(IGozlemci gozlemci);
    void AboneCikar(IGozlemci gozlemci);
    void Bildir(FutbolcuOlayi olay);
}

public class OyuncuTakip : IYayinci
{
    private List<IGozlemci> _gozlemciler = new List<IGozlemci>();

    public void AboneEkle(IGozlemci gozlemci)
    {
        _gozlemciler.Add(gozlemci);
    }

    public void AboneCikar(IGozlemci gozlemci)
    {
        _gozlemciler.Remove(gozlemci);
    }

    public void Bildir(FutbolcuOlayi olay)
    {
        Console.WriteLine($"\n[SAHA İÇİ OLAY]: {olay.FutbolcuAdi}, Dk: {olay.Dakika} -> {olay.OlayTipi}!");
        foreach (var gozlemci in _gozlemciler)
        {
            gozlemci.Guncelle(olay);
        }
    }

    public void OlayGerceklesti(string isim, string aksiyon, int dakika)
    {
        var yeniOlay = new FutbolcuOlayi { FutbolcuAdi = isim, OlayTipi = aksiyon, Dakika = dakika };
        Bildir(yeniOlay);
    }
}

public class BasGozlemci : IGozlemci
{
    public void Guncelle(FutbolcuOlayi olay)
    {
        Console.WriteLine("Baş Gözlemci: Oyuncunun yetenek raporu olaya göre güncellendi.");
    }
}

public class VeriAnalisti : IGozlemci
{
    public void Guncelle(FutbolcuOlayi olay)
    {
        Console.WriteLine("Veri Analisti: Veritabanına işlendi ve metrikler hesaplandı.");
    }
}

public class TeknikDirektor : IGozlemci
{
    public void Guncelle(FutbolcuOlayi olay)
    {
        Console.WriteLine("Teknik Direktör: Oyuncunun transfer önceliği tekrar değerlendiriliyor.");
    }
}

class Program
{
    static void Main()
    {
        OyuncuTakip takipSistemi = new OyuncuTakip();

        IGozlemci basGozlemci = new BasGozlemci();
        IGozlemci veriAnalisti = new VeriAnalisti();
        IGozlemci teknikDirektor = new TeknikDirektor();

        takipSistemi.AboneEkle(basGozlemci);
        takipSistemi.AboneEkle(veriAnalisti);
        takipSistemi.AboneEkle(teknikDirektor);

        takipSistemi.OlayGerceklesti("Arda", "Asist", 24);
        takipSistemi.OlayGerceklesti("Arda", "Kırmızı Kart", 78);
    }
}
