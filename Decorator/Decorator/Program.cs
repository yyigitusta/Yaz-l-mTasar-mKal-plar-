using System;

public interface IFutbolcu
{
    string BilgiAl();
    int GucHesapla();
}

public class TemelFutbolcu : IFutbolcu
{
    public string BilgiAl() => "Standart Futbolcu";
    public int GucHesapla() => 60;
}

public abstract class FutbolcuDecorator : IFutbolcu
{
    protected IFutbolcu _futbolcu;

    protected FutbolcuDecorator(IFutbolcu futbolcu)
    {
        _futbolcu = futbolcu;
    }

    public virtual string BilgiAl() => _futbolcu.BilgiAl();
    public virtual int GucHesapla() => _futbolcu.GucHesapla();
}

public class KaptanDecorator : FutbolcuDecorator
{
    public KaptanDecorator(IFutbolcu futbolcu) : base(futbolcu) { }

    public override string BilgiAl() => base.BilgiAl() + " + Takım Kaptanı";
    public override int GucHesapla() => base.GucHesapla() + 10; 
}

public class KramponDecorator : FutbolcuDecorator
{
    public KramponDecorator(IFutbolcu futbolcu) : base(futbolcu) { }

    public override string BilgiAl() => base.BilgiAl() + " + Altın Krampon";
    public override int GucHesapla() => base.GucHesapla() + 5;
    }
    class Program
    {
        static void Main()
        {
            IFutbolcu oyuncu = new TemelFutbolcu();

            oyuncu = new KaptanDecorator(oyuncu);

            oyuncu = new KramponDecorator(oyuncu);

            Console.WriteLine($"Oyuncu Tanımı: {oyuncu.BilgiAl()}");
            Console.WriteLine($"Toplam Reyting: {oyuncu.GucHesapla()}");

        }
    }
