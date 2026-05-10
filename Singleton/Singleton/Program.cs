public class VeritabanıBaglantisi
{
    private static VeritabanıBaglantisi _ornegi;
    private static readonly object _kilit = new object();

    private VeritabanıBaglantisi() { }

    public static VeritabanıBaglantisi OrnekAl()
    {
        if (_ornegi == null)
        {
            lock (_kilit) 
            {
                if (_ornegi == null)
                {
                    _ornegi = new VeritabanıBaglantisi();
                    Console.WriteLine("Veritabanı bağlantısı ilk kez oluşturuldu.");
                }
            }
        }
        return _ornegi;
    }

    public void SorguCalistir(string sorgu)
    {
        Console.WriteLine($"Sorgu çalıştırılıyor: {sorgu}");
    }
}