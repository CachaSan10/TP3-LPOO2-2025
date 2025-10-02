using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClasesBase;
namespace ClasesBase.DataAccess
{
    public class TrabajarAlumno
    {

        public Alumno TraerAlumno(int id)
        {
            Alumno alu = null;
            using (SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.institutoConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT alu_id, alu_dni, alu_nombre, alu_apellido, alu_email FROM Alumno WHERE alu_id=@id", cnn);
                cmd.Parameters.AddWithValue("@id", id);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    alu = new Alumno()
                    {
                        Alu_ID = (int)dr["alu_id"],
                        Alu_DNI = dr["alu_dni"].ToString(),
                        Alu_Nombre = dr["alu_nombre"].ToString(),
                        Alu_Apellido = dr["alu_apellido"].ToString(),
                        Alu_Email = dr["alu_email"].ToString()
                    };

                }
            }
            return alu;
        }
    }
}
