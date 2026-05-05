public interface IScoutReport
{
    string GetPlayerPerformance();
}

public class LegacyFootballData
{
    public string GetOldMatchStats()
    {
        return "Eski Veri: Koşu Mesafesi: 10km, İsabetli Pas: %80";
    }
}

public class FootballDataAdapter : IScoutReport
{
    private readonly LegacyFootballData _legacyData;

    public FootballDataAdapter(LegacyFootballData legacyData)
    {
        _legacyData = legacyData;
    }

    public string GetPlayerPerformance()
    {
        string oldData = _legacyData.GetOldMatchStats();
        return $"[Adaptör Edildi] {oldData}";
    }
}