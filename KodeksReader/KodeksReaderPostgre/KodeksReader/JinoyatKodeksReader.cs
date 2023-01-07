using KodeksReaderPostgre.Model;
using System.Linq;

namespace KodeksReaderPostgre.KodeksReader
{
    internal class JinoyatKodeksReader
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
            string KodeksName = "JioyatKodeks.txt";
            float moddaCount = 1;
            float moddaRemainderCount = moddaCount + 0.1f;
            float bolimCount = 1;
            float bobCount = 1;
            float bobRemainderCount = 1 + 0.1f;
            using StreamReader reader = new StreamReader(MainFolder + KodeksName);
            string header = "UMUMIY QISM. ";

            while (!reader.EndOfStream)
            {
                lock (key)
                {
                    string text = reader.ReadLine();
                    if (text.StartsWith(moddaCount + "-modda"))
                    {
                        var bob = kodeks.Boblar.LastOrDefault();
                        Modda newModda = new()
                        {
                            Title = text,
                            Number = moddaCount,
                        };
                        ++moddaCount;
                        moddaRemainderCount = moddaCount -1 + 0.1f;
                        kodeks.Moddalar.Add(newModda);
                        bob.Count++;
                        bob.Moddalar.Add(newModda);
                    }
                    else if(text.StartsWith(moddaRemainderCount + "-modda"))
                    { 

                         var bob = kodeks.Boblar.LastOrDefault();
                        Modda newModda = new()
                        {
                            Title = text,
                            Number = moddaRemainderCount,
                        };
                        moddaRemainderCount += 0.1f;
                        kodeks.Moddalar.Add(newModda);
                        bob.Count++;
                        bob.Moddalar.Add(newModda);
                    }
                    else if (text.StartsWith(bobCount + "-bob"))
                    {
                        var bolim = kodeks.Bolimlar.LastOrDefault();
                        Bob newBob = new()
                        {
                            Title = text,
                            Number = bobCount,
                        };
                        bobCount++;
                        bobRemainderCount = bobCount -1 + 0.1f;
                        kodeks.Boblar.Add(newBob);
                        bolim?.Boblar.Add(newBob);
                        bolim.Count++;
                    }
                    else if(text.StartsWith(bobRemainderCount + "-bob"))
                    {
                        var bolim = kodeks.Bolimlar.LastOrDefault();
                        Bob newBob = new()
                        {
                            Title = text,
                            Number = bobRemainderCount,
                        };
                        bobRemainderCount += 0.1f;
                        kodeks.Boblar.Add(newBob);
                        bolim?.Boblar.Add(newBob);
                        bolim.Count++;
                    }
                    else if (text.StartsWith(bolimCount + "-BO‘LIM"))
                    {

                        Bolim part = new()
                        {
                            Title = header + text,
                            Number = bolimCount,
                        };
                        bolimCount++;
                        kodeks.Bolimlar.Add(part);
                    }
                    else if (text.StartsWith("Qarang:") || text.Contains("00.00.00"))
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
                    else if(text.StartsWith("MAXSUS QISM"))
                    {
                        header = "MAXSUS QISM. ";
                    }

                }
            }
            return kodeks;
        }
    }
}
