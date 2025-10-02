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
    /// Interaction logic for FrmCurso.xaml
    /// </summary>
    public partial class FrmCurso : Window
    {
        private List<Estado> estados = new List<Estado>();
        private List<EstadoType> estadoTypes = new List<EstadoType>();
        private List<Docente> docentes = new List<Docente>();
        string errores = "";

        public FrmCurso()
        {
            InitializeComponent();
           
        }

        private void Limpiar_Campos()
        {
            altaCurso.txtNombre.Clear();
            altaCurso.txtDescripcion.Clear();
            altaCurso.txtCupo.Clear();
            altaCurso.dpFechaInicio.SelectedDate = null;
            altaCurso.dpFechaFin.SelectedDate = null;
            altaCurso.cmbTipoEstado.SelectedIndex = -1;
            altaCurso.cmbEstado.ItemsSource = null;
            altaCurso.cmbDocente.SelectedIndex = -1;
        }

   

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var confirmacion = new MessageBoxConfirm("¿Desea guardar este Curso?", "Atención");
            bool? resultado = confirmacion.ShowDialog();

            if (resultado == true)
            {
                if (verificarCampos())
                {
                    Curso oCurso = new Curso();
                    oCurso.Cur_Nombre = altaCurso.txtNombre.Text;
                    oCurso.Cur_Descripcion = altaCurso.txtDescripcion.Text;
                    oCurso.Cur_Cupo = int.Parse(altaCurso.txtCupo.Text);
                    oCurso.Cur_FechaInicio = altaCurso.dpFechaInicio.SelectedDate ?? DateTime.MinValue;
                    oCurso.Cur_FechaFin = altaCurso.dpFechaFin.SelectedDate ?? DateTime.MinValue;
                    int tipoSeleccionado = altaCurso.cmbTipoEstado.SelectedValue != null ? (int)altaCurso.cmbTipoEstado.SelectedValue : 0;
                    //oCurso.Est_ID = cmbTipoEstado.SelectedValue != null ? (int)cmbTipoEstado.SelectedValue : 0;

                    oCurso.Doc_ID = altaCurso.cmbDocente.SelectedValue != null ? (int)altaCurso.cmbDocente.SelectedValue : 0;


                    MessageBoxCustom.ShowSuccess(

                      "Datos del curso guardado"
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
            int cupo;
            var resultadoNombre = StringValidatorNombreApellido.ValidarNombreApellido("Nombre", altaCurso.txtNombre.Text);
            var resultadoDescripcion = DescripcionValidator.ValidarDescripcion(altaCurso.txtDescripcion.Text);
            var resultadoCmbEstado = ComboBoxValidator.ValidarSeleccion(altaCurso.cmbEstado, "Estado");
            var resultadoCmbTipoEstado = ComboBoxValidator.ValidarSeleccion(altaCurso.cmbTipoEstado, "Tipo Estado");
            var resultadoCmbDocente = ComboBoxValidator.ValidarSeleccion(altaCurso.cmbDocente, "Docente");
            var resultadoFechaInicio = FechaValidator.ValidarFechaFutura(altaCurso.dpFechaInicio.SelectedDate, "Inicio");
            var resultadoFechaFin = FechaValidator.ValidarFechaFutura(altaCurso.dpFechaFin.SelectedDate , "Fin");
            var resultadoRangoFecha = FechaValidator.ValidarRangoFechas(altaCurso.dpFechaInicio.SelectedDate, altaCurso.dpFechaFin.SelectedDate);

            if (
               resultadoNombre.IsValid &&
               resultadoCmbEstado.IsValid &&
               resultadoCmbTipoEstado.IsValid &&
               resultadoCmbDocente.IsValid &&
               resultadoDescripcion.IsValid &&
               int.TryParse(altaCurso.txtCupo.Text, out cupo) &&
               resultadoFechaInicio.IsValid &&
               resultadoFechaFin.IsValid && resultadoRangoFecha.IsValid
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

                if (!resultadoDescripcion.IsValid)
                {
                    errores = errores  + resultadoDescripcion.ErrorMessage + "\n";
                }

                if (!resultadoCmbEstado.IsValid) {
                    errores = errores + resultadoCmbEstado.ErrorMessage + "\n";
                }

                if (!resultadoCmbTipoEstado.IsValid)
                {
                    errores = errores + resultadoCmbEstado.ErrorMessage + "\n";
                }

                if (!resultadoCmbDocente.IsValid)
                {
                    errores = errores + resultadoCmbDocente.ErrorMessage + "\n";
                }

                if (!int.TryParse(altaCurso.txtCupo.Text, out cupo)) {
                    errores = errores + "El curso debe ser numero"+ "\n";
                }

                if (!resultadoFechaInicio.IsValid)
                {
                    errores = errores + resultadoFechaInicio.ErrorMessage + "\n";
                }

                if (!resultadoFechaFin.IsValid)
                {
                    errores = errores + resultadoFechaFin.ErrorMessage + "\n";
                }

                if (!resultadoRangoFecha.IsValid)
                {
                    errores = errores + resultadoRangoFecha.ErrorMessage + "\n";
                }


            }

            return verificado;
        }

        
    }
}
