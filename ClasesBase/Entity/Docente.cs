using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Docente
    {
        private int doc_ID;
        private string doc_DNI;
        private string doc_Apellido;
        private string doc_Nombre;
        private string doc_Email;

        public string Doc_Email
        {
            get { return doc_Email; }
            set { doc_Email = value; }
        }

        public string Doc_Nombre
        {
            get { return doc_Nombre; }
            set { doc_Nombre = value; }
        }

        public string Doc_Apellido
        {
            get { return doc_Apellido; }
            set { doc_Apellido = value; }
        }

        public string Doc_DNI
        {
            get { return doc_DNI; }
            set { doc_DNI = value; }
        }

        public int Doc_ID
        {
            get { return doc_ID; }
            set { doc_ID = value; }
        }
    }
}
