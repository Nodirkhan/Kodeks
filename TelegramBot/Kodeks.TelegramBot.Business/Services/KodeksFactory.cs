using Kodeks.TelegramBot.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kodeks.TelegramBot.Business.Services
{
    public class KodeksFactory
    {
        private  static Dictionary<string, string> Kodeks { get; set; }
        public static KodeksFactory Instance 
        {
            get { return Nested.kodeksFactory; }
        }

        private KodeksFactory()
        {
            Kodeks = new Dictionary<string, string>();
            RegisterKodeks();
        }

        public void RegisterKodeks()
        {
            var kodeksRepository = new KodeksRepositoryAsync();
            var codexes = kodeksRepository.GetAllKodeks();
            foreach(var kodeks in codexes )
            {
                Kodeks.Add(kodeks.Id.ToString(), kodeks.Name);
            }
        }
        public Dictionary<string, string> GetKodeks() =>
            Kodeks;
        private class Nested
        {
            static Nested() { }
            internal static readonly KodeksFactory kodeksFactory = new KodeksFactory();
        }

    }
    
}
