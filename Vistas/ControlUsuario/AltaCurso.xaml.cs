﻿using System;
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

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para AltaCurso.xaml
    /// </summary>
    public partial class AltaCurso : UserControl
    {
        private List<Estado> estados = new List<Estado>();
        private List<EstadoType> estadoTypes = new List<EstadoType>();
        private List<Docente> docentes = new List<Docente>();
        public AltaCurso()
        {
            InitializeComponent();
            InicializarEstados();
            InicializarDocentes();
        }

        private void InicializarEstados()
        {
            // Tipos de estado
            estadoTypes.Add(new EstadoType { Esty_ID = 1, Esty_Nombre = "Curso" });
            //estadoTypes.Add(new EstadoType { Esty_ID = 2, Esty_Nombre = "Inscripción" });

            // Estados para Curso
            estados.Add(new Estado { Est_ID = 1, Est_Nombre = "Programado", Esty_ID = 1 });
            estados.Add(new Estado { Est_ID = 2, Est_Nombre = "En Curso", Esty_ID = 1 });
            estados.Add(new Estado { Est_ID = 3, Est_Nombre = "Finalizado", Esty_ID = 1 });
            estados.Add(new Estado { Est_ID = 4, Est_Nombre = "Cancelado", Esty_ID = 1 });

            // Estados para Inscripción
            //estados.Add(new Estado { Est_ID = 5, Est_Nombre = "Inscripto", Esty_ID = 2 });
            //estados.Add(new Estado { Est_ID = 6, Est_Nombre = "Confirmado", Esty_ID = 2 });
            //estados.Add(new Estado { Est_ID = 7, Est_Nombre = "Cancelado", Esty_ID = 2 });

            // Cargar tipos en el combo
            cmbTipoEstado.ItemsSource = estadoTypes;
            
            cmbTipoEstado.SelectedValuePath = "Esty_ID";
        }

        private void cmbTipoEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoEstado.SelectedValue != null)
            {
                int tipoId = (int)cmbTipoEstado.SelectedValue;

                // Filtramos estados según el tipo seleccionado
                var estadosFiltrados = estados.Where(est => est.Esty_ID == tipoId).ToList();

                cmbEstado.ItemsSource = estadosFiltrados;
                
                cmbEstado.SelectedValuePath = "Est_ID";
            }
        }

        private void InicializarDocentes()
        {

            docentes.Add(new Docente { Doc_ID = 1, Doc_Nombre = "Juan Pérez" });
            docentes.Add(new Docente { Doc_ID = 2, Doc_Nombre = "María González" });
            docentes.Add(new Docente { Doc_ID = 3, Doc_Nombre = "Carlos López" });

            // Enlazar lista al ComboBox
             
            cmbDocente.ItemsSource = docentes;
            //cmbDocente.DisplayMemberPath = "Doc_Nombre";
            cmbDocente.SelectedValuePath = "Doc_ID";
        }

   
    }
}
