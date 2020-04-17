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
    public partial class Datos : ContentPage
    {
        public Datos()
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

            Afiliado afiliado = Afiliado.FromJson(json);
            socio.Text = afiliado.idfolio;
            filiacion.Text = afiliado.filiacion;
            ape_pat.Text = afiliado.ape_pat;
            ape_mat.Text = afiliado.ape_mat;
            nombre.Text = afiliado.nombre;
            d_dom.Text = afiliado.d_dom;
        }      
        private async void Btn_salir(object sender, EventArgs args) 
        {
            await Navigation.PopAsync();
        }
    }
}