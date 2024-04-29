using System.Text.Json;

namespace Termometro;

public partial class MainPage : ContentPage
{
  const string Url = "https://api.hgbrasil.com/weather?woeid=455927&key=03414340";
    private object labelTemp;
    private object labelWind_direction;

    public MainPage()
    {
        InitializeComponent();
        AtualizaTempo();

    }

    public Resposta Resposta { get; private set; }

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
  
  labelTemp.Text = respostas.results.Temp.ToString();
  labelHumidity.Text = respostas.results.Humidity.ToString();
  labelDescription.Text = respostas.results.Description;
  labelCity.Text = respostas.results.City;
  labelRain.Text = respostas.results.Rain.ToString();
  labelSunrise.Text = respostas.results.Sunrise;
  labelSunset.Text = respostas.results.Sunset;
  labelWind_speedy.Text = respostas.results.Wind_speedy;
  labelWind_direction.Text = respostas.results.Wind_direction.ToString();

  
  if (respostas.results.Moon_phase=="full")
       labelFullMoon.Text = "Cheia";
else if(resposta.results.Moon_phase=="new")
       labelNewMoon.Text = "Nova";
else if(resposta.results.Moon_phase=="growing")
       labelGrowingMoon.Text = "Crescente";
else if(resposta.results.Moon_phase=="waning")
       labelWaningMoon.Text = "Minguante";


if(resposta.results.currently=="Noite")
{
  if(resposta.results.Rain>=10)
     imgFundo.Source="Noitechuvosa.png";
  else if(resposta.results.cloudiness>=10)
     imgFundo.Source="Noitelimpa.png";
  else
     imgFundo.Source="Noitenublada.png";
}

else
{
  if(Resposta.results.Rain>=10)
  imgFundo.Source="Diachuvoso.png";
  else if(resposta.results.cloudiness>=10)
  imgFundo.Source="Dialimpo.png";
  else
  imgFundo.Source="Diachuvoso,png";
}

}






















}










