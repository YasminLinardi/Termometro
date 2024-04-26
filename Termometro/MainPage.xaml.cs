namespace Termometro;



public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

void PreencherTela()
{
  
  LabelTemp.Text = Respostas.results.Temp
  LabelHumidity.Text = Respostas.results.Humidity
  LabelDescription.Text = Respostas.results.Description
  LabelImg_id.Text = Respostas.results.Img_id
  LabelCurrently.Text = Respostas.results.Currently
  LabelCid.Text = Respostas.results.Cid
  LabelCity.Text = Respostas.results.City
  LabelSunrise.Text = Respostas.results.Sunrise
  LabelSunset.Text = Respostas.results.Sunset
  LabelWind_speedy.Text = Respostas.results.Wind_speedy
  LabelWind_direction.Text = Respostas.results.Wind_direction
  LabelWind_cardinal.Text = Respostas.results.Wind_cardinal
  LabelMoon_phase.Text = Respostas.results.Moon_phase
  LabelCondition_slug.Text = Respostas.results.Condition_slug
  LabelCity_name.Text = Respostas.results.City_name
  LabelTimezone.Text = Respostas.results.Timezone
  LabelForecast.Text = Respostas.results.Forecast



}






















}





