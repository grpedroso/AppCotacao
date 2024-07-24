using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MauiApp1
{
    public static class MauiProgram
    {



        public class DataAPI
        {
            [JsonProperty("totalAsk")]
            public float PrecoC { get; set; }
            [JsonProperty("ask")]
            public float ask { get; set; }
            [JsonProperty("bid")]
            public float bid { get; set; }
            [JsonProperty("totalBid")]
            public float PrecoV { get; set; }
            [JsonProperty("time")]
            public int Time { get; set; }

        }
        public static async Task<DataAPI> GetDataFromAPIAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string reponseBody = await response.Content.ReadAsStringAsync();

                DataAPI data = JsonConvert.DeserializeObject<DataAPI>(reponseBody);
                return data;
            }
        }


        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }); 


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
