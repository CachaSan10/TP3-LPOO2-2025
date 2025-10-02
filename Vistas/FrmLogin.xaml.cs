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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClasesBase;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public MainWindow()
        {
            InitializeComponent();

            InicializarUsuarios();
        }

        private void InicializarUsuarios()
        {

            usuarios.Add(new Usuario
            {
                Usu_ID = 1,
                Usu_NombreUsuario = "admin",
                Usu_Contrasenia = "1234",
                Usu_ApellidoNombre = "Administrador del sistema",
                Rol_ID = 1 // Administrador
            });

            usuarios.Add(new Usuario
            {

                Usu_ID = 2,
                Usu_NombreUsuario = "docente",
                Usu_Contrasenia = "1234",
                Usu_ApellidoNombre = "Profesor Pérez",
                Rol_ID = 2 // Docente
            });

            usuarios.Add(new Usuario
            {
                Usu_ID = 3,
                Usu_NombreUsuario = "recepcion",
                Usu_Contrasenia = "1234",
                Usu_ApellidoNombre = "Recepción López",
                Rol_ID = 3 // Recepcion
            });

        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = login.txtUsuario.Text;
            string clave = login.txtPassword.Password;
            Usuario encontrado = null;
            foreach (Usuario u in usuarios)
            {
                if (u.Usu_NombreUsuario == usuario && u.Usu_Contrasenia == clave)
                {
                    encontrado = u;
                    break;
                }
            }

            if (encontrado != null)
            {
                //MessageBox.Show("Bienvenido " + encontrado.Usu_ApellidoNombre);
                MessageBoxCustom.ShowSuccess("Bienvenido " + encontrado.Usu_ApellidoNombre);
                Principal win = new Principal();
                win.Show();
                this.Close();
            }
            else
            {
                MessageBoxCustom.ShowError("Usuario o contraseña incorrectos");
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
   
    }
}
