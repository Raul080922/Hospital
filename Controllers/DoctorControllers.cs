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
    internal class DoctorControllers
    {
        public Conexion conexion;

        public DoctorControllers()
        {
            Conexion = new conexion();
        }

        public List<Doctor> ObtenerDoctores()
        {
            List<Doctor> doctores = new List<Doctor>();
            using (SqlConnection con = Conexion.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Doctores";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Especialidad = reader["Especialidad"].ToString()
                    };
                    doctores.Add(doctor);
                }
            }
            return doctores;
        }
    }
}
