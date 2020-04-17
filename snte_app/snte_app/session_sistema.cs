namespace snte_app
{
    class session_sistema
    {
        private static string idpersona_tmp = "";
        private static string filiacion_tmp = "";
        private static string url_tmp = "";

        public static string idpersona
        {
            get { return idpersona_tmp; }
            set { idpersona_tmp = value; }
        }
        public static string url
        {
            get { return url_tmp; }
            set { url_tmp = value; }
        }

        public static string filiacion
        {
            get { return filiacion_tmp; }
            set { filiacion_tmp = value; }
        }
    }
}
