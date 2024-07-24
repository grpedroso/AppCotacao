using Newtonsoft.Json;
using static MauiApp1.MainPage;
using static MauiApp1.MauiProgram;

namespace MauiApp1;

public partial class CalcPage : ContentPage
{
	public CalcPage()
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
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        float.TryParse(CalcBox.Text, out float value);
        ResultBox.Text = (value / (DataARS.PrecoC / DataBRL.PrecoV)).ToString("F2");
        CalcBox.Text = string.Empty;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        float.TryParse(CalcBox1.Text, out float value);
        ResultBox1.Text = (value * (DataARS.PrecoV / DataBRL.PrecoC)).ToString("F2");
        CalcBox1.Text = string.Empty;
    }
}