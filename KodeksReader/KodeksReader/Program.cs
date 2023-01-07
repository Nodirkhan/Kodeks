using KodeksReader.KodeksReader;
using KodeksReader.Model;
using KodeksReader.Repository;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static object key = new();
    private static async Task Main(string[] args)
    {
        var kodeks = OilaKodeksReader.Get();

        var repository = new BaseRepositoryAsync<Kodeks>();
        await repository.InserAsync(kodeks);
    }


}