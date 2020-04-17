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
    public partial class credito : ContentPage
    {
        Creditores creditores;
        public credito()
        {
            InitializeComponent();
            Json_creditos();
        }
        private async void Json_creditos()
        {
            try
            {
                Solicita solicita = new Solicita();
                solicita.Filiacion = session_sistema.filiacion;
                solicita.function = "credito_app";

                HttpClient login = new HttpClient();
                string jsonCurso = JsonConvert.SerializeObject(solicita);
                var resultado = await login.PostAsync(session_sistema.url, new StringContent(jsonCurso));
                var json = resultado.Content.ReadAsStringAsync().Result;

                creditores = Creditores.FromJson(json);
                listacreditos.ItemsSource = creditores.Creditos;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "ok");
            }
        }
        public async void lvItemTapped(object sender, ItemTappedEventArgs e) { 
            int id = Convert.ToInt32(e.ItemIndex);
            
            await Navigation.PushAsync(new credito_ver(creditores.Creditos[id].ClvCred));
        }


    }
}