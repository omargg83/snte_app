﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using snte_app;
//
//    var login = Login.FromJson(jsonString);

namespace snte_app
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// SOLICITAR ACCESO
    /// </summary>
    public partial class Solicita
    {
        [JsonProperty("userAcceso")]
        public string userAcceso { get; set; }

        [JsonProperty("passAcceso")]
        public string passAcceso { get; set; }

        [JsonProperty("idfolio")]
        public string idfolio { get; set; }

        [JsonProperty("clvcred")]
        public string clvcred { get; set; }

        [JsonProperty("filiacion")]
        public string Filiacion { get; set; }

        [JsonProperty("function")]
        public string function { get; set; }

        [JsonProperty("ctrl")]
        public string ctrl { get; set; }
    }

    public partial class Solicita
    {
        public static Solicita FromJson(string json) => JsonConvert.DeserializeObject<Solicita>(json, snte_app.Converter.Settings);
    }

    /// <summary>
    /// DATOS DE REGRESO
    /// </summary>
    public partial class Login
    {
        [JsonProperty("acceso")]
        public string Acceso { get; set; }

        [JsonProperty("idpersona")]
        public string Idpersona { get; set; }

        [JsonProperty("filiacion")]
        public string Filiacion { get; set; }
    }

    public partial class Login
    {
        public static Login FromJson(string json) => JsonConvert.DeserializeObject<Login>(json, snte_app.Converter.Settings);
    }

    /// <summary>
    /// Datos del afiliado
    /// </summary>
    public partial class Datos
    {
        [JsonProperty("idfolio")]
        public string idfolio { get; set; }

        [JsonProperty("filiacion")]
        public string filiacion { get; set; }

        [JsonProperty("ape_pat")]
        public string ape_pat { get; set; }

        [JsonProperty("ape_mat")]
        public string ape_mat { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }
    }
    public partial class Datos
    {
        public static Datos FromJson(string json) => JsonConvert.DeserializeObject<Datos>(json, snte_app.Converter.Settings);
    }

    /// <summary>
    /// desde aqui ahorro
    /// </summary>
    public partial class AhorroRes
    {
        [JsonProperty("disponible_anual")]
        public string DisponibleAnual { get; set; }

        [JsonProperty("interes_anual")]
        public string InteresAnual { get; set; }

        [JsonProperty("datos")]
        public Dato[] Datos { get; set; }
    }

    public partial class Dato
    {
        [JsonProperty("anio")]
        public string Anio { get; set; }

        [JsonProperty("quin_nombre")]
        public string QuinNombre { get; set; }

        [JsonProperty("monto")]
        public string Monto { get; set; }

        [JsonProperty("retiro")]
        public string Retiro { get; set; }
    }

    public partial class AhorroRes
    {
        public static AhorroRes FromJson(string json) => JsonConvert.DeserializeObject<AhorroRes>(json, snte_app.Converter.Settings);
    }

    /// <summary>
    /// hasta aqui ahorro
    /// </summary>



    /// <summary>
    /// desde aqui creditos
    /// </summary>
    public partial class Creditores
    {
        [JsonProperty("creditos")]
        public Credito[] Creditos { get; set; }
    }

    public partial class Credito
    {
        [JsonProperty("clv_cred")]
        public string ClvCred { get; set; }

        [JsonProperty("fecha")]
        public string Fecha { get; set; }

        [JsonProperty("monto")]
        public string Monto { get; set; }
    }

    public partial class Creditores
    {
        public static Creditores FromJson(string json) => JsonConvert.DeserializeObject<Creditores>(json, snte_app.Converter.Settings);
    }
    /// <summary>
    /// hasta aqui creditos
    /// </summary>

    /// CREDITO VER

    public partial class Creditover
    {
        [JsonProperty("txt_credito")]
        public string Txtcredito { get; set; }

        [JsonProperty("txt_qini")]
        public string Txtqini { get; set; }

        [JsonProperty("txt_qfin")]
        public string Txtqfin { get; set; }

        [JsonProperty("txt_monto")]
        public string Txtmonto { get; set; }

        [JsonProperty("txt_interes")]
        public string Txtinteres { get; set; }

        [JsonProperty("txt_total")]
        public string Txttotal { get; set; }

        [JsonProperty("txt_abono")]
        public string Txtabono { get; set; }

        [JsonProperty("txt_saldo")]
        public string Txtsaldo { get; set; }

        [JsonProperty("txt_estado")]
        public string Txtestado { get; set; }

        [JsonProperty("txt_plazo")]
        public string Txtplazo { get; set; }

        [JsonProperty("datoscred")]
        public Creddato[] Datos { get; set; }
    }

    public partial class Creddato
    {
        [JsonProperty("anio")]
        public string Anio { get; set; }

        [JsonProperty("quin_nombre")]
        public string QuinNombre { get; set; }

        [JsonProperty("monto")]
        public string Monto { get; set; }

        [JsonProperty("saldo")]
        public string Saldo { get; set; }
    }

    public partial class Creditover
    {
        public static Creditover FromJson(string json) => JsonConvert.DeserializeObject<Creditover>(json, snte_app.Converter.Settings);
    }

    /// <summary>
    /// /hasta aqui ver credito
    /// </summary>
    public static class Serialize
    {
        public static string ToJson(this Login self) => JsonConvert.SerializeObject(self, snte_app.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
