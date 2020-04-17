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
    public partial class credito_ver : ContentPage
    {
        public credito_ver(string cred)
        {
            InitializeComponent();
            Json_credito(cred);
        }
        private async void Json_credito(string cred)
        {
            try
            {
                Solicita solicita = new Solicita();
                solicita.Filiacion = session_sistema.filiacion; 
                solicita.clvcred = cred;
                solicita.function = "credito_ver";

                HttpClient login = new HttpClient();
                string jsonCurso = JsonConvert.SerializeObject(solicita);
                var resultado = await login.PostAsync(session_sistema.url, new StringContent(jsonCurso));
                var json = resultado.Content.ReadAsStringAsync().Result;
                Creditover creditover = Creditover.FromJson(json);

                Txtcredito.Text = creditover.Txtcredito;
                Txtqini.Text = creditover.Txtqini;
                Txtqfin.Text = creditover.Txtqfin;
                Txtmonto.Text = creditover.Txtmonto;
                Txtinteres.Text = creditover.Txtinteres;
                Txttotal.Text = creditover.Txttotal;
                Txtabono.Text = creditover.Txtabono;
                Txtsaldo.Text = creditover.Txtsaldo;
                Txtestado.Text = creditover.Txtestado;
                Txtplazo.Text = creditover.Txtplazo;
                
                listadatoscred.ItemsSource = creditover.Datos;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "ok");
            }
        }
    }
}