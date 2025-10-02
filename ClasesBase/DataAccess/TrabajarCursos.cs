using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClasesBase.DataAccess
{
    public class TrabajarCursos
    {
        public static DataTable TraerCursos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.institutoConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                // Query con alias SIN ESPACIOS (más fácil para WPF)
                cmd.CommandText = @"SELECT 
                                    c.cur_id as IDCurso,
                                    c.cur_nombre as Nombre,
                                    c.cur_descripcion as Descripcion,
                                    c.cur_cupo as Cupo,
                                    c.cur_fecha_inicio as FechaInicio,
                                    c.cur_fecha_fin as FechaFin,
                                    e.est_nombre as Estado,
                                    d.doc_apellido + ', ' + d.doc_nombre as Docente
                                  FROM curso c
                                  INNER JOIN estado e ON c.est_id = e.est_id
                                  INNER JOIN docente d ON c.doc_id = d.doc_id
                                  ORDER BY c.cur_id";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }
}