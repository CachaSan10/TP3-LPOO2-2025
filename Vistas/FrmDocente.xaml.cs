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
    /// Interaction logic for FrmDocente.xaml
    /// </summary>
    public partial class FrmDocente : Window
    {
        string errores = "";
        public FrmDocente()
        {
            InitializeComponent();
        }

        private void Limpiar_Campos()
        {

            altaDocente.txtDNI.Clear();
            altaDocente.txtApellido.Clear();
            altaDocente.txtNombre.Clear();
            altaDocente.txtEmail.Clear();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxConfirm("¿Desea guardar el Docente?", "Atención");
            bool? resultado = confirmacion.ShowDialog();
            if (resultado == true)
            {
                if (verificarCampos())
                {
                    Docente oDocente = new Docente();
                    oDocente.Doc_DNI = altaDocente.txtDNI.Text;
                    oDocente.Doc_Apellido = altaDocente.txtApellido.Text;
                    oDocente.Doc_Nombre = altaDocente.txtNombre.Text;
                    oDocente.Doc_Email = altaDocente.txtEmail.Text;


                    MessageBoxCustom.ShowSuccess(

                        //"Docente cargado: \n" +
                        //"DNI: " + oDocente.Doc_DNI + "\n" +
                        //"Apellido: " + oDocente.Doc_Apellido + "\n" +
                        //"Nombre: " + oDocente.Doc_Nombre + "\n" +
                        //"Email: " + oDocente.Doc_Email, "Datos Guardados", MessageType.Success
                        "Docente Guardado"
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
            var resultadoNombre = StringValidatorNombreApellido.ValidarNombreApellido("Nombre", altaDocente.txtNombre.Text);
            var resultadoApellido = StringValidatorNombreApellido.ValidarNombreApellido("Apellido", altaDocente.txtApellido.Text);
            var resultadoDni = DniValidator.ValidarDni(altaDocente.txtDNI.Text);
            var resultadoEmail = EmailValidator.ValidarEmail(altaDocente.txtEmail.Text);

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
