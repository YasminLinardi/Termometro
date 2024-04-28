using System.Text.Json;

namespace Termometro;

public partial class MainPage : ContentPAge
{
  const string Url = "https://api.hgbrasil.com/weather?woeid=455927&key=03414340";

    public MainPage()
    {
        InitializeComponent();
        AtualizaTempo();

    }

async void AtualizaTempo()
{
  try
  {
    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync(Url);
    if(response.IsSuucessStatusCode)
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
  labelImg_id.Text = respostas.results.Img_id.ToString();
  labelCurrently.Text = respostas.results.Currently;
  labelCid.Text = respostas.results.Cid;
  labelCity.Text = respostas.results.City;
  labelSunrise.Text = respostas.results.Sunrise;
  labelSunset.Text = respostas.results.Sunset;
  labelWind_speedy.Text = respostas.results.Wind_speedy;
  labelWind_direction.Text = respostas.results.Wind_direction.ToString();
  labelWind_cardinal.Text = respostas.results.Wind_cardinal.ToString();
  labelMoon_phase.Text = respostas.results.Moon_phase.ToString();
  labelCondition_slug.Text = respostas.results.Condition_slug.ToString();
  labelCity_name.Text = respostas.results.City_name;
  labelTimezone.Text = respostas.results.Timezone;
  labelForecast.Text = respostas.results.Forecast;
  if (respostas.results.Moon_phase=="full")
       labeldafaselua.Text = "cheia";
else if(reposta.results.Moon_phase=="new")
       labeldafasedalua.Text = "Nova";
else if(reposta.results.Moon_phase=="growing")
       labeldafasedalua.Text = "Crescente";
else if(reposta.results.Moon_phase=="waning")
       labeldafasedalua.Text = "minguante";


if(resposta.results.currently=="noite")
{
  if(resposta.results.Rain>=10)
     imgFundo.Source="noitechuvosa.png";
  else if(resposta.results.cloudiness>=10)
     imgFundo.Source="noitelimpa.png";
  else
     imgFundo.Source="noitenublada.png";
}

else
{
  if(Resposta.results.Rain>=10)
  imgFundo.Source="diachuvoso.png";
  else if(resposta.results.cloudiness>=10)
  imgFundo.Source="dialimpo.png";
  else
  imgFundo.Source="diachuvoso,png";
}

}






















}





