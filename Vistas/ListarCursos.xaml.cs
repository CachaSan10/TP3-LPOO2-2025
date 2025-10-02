using System;
using System.Windows;
using System.Windows.Input;
using System.Data;
using ClasesBase.DataAccess;

namespace Vistas
{
    public partial class ListarCursos : Window
    {
        public ListarCursos()
        {
            InitializeComponent();
            
        }


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            // Actualizar el ObjectDataProvider como en la consigna
            var dataProvider = (System.Windows.Data.ObjectDataProvider)this.Resources["list_cursos"];
            dataProvider.Refresh();
        }

        private void btnNuevoCurso_Click(object sender, RoutedEventArgs e)
        {
            FrmCurso nuevoCurso = new FrmCurso();
            nuevoCurso.Owner = this;
            bool? resultado = nuevoCurso.ShowDialog();

            if (resultado == true)
            {
                // Actualizar después de cerrar si se guardó un nuevo curso
                btnActualizar_Click(sender, e);
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar esta ventana
            this.Close();
        }

        private void dgCursos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Al hacer doble clic en un curso
            if (dgCursos.SelectedItem != null)
            {
                DataRowView filaSeleccionada = (DataRowView)dgCursos.SelectedItem;
                string nombreCurso = filaSeleccionada["cur_nombre"].ToString();
                MessageBox.Show("Curso seleccionado: " + nombreCurso,
                            "Información del Curso", 
                              MessageBoxButton.OK, 
                              MessageBoxImage.Information);
            }
        }
    }
}