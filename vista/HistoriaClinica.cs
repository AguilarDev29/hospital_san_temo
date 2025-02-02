using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class HistoriaClinica : Form
    {
        private string dniPaciente;
        private SqlDataAdapter dataAdapter;
        private System.Data.DataTable dataTable;
        public HistoriaClinica(string dniPaciente)
        {
            InitializeComponent();
            this.dniPaciente = dniPaciente;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void HistoriaClinica_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string query = "EXECUTE spListar_historia_clinica @dni_paciente;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@dni_paciente", dniPaciente);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewHistoriaClinica.DataSource = dataTable;
                dataGridViewHistoriaClinica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

    }
}
