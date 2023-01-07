using KodeksReader.Model;
using MongoDB.Driver;
using MongoDB.Bson;
namespace KodeksReader.KodeksReader
{
    public class OilaKodeksReader
    {
        private static object key = new object();
        private const string KODEKS_NAME = "O‘ZBEKISTON RESPUBLIKASINING OILA KODEKSI";
        private const string LINK = "https://lex.uz/acts/-104720";
        public static Kodeks Get()
        {
            Kodeks kodeks = new()
            {
                Name = KODEKS_NAME,
                Link = LINK
            };
            string MainFolder = @"C:\Users\Nodirkhan\Desktop\";
            string KodeksName = "Kodeks1.txt";
            int moddaCount = 1;
            int bolimCount = 1;
            int bobCount = 1;
            using StreamReader reader = new StreamReader(MainFolder + KodeksName);

            while (!reader.EndOfStream)
            {
                lock (key)
                {
                    string text = reader.ReadLine();
                    if (text.StartsWith(moddaCount + "-modda"))
                    {
                        string moddaId = ObjectId.GenerateNewId().ToString();
                        Modda newModda = new()
                        {
                            Id = moddaId,
                            Title = text,
                            Number = moddaCount,
                        };
                        ++moddaCount;
                        // These moddas are not found in real kodeks
                        moddaCount = moddaCount == 163 ? 164 : moddaCount;
                        moddaCount = moddaCount == 168 ? 169 : moddaCount;
                        moddaCount = moddaCount == 176 ? 194 : moddaCount;
                        kodeks.Moddalar.Add(newModda);
                        if (moddaCount == 235)
                        {
                            kodeks.Boblar.Add(new()
                            {
                                Id = ObjectId.GenerateNewId().ToString(),
                                Title = "",
                            });
                        }
                        var bob = kodeks.Boblar.LastOrDefault();
                        bob.Count++;
                        bob.Moddalar.Add(moddaId, newModda.Title);
                    }
                    else if (text.StartsWith(bobCount + "-bob"))
                    {
                        string Id = ObjectId.GenerateNewId().ToString();
                        Bob newBob = new()
                        {
                            Id = Id,
                            Title = text,
                            Number = bobCount,
                        };
                        bobCount++;
                        kodeks.Boblar.Add(newBob);
                        var bolim = kodeks.Bolimlar.LastOrDefault();
                        bolim?.Boblar.Add(Id, newBob.Title);
                        bolim.Count++;
                    }
                    else if (text.StartsWith(bolimCount + " BO‘LIM"))
                    {
                        string Id = ObjectId.GenerateNewId().ToString();

                        Bolim part = new()
                        {
                            Id = Id,
                            Title = text,
                            Number = bolimCount
                        };
                        bolimCount++;
                        kodeks.Bolimlar.Add(part);
                    }
                    else if (text.StartsWith("Qarang:") || text.StartsWith("1.04.00.00.00"))
                    {
                        continue;
                    }
                    else if (text.StartsWith("(") || text.StartsWith("["))
                    {
                        continue;
                    }
                    else if (!string.IsNullOrEmpty(text.Trim()))
                    {
                        kodeks.Moddalar.LastOrDefault().Content += "\n\n" + text;
                    }

                }
            }
            return kodeks;

        }

        /* public static Kodeks GetOilaKodeks()
         {
             string MainFolder = @"C:\Users\Nodirkhan\Desktop\";
             string KodeksName = "Kodeks1.txt";
             int moddaCount = 1;
             int bolimCount = 1;
             int bobCount = 1;
             using StreamReader reader = new StreamReader(MainFolder + KodeksName);
             List<Bolim> Parts = new();

             while (!reader.EndOfStream)
             {
                 lock (key)
                 {
                     string text = reader.ReadLine();
                     if (text.StartsWith(moddaCount + "-modda"))
                     {
                         Modda newModda = new()
                         {
                             Title = text,
                             Number = moddaCount,
                         };
                         ++moddaCount;
                         // These moddas are not found in real kodeks
                         moddaCount = moddaCount == 163 ? 164 : moddaCount;
                         moddaCount = moddaCount == 168 ? 169 : moddaCount;
                         moddaCount = moddaCount == 176 ? 194 : moddaCount;
                         var bolim = Parts?.LastOrDefault();
                         var bob = bolim?.Boblar?.LastOrDefault();

                         if (moddaCount == 235)
                         {
                             //in this case, end of bo'lim has not bob
                             bolim.Boblar.Add(new Bob());
                             bob = bolim?.Boblar?.LastOrDefault();

                         }
                         bob.Moddalar.Add(newModda);
                         bob.Count++;
                     }
                     else if (text.StartsWith(bobCount + "-bob"))
                     {
                         Bob newBob = new()
                         {
                             Title = text,
                             Number = bobCount,
                         };
                         var bolim = Parts?.LastOrDefault();
                         bobCount++;
                         bolim.Boblar.Add(newBob);
                         bolim.Count++;
                     }
                     else if (text.StartsWith(bolimCount + " BO‘LIM"))
                     {
                         Bolim part = new()
                         {
                             Title = text,
                             Number = bolimCount
                         };
                         bolimCount++;
                         Parts.Add(part);
                     }
                     else if (text.StartsWith("Qarang:") || text.StartsWith("1.04.00.00.00"))
                     {
                         continue;
                     }
                     else if (text.StartsWith("(") || text.StartsWith("["))
                     {
                         continue;
                     }
                     else if (!string.IsNullOrEmpty(text.Trim()))
                     {
                         var bolim = Parts?.LastOrDefault();
                         var bob = bolim?.Boblar?.LastOrDefault();
                         var modda = bob?.Moddalar?.LastOrDefault();
                         modda.Content += "\n\n" + text;
                     }

                 }
             }

             Kodeks kodeks = new()
             {
                 Name = KODEKS_NAME,
                 Bolimlar = Parts,
                 Link = LINK
             };

             return kodeks;
         }*/
    }
}
