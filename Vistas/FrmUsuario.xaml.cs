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
using ClasesBase;
using ClasesBase.Utilities.Validators;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para FrmUsuario.xaml
    /// </summary>
    public partial class FrmUsuario : Window
    {

        private List<Roles> roles = new List<Roles>();
        private string errores = "";
        public FrmUsuario()
        {
            InitializeComponent();
            InicializarRoles();
        }

        /// <summary>
        /// Limpia todos los controles de entrada del formulario.
        /// </summary>
        private void Limpiar_Campos()
        {
            altaUsuario.txtApellido.Clear();
            altaUsuario.txtNombre.Clear();
            altaUsuario.txtNombreUsuario.Clear();
            altaUsuario.txtPassword.Clear();
            altaUsuario.cmbRol.SelectedIndex = -1;
        }

        private void InicializarRoles()
        {
            // Limpiar elementos existentes del XAML
            altaUsuario.cmbRol.Items.Clear();

            // Cargar roles disponibles
            roles.Add(new Roles { Rol_ID = 1, Rol_Descripcion = "Administrador" });
            roles.Add(new Roles { Rol_ID = 2, Rol_Descripcion = "Docente" });
            roles.Add(new Roles { Rol_ID = 3, Rol_Descripcion = "Recepción" });

            // Enlazar lista al ComboBox
            altaUsuario.cmbRol.ItemsSource = roles;
            
            altaUsuario.cmbRol.SelectedValuePath = "Rol_ID";          
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Valida los campos, guarda un nuevo usuario y limpia el formulario.
        /// </summary>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxConfirm("¿Desea guardar el Usuario?", "Atención");
            bool? resultado = confirmacion.ShowDialog();
            if (resultado == true)
            {
                if (verificarCampos())
                {
                    // Crear un objeto Usuario y asignar los valores
                    Usuario oUsuario = new Usuario();
                    oUsuario.Usu_ApellidoNombre = altaUsuario.txtApellido.Text + " " + altaUsuario.txtNombre.Text;
                    oUsuario.Usu_Contrasenia = altaUsuario.txtPassword.Text;
                    oUsuario.Usu_NombreUsuario = altaUsuario.txtNombreUsuario.Text;
               
                    oUsuario.Rol_ID = altaUsuario.cmbRol.SelectedValue != null ? (int)altaUsuario.cmbRol.SelectedValue : 0;

                    // Mostrar datos del usuario creado
                    MessageBoxCustom.ShowSuccess(
                        //"Usuario Cargado: \n" +
                        //"Apellido y Nombre: " + oUsuario.Usu_ApellidoNombre + "\n" +
                        //"Nombre de Usuario: " + oUsuario.Usu_NombreUsuario + "\n" +
                        //"Rol: " + altaUsuario.cmbRol.SelectedItem.ToString() + "\n" +
                        //"Contraseña: " + new string('*', oUsuario.Usu_Contrasenia.Length)
                       "Usuario Guardado"

                        
                    );

                    Limpiar_Campos();
                }
                else
                {
                    MessageBoxCustom.ShowError(errores);
                    errores = "";
                }
            }
        }

        /// <summary>
        /// Verifica que todos los campos estén completos y válidos.
        /// </summary>
        private Boolean verificarCampos()
        {
            Boolean verificado = false;
            var resultadoNombre = StringValidatorNombreApellido.ValidarNombreApellido("Nombre" , altaUsuario.txtNombre.Text);
            var resultadoApellido = StringValidatorNombreApellido.ValidarNombreApellido("Apellido", altaUsuario.txtApellido.Text);
            var resultadoUsuario = UserValidator.ValidarUsuario(altaUsuario.txtNombreUsuario.Text);
            var resultadoContraseña = PasswordValidator.ValidarPassword(altaUsuario.txtPassword.Text);
            var resultadoCmbRol = ComboBoxValidator.ValidarSeleccion(altaUsuario.cmbRol, "Rol");

            if (resultadoNombre.IsValid && resultadoApellido.IsValid &&
                resultadoUsuario.IsValid &&
                resultadoContraseña.IsValid &&
                resultadoCmbRol.IsValid)
            {
                verificado = true;
            }
            else {
                if (!resultadoNombre.IsValid)
                {
                    errores = resultadoNombre.ErrorMessage + "\n";
                }

                if (!resultadoApellido.IsValid)
                {
                    errores = errores + " " + resultadoApellido.ErrorMessage + "\n";
                }

                if (!resultadoUsuario.IsValid) {
                    errores = errores + " " + resultadoUsuario.ErrorMessage + "\n";
                }

                if (!resultadoContraseña.IsValid) {
                    errores = errores + " " + resultadoContraseña.ErrorMessage + "\n";
                }

                if (!resultadoCmbRol.IsValid)
                {
                    errores = errores + " " + resultadoCmbRol.ErrorMessage + "\n";
                }
            }

            return verificado;
        }

        /// <summary>
        /// Evento para manejar cambios en la contraseña.
        /// </summary>
        private void txtContrasena_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Puedes agregar validación de contraseña aquí si es necesario
        }

    }
}
