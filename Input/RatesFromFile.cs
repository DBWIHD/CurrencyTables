namespace CurrencyTables.Input;

public class RatesFromFile
{
    public string FilePath { get; }
    public RatesFromFile(string path)
    {
        FilePath = path;
    }
    /// <summary>
    /// Takes data from file
    /// </summary>
    /// <returns>The objects list of currency rates</returns>
    public List<CurrencyRate> Rates()
    {
        List<CurrencyRate> rates = new List<CurrencyRate>();

        foreach (string line in File.ReadLines(FilePath))
        {
            string[] parts = line.Split(';');
            rates.Add(new CurrencyRate(parts[0], decimal.Parse(parts[1])));
        }

        return rates;
    }
}
