using HuggiesBot.Config;
using Newtonsoft.Json;
using System.Text;

namespace HuggiesBot.Huggies
{
    internal class HuggiesReader
    {

        public async Task<string> GetHugGif()
        {
            HuggiesJSON obj;

            Random rnd = new Random();
            using (StreamReader sr = new StreamReader("Huggies/huggies.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync(); //Reading whole file
                obj = JsonConvert.DeserializeObject<HuggiesJSON>(json); //Deserialising file into the ConfigJSON structure
            }

            int lenght = obj.hugs.Count;

            int index = rnd.Next(0, lenght - 1);

            return obj.hugs[index];
        }

        public async Task AddHugGif(string url)
        {
            HuggiesJSON obj;

            // Read existing JSON file
            using (StreamReader sr = new StreamReader("Huggies/huggies.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync();
                obj = JsonConvert.DeserializeObject<HuggiesJSON>(json); // Deserialize
            }

            // Add new URL to the list
            obj.hugs.Add(url);

            // Serialize the object back to a JSON string
            string updatedJson = JsonConvert.SerializeObject(obj, Formatting.Indented);

            // Write the updated JSON back to the file
            using (StreamWriter sw = new StreamWriter("Huggies/huggies.json", false, new UTF8Encoding(false)))
            {
                await sw.WriteAsync(updatedJson);
            }
        }

        public async Task<int> HuggiesCount()
        {
            HuggiesJSON obj;

            Random rnd = new Random();
            using (StreamReader sr = new StreamReader("Huggies/huggies.json", new UTF8Encoding(false)))
            {
                string json = await sr.ReadToEndAsync(); //Reading whole file
                obj = JsonConvert.DeserializeObject<HuggiesJSON>(json); //Deserialising file into the ConfigJSON structure
            }

            return obj.hugs.Count;
        }
    }

    internal sealed class HuggiesJSON
    {
        public List<string> hugs { get; set; }
    }

   
}
