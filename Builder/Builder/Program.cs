using System;
using System.Collections.Generic;
public class TaktikPlan
{
    public string Dizilis { get; set; }
    public string OfansifDusunce { get; set; }
    public string DefansCizgisi { get; set; }
    public string Kaptan { get; set; }
    public List<string> Talimatlar { get; set; }=new List<string>();
    public void OyunPlani()
    {
        Console.WriteLine($"Dizilis: {Dizilis}");
        Console.WriteLine($"Ofansif Dusunce: {OfansifDusunce}");
        Console.WriteLine($"Defans Cizgisi: {DefansCizgisi}");
        Console.WriteLine($"Kaptan: {Kaptan}");
        Console.WriteLine("Talimatlar:");
        foreach (var talimat in Talimatlar)
        {
            Console.WriteLine($"- {talimat}");
        }
    }
}

public interface ITacticBuilder
{
    void SetDizilis();
    void SetOfansifDusunce();
    void SetDefansCizgisi();
    void SetKaptan(string name);
    void SetTalimatlar(string talimat);
    TaktikPlan GetTaktikPlan();
}

public class OffensiveTacticBuilder : ITacticBuilder
{
    private TaktikPlan plan = new TaktikPlan();
    public void SetDizilis()
    {
        plan.Dizilis = "4-3-3";
    }
    public void SetOfansifDusunce()
    {
        plan.OfansifDusunce = "GegenPres";
    }
    public void SetDefansCizgisi()
    {
        plan.DefansCizgisi = "Önde";
    }
    public void SetKaptan(string name)
    {
        plan.Kaptan = name;
    }
    public void SetTalimatlar(string talimat)
    {
        plan.Talimatlar.Add(talimat);
    }
    public TaktikPlan GetTaktikPlan()
    {
        return plan;
    }
}

public class TeknikDirektor
{
    public void GegenPresTaktik(ITacticBuilder builder,string kaptan, List<string> talimatlar)
    {
        builder.SetDizilis();
        builder.SetOfansifDusunce();
        builder.SetDefansCizgisi();
        builder.SetKaptan(kaptan);
        foreach (var talimat in talimatlar)
        {
            builder.SetTalimatlar(talimat);
        }
    }
}
class Program
{
    static void Main()
    {
        ITacticBuilder builder = new OffensiveTacticBuilder();
        TeknikDirektor direktor = new TeknikDirektor();
        List<string> talimatlar = new List<string>
        {
            "Hızlı hücum",
            "Yüksek pres",
            "Kanat oyuncularını aktif kullan"
        };
        direktor.GegenPresTaktik(builder,"Asensio", talimatlar);
        TaktikPlan plan = builder.GetTaktikPlan();
        plan.OyunPlani();
    }
}
