using System;
using System.Windows.Forms;
using Hospital.Controllers;
using Hospital.Controllers;

namespace Hospital.views
{
    public partial class FrmReporteDoctor : Form
    {
        private ConsultaController consultaController;

        public FrmReporteDoctor()
        {
            InitializeComponent();
            consultaController = new ConsultaController();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            int mes = cmbMes.SelectedIndex + 1;
            int anio = (int)nudAnio.Value;

            var resultado = consultaController.GetDoctorConMasPacientesEnMes(mes, anio);

            if (resultado.Rows.Count > 0)
            {
                MessageBox.Show($"Doctor: {resultado.Rows[0]["Doctor"]} \nTotal Consultas: {resultado.Rows[0]["TotalConsultas"]}");
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el mes y año seleccionados.");
            }
        }
    }
}
