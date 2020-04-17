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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            Llenarinfo();
        }

        private async void Llenarinfo()
        {
            Solicita solicita = new Solicita();
            solicita.idfolio = session_sistema.idpersona;
            solicita.function = "afiliado";

            HttpClient login = new HttpClient();
            string jsonCurso = JsonConvert.SerializeObject(solicita);
            var resultado = await login.PostAsync(session_sistema.url, new StringContent(jsonCurso));
            var json = resultado.Content.ReadAsStringAsync().Result;

            Datos datos = Datos.FromJson(json);
            socio.Text = datos.idfolio;
            filiacion.Text = datos.filiacion;
            ape_pat.Text = datos.ape_pat;
            ape_mat.Text = datos.ape_mat;
            nombre.Text = datos.nombre;

        }

        private async void Btn_ahorro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Ahorro());
        }
        private async void Btn_credito(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new credito());
        }
        private async void Btn_salir(object sender, EventArgs args) 
        {
            await Navigation.PopAsync();
        }
    }
}