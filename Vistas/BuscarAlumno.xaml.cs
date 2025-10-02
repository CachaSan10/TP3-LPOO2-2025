using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para BuscarAlumno.xaml
    /// </summary>
    public partial class BuscarAlumno : Window
    {
        public BuscarAlumno()
        {
            InitializeComponent();
            txtID.TextChanged += TxtID_TextChanged;
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id;
            if (int.TryParse(txtID.Text, out id))
            {
                var odp = (ObjectDataProvider)this.Resources["AlumnoProvider"];
                odp.MethodParameters[0] = id;
                odp.Refresh(); 
            }
            else
            {
               
                var odp = (ObjectDataProvider)this.Resources["AlumnoProvider"];
                odp.MethodParameters[0] = 0;
                odp.Refresh();
            }
        }


        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        
    }
}
