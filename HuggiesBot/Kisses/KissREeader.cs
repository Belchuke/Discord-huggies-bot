using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuggiesBot.Kisses
{
    internal class KissREeader
    {
        public async Task<string> GetKissGif()
        {
            KissJSON obj;

            Random rnd = new Random();

            using (StreamReader sr = new StreamReader("Kisses/kiss.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync(); //Reading whole file
                obj = JsonConvert.DeserializeObject<KissJSON>(json); //Deserialising file into the ConfigJSON structure
            }

            int lenght = obj.kiss.Count;

            int index = rnd.Next(0, lenght - 1);

            return obj.kiss[index];
        }

        public async Task AddKissGif(string url)
        {
            KissJSON obj;

            // Read existing JSON file
            using (StreamReader sr = new StreamReader("Kisses/kiss.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync();
                obj = JsonConvert.DeserializeObject<KissJSON>(json); // Deserialize
            }

            // Add new URL to the list
            obj.kiss.Add(url);

            // Serialize the object back to a JSON string
            string updatedJson = JsonConvert.SerializeObject(obj, Formatting.Indented);

            // Write the updated JSON back to the file
            using (StreamWriter sw = new StreamWriter("Kisses/kiss.json", false, new UTF8Encoding(false)))
            {
                await sw.WriteAsync(updatedJson);
            }
        }

        public async Task<int> KissCount()
        {
            KissJSON obj;

            Random rnd = new Random();

            using (StreamReader sr = new StreamReader("Kisses/kiss.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync(); //Reading whole file
                obj = JsonConvert.DeserializeObject<KissJSON>(json); //Deserialising file into the ConfigJSON structure
            }

            return obj.kiss.Count;
        }
    }

    public sealed class  KissJSON
    {
        public List<string> kiss { get; set; }
    }
}
