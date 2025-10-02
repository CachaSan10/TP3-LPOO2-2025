using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Usuario
    {
        private int usu_ID;
        private string usu_NombreUsuario;
        private int rol_ID;
        private string usu_Contrasenia;
        private string usu_ApellidoNombre;

        public string Usu_ApellidoNombre
        {
            get { return usu_ApellidoNombre; }
            set { usu_ApellidoNombre = value; }
        }

        public string Usu_Contrasenia
        {
            get { return usu_Contrasenia; }
            set { usu_Contrasenia = value; }
        }

        public int Rol_ID
        {
            get { return rol_ID; }
            set { rol_ID = value; }
        }

        public string Usu_NombreUsuario
        {
            get { return usu_NombreUsuario; }
            set { usu_NombreUsuario = value; }
        }

        public int Usu_ID
        {
            get { return usu_ID; }
            set { usu_ID = value; }
        }
    }
}
