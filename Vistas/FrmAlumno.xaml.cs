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
    /// Interaction logic for FrmAlumno.xaml
    /// </summary>
    public partial class FrmAlumno : Window
    {
        string errores = "";
        public FrmAlumno()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Limpiar_Campos()
        {

            altaAlumno.txtDNI.Clear();
            altaAlumno.txtApellido.Clear();
            altaAlumno.txtNombre.Clear();
            altaAlumno.txtEmail.Clear();
        } 
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxConfirm("¿Desea guardar el Alumno?", "Atención");
            bool? resultado = confirmacion.ShowDialog();
            if (resultado == true)
            {

                if (verificarCampos())
                {
                    Alumno oAlumno = new Alumno();
                    oAlumno.Alu_DNI = altaAlumno.txtDNI.Text;
                    oAlumno.Alu_Apellido = altaAlumno.txtApellido.Text;
                    oAlumno.Alu_Nombre = altaAlumno.txtNombre.Text;
                    oAlumno.Alu_Email = altaAlumno.txtEmail.Text;


                    MessageBoxCustom.ShowSuccess(

                        //"Alumno cargado: \n" +
                        //"DNI: " + oAlumno.Alu_DNI + "\n" +
                        //"Apellido: " + oAlumno.Alu_Apellido + "\n" +
                        //"Nombre: " + oAlumno.Alu_Nombre + "\n" +
                        //"Email: " + oAlumno.Alu_Email
                        "Alumno Guardado"
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

        private Boolean verificarCampos()
        {
            Boolean verificado = false;
            var resultadoNombre = StringValidatorNombreApellido.ValidarNombreApellido("Nombre", altaAlumno.txtNombre.Text);
            var resultadoApellido = StringValidatorNombreApellido.ValidarNombreApellido("Apellido", altaAlumno.txtApellido.Text);
            var resultadoDni = DniValidator.ValidarDni(altaAlumno.txtDNI.Text);
            var resultadoEmail = EmailValidator.ValidarEmail(altaAlumno.txtEmail.Text);

            if (resultadoNombre.IsValid && resultadoApellido.IsValid &&
                resultadoEmail.IsValid && resultadoDni.IsValid
                )
            {
                verificado = true;
            }
            else
            {
                if (!resultadoNombre.IsValid)
                {
                    errores = resultadoNombre.ErrorMessage + "\n";
                }

                if (!resultadoApellido.IsValid)
                {
                    errores = errores + " " + resultadoApellido.ErrorMessage + "\n";
                }

                if (!resultadoDni.IsValid)
                {
                    errores = errores + " " + resultadoDni.ErrorMessage + "\n";
                }

                if (!resultadoEmail.IsValid)
                {
                    errores = errores + " " + resultadoEmail.ErrorMessage + "\n";
                }

            }

            return verificado;
        }

       
    }
}
