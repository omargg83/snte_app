using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace snte_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ahorro : ContentPage
    {
        public Ahorro()
        {
            InitializeComponent();
            Json_ahorro();
        }
        private async void Json_ahorro()
        {
            try
            {
                Solicita solicita = new Solicita();
                solicita.idfolio = session_sistema.idpersona;
                solicita.function = "ahorro_app";

                HttpClient login = new HttpClient();
                string jsonCurso = JsonConvert.SerializeObject(solicita);
                var resultado = await login.PostAsync(session_sistema.url, new StringContent(jsonCurso));
                var json = resultado.Content.ReadAsStringAsync().Result;

                AhorroRes ahorroresp = AhorroRes.FromJson(json);
                DisponibleAnual.Text = ahorroresp.DisponibleAnual;
                interes_anual.Text = ahorroresp.InteresAnual;

                listadatos.ItemsSource = ahorroresp.Datos;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",  ex.ToString(), "ok");
            }            
        }
      
    }
}