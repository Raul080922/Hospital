using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.config;

namespace Hospital.Controllers
{

    public class ConsultaController
    {
        public Conexion conexion;

        public ConsultaController()
        {
             conexion = new Conexion ();
        }
        public Doctor ObtenerDoctorConMasConsultasPorMes(int mes, int año)
        {
            Doctor doctorConMasConsultas = null;
            using (SqlConnection con = Conexion.GetConnection())
            {
                con.Open();
                string query = @"
                SELECT TOP 1 d.Id, d.Nombre, COUNT(c.Id) AS TotalConsultas
                FROM Consultas c
                JOIN Doctores d ON c.DoctorId = d.Id
                WHERE MONTH(c.Fecha) = @Mes AND YEAR(c.Fecha) = @Ano
                GROUP BY d.Id, d.Nombre
                ORDER BY COUNT(c.Id) DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Mes", mes);
                cmd.Parameters.AddWithValue("@Ano", año);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    doctorConMasConsultas = new Doctor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                    };
                    Console.WriteLine($"Doctor con más consultas: {doctorConMasConsultas.Nombre}, Total Consultas: {reader["TotalConsultas"]}");
                }
            }
            return doctorConMasConsultas;
        }
    }

}