using KodeksReaderPostgre.KodeksReader;
using KodeksReaderPostgre.Model;
using KodeksReaderPostgre.Repository;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var kodeks = JinoyatKodeksReader.Get();

        /*var repo = new BaseRepositoryAsync<Kodeks>();
        await repo.InsertAsync(kodeks);*/
     }
}