using GaloEstrellaProgreso3.Models;
using Newtonsoft.Json;

namespace GaloEstrellaProgreso3;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        string cadena = Buscador.Text;
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita" + cadena);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Acept", "application/json");
        var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<GEComentarios>>(content);
            ListaDemo.ItemsSource = resultado;
        }
    }
}

