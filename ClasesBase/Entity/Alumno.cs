using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Alumno
    {
        private int alu_ID;
        private string alu_DNI;
        private string alu_Apellido;
        private string alu_Nombre;
        private string alu_Email;

        public string Alu_Email
        {
            get { return alu_Email; }
            set { alu_Email = value; }
        }

        public string Alu_Nombre
        {
            get { return alu_Nombre; }
            set { alu_Nombre = value; }
        }

        public string Alu_Apellido
        {
            get { return alu_Apellido; }
            set { alu_Apellido = value; }
        }

        public string Alu_DNI
        {
            get { return alu_DNI; }
            set { alu_DNI = value; }
        }

        public int Alu_ID
        {
            get { return alu_ID; }
            set { alu_ID = value; }
        }
    }
}
