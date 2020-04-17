using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace snte_app
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //session_sistema.url = "http://172.16.0.24/cajasnte/snte_.php";
            session_sistema.url = "http://cajaseccion15snte.com.mx/snte_.php";
            //session_sistema.url = "http://192.168.100.15/cajasnte/snte_.php";
        }

        private async void Btn_login(object sender, EventArgs args)
        {
   
            try
            {
                Solicita solicita = new Solicita();
                solicita.userAcceso = txt_usuario.Text.Trim();
                solicita.passAcceso = txt_pass.Text.Trim();
                solicita.function = "acceso";
                solicita.ctrl = "";

                HttpClient login = new HttpClient();
                string jsonCurso = JsonConvert.SerializeObject(solicita);
                var resultado = await login.PostAsync(session_sistema.url, new StringContent(jsonCurso));
                var json = resultado.Content.ReadAsStringAsync().Result;

                Login resp = Login.FromJson(json);
                if (resp.Acceso.ToString()== "1")
                {
                    session_sistema.idpersona = resp.Idpersona.ToString();
                    session_sistema.filiacion = resp.Filiacion.ToString();
                    await Navigation.PushAsync(new Menu());
                }
                else {
                    await DisplayAlert("Usuario o contraseña incorrecta", session_sistema.url+"SNTE", "ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Usuario o contraseña incorrecta", session_sistema.url +  ex.ToString(), "ok");
            }
        }
    }
}
