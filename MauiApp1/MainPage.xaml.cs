using Newtonsoft.Json;
using static MauiApp1.MauiProgram;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            LoadDataFromAPI();

        }



        public DataAPI DataBRL { get; set; }
        public DataAPI DataARS { get; set; }


 
        public async void LoadDataFromAPI()
        {
            string url = $"https://criptoya.com/api/binance/usdt/brl/1";
            string urlA = $"https://criptoya.com/api/binance/usdt/ars/1";
            DataBRL = await GetDataFromAPIAsync(url);
            DataARS = await GetDataFromAPIAsync(urlA);
            TextBox.Text = (DataARS.PrecoV / DataBRL.PrecoC).ToString("F2");
            TextBoxA.Text = (DataARS.PrecoC / DataBRL.PrecoV).ToString("F2");
        }

    }

}
