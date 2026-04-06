using System;
using System.Collections.Generic;

public interface IFutbolcuRapor
{
    void RaporuGoruntule();
}
public class FizikselRapor : IFutbolcuRapor
{
    public void RaporuGoruntule()
    {
        Console.WriteLine("Fiziksel Analiz: Hız: 92/100," +
            " Dayanıklılık: Yüksek. Türkiye Süper Lig'e uygun.");
    }
}
public class TeknikRapor : IFutbolcuRapor
{
    public void RaporuGoruntule()
    {
        Console.WriteLine("Teknik Analiz: Pas isabeti: 88%" +
            ", Dribling: 90%. Türkiye Süper Lig'e uygun.");
    }
}
public abstract class ScoutDepartmani
{
    public abstract IFutbolcuRapor RaporOlustur();

    public void FutbolcuAnalizi()
    {
        var report= RaporOlustur();
        Console.WriteLine("Futbolcu Analizi Raporu:");
        report.RaporuGoruntule();
    }
}
public class FizikselScout : ScoutDepartmani
{
    public override IFutbolcuRapor RaporOlustur()
    {
        return new FizikselRapor();
    }
}
public class TeknikScout : ScoutDepartmani
{
    public override IFutbolcuRapor RaporOlustur()
    {
        return new TeknikRapor();
    }
}
class Program
{
    static void Main(string[] args)
    {
        ScoutDepartmani departman;
        departman = new FizikselScout();
        departman.FutbolcuAnalizi();

        departman = new TeknikScout();
        departman.FutbolcuAnalizi();
    }
}