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
  
  labelTemp.Text = Resposta.Results.Temp.ToString();
  labelHumidity.Text = Resposta.Results.Humidity.ToString();
  labelDescription.Text = Resposta.Results.Description;
  labelCity.Text = Resposta.Results.City;
  labelRain.Text = Resposta.Results.Rain.ToString();
  labelSunrise.Text = Resposta.Results.Sunrise;
  labelSunset.Text = Resposta.Results.Sunset;
  labelWind_speedy.Text = Resposta.Results.Wind_speedy;
  labelWind_direction.Text = Resposta.Results.Wind_direction.ToString();
  labelCloudiness.Text = Resposta.Results.Cloudiness.ToString( );
  labelCurrently.Text = Resposta.Results.Currently;

  
  if (Resposta.Results.Moon_phase=="full")
       labelFullMoon.Text = "Cheia";
else if(Resposta.Results.Moon_phase=="new")
       labelNewMoon.Text = "Nova";
else if(Resposta.Results.Moon_phase=="first_quarter")
       labelGrowingMoon.Text = "Quarto crescente";
else if(Resposta.Results.Moon_phase=="waxing_crescent")
       labelGrowingMoon.Text = "Lua crescente";
else if(Resposta.Results.Moon_phase=="waxing_gibbous")
       labelGrowingMoon.Text = "Gibosa crescente";
else if(Resposta.Results.Moon_phase=="waning_crescent")
       labelWaningMoon.Text = "Lua minguante";
else if(Resposta.Results.Moon_phase=="Last_quarter")
       labelWaningMoon.Text = "Quarto minguante";
else if(Resposta.Results.Moon_phase=="waning_gibbous")
       labelWaningMoon.Text = "Gibosa minguante";


if(Resposta.Results.Currently=="Noite")
{
  if(Resposta.Results.Rain >= 10)
     imgFundo.Source="Noitechuvosa.png";
  else if(Resposta.Results.Cloudiness >= 10)
     imgFundo.Source="Noitelimpa.png";
  else
     imgFundo.Source="Noitenublada.png";
}

else
{
  if(Resposta.Results.Rain>=10)
  imgFundo.Source="Diachuvoso.png";
  else if(Resposta.Results.Cloudiness>=10)
  imgFundo.Source="Dialimpo.png";
  else
  imgFundo.Source="Diachuvoso,png";
}

}






















}










