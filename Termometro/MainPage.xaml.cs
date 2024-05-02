using System.Text.Json;

namespace Termometro;

public partial class MainPage : ContentPage
{
  const string Url = "https://api.hgbrasil.com/weather?woeid=455927&key=03414340";

    public MainPage()
    {
        InitializeComponent();
        AtualizaTempo();

    }

    public Resposta Resposta;

    async void AtualizaTempo()
{
  try
  {
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync(Url);
    if(response.IsSuccessStatusCode)
    {
      var content = await response.Content.ReadAsStringAsync();
      Resposta = JsonSerializer.Deserialize<Resposta>(content);
    }
    PreencherTela();
  }
  catch (Exception e)
  {
    System.Diagnostics.Debug.WriteLine(e);
  }
}

void PreencherTela()
{
  
  labelTemp.Text = Resposta.results.temp.ToString();
  labelHumidity.Text = Resposta.results.humidity.ToString();
  labelDescription.Text = Resposta.results.description;
  labelCity.Text = Resposta.results.city;
  labelRain.Text = Resposta.results.rain.ToString();
  labelSunrise.Text = Resposta.results.sunrise;
  labelSunset.Text = Resposta.results.sunset;
  labelWind_speedy.Text = Resposta.results.wind_speedy;
  labelWind_direction.Text = Resposta.results.wind_direction.ToString();
  labelCloudiness.Text = Resposta.results.cloudiness.ToString( );
  labelCurrently.Text = Resposta.results.currently;
  labelMoon.Text = Resposta.results.moon_phase;

  
  if (Resposta.results.moon_phase=="full")
       labelMoon.Text = "Cheia";
else if(Resposta.results.moon_phase=="new")
       labelMoon.Text = "Nova";
else if(Resposta.results.moon_phase=="first_quarter")
       labelMoon.Text = "Quarto crescente";
else if(Resposta.results.moon_phase=="waxing_crescent")
       labelMoon.Text = "Lua crescente";
else if(Resposta.results.moon_phase=="waxing_gibbous")
       labelMoon.Text = "Gibosa crescente";
else if(Resposta.results.moon_phase=="waning_crescent")
       labelMoon.Text = "Lua minguante";
else if(Resposta.results.moon_phase=="last_quarter")
       labelMoon.Text = "Quarto minguante";
else if(Resposta.results.moon_phase=="waning_gibbous")
       labelMoon.Text = "Gibosa minguante";


if(Resposta.results.currently=="noite")
{
  if(Resposta.results.rain >= 10)
     imgFundo.Source="noitechuvosa.png";
  else if(Resposta.results.cloudiness >= 10)
     imgFundo.Source="noitelimpa.png";
  else
     imgFundo.Source="noitenublada.png";
}

else
{
  if(Resposta.results.rain>=10)
  imgFundo.Source="diachuvoso.png";
  else if(Resposta.results.cloudiness>=10)
  imgFundo.Source="dialimpo.png";
  else
  imgFundo.Source="diachuvoso.png";
}

}

}










