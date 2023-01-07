using KodeksReaderPostgre.Model;

namespace KodeksReaderPostgre.KodeksReader
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
            float moddaCount = 1;
            float bolimCount = 1;
            float bobCount = 1;
            using StreamReader reader = new StreamReader(MainFolder + KodeksName);

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
                        if(moddaCount == 161)
                        {
                            moddaCount = 161.1f;
                        }
                        else
                        {
                            ++moddaCount;
                        }
                        // These moddas are not found in real kodeks
                        moddaCount = moddaCount == 162.1f ? 162 : moddaCount;
                        moddaCount = moddaCount == 163 ? 164 : moddaCount;
                        moddaCount = moddaCount == 163 ? 164 : moddaCount;
                        moddaCount = moddaCount == 168 ? 169 : moddaCount;
                        moddaCount = moddaCount == 176 ? 194 : moddaCount;
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
                        kodeks.Boblar.Add(newBob);
                        bolim?.Boblar.Add(newBob);
                        bolim.Count++;
                    }
                    else if (text.StartsWith(bolimCount + " BO‘LIM"))
                    {

                        Bolim part = new()
                        {
                            Title = text,
                            Number = bolimCount,
                        };
                        
                        bolimCount++;
                        kodeks.Bolimlar.Add(part);
                        if (bolimCount - 1 == 8)
                        {
                            var bolim = kodeks.Bolimlar.LastOrDefault();
                            Bob newBob = new()
                            {
                                Title = text,
                                Number = bobCount,
                            };
                            bobCount++;
                            kodeks.Boblar.Add(newBob);
                            bolim?.Boblar.Add(newBob);
                        }
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

    }
}
