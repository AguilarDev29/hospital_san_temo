using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class PanelAdmin : Form
    {
        private IngresoMedico cargarMedico;
        private Finanzas finanzas;
        private SqlDataAdapter dataAdapter;
        private System.Data.DataTable dataTable;
        public PanelAdmin()
        {
            InitializeComponent();
        }

        private void PanelAdmin_Load(object sender, EventArgs e)
        {
            /*// TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet15.vista_medicos' Puede moverla o quitarla según sea necesario.
            this.vista_medicosTableAdapter2.Fill(this.hospital_san_telmoDataSet15.vista_medicos);
            // TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet14.vista_pacientes' Puede moverla o quitarla según sea necesario.
            this.vista_pacientesTableAdapter2.Fill(this.hospital_san_telmoDataSet14.vista_pacientes);
            // TODO: esta línea de código carga datos en la tabla 'hospital_san_telmoDataSet13.vista_turnos_pendientes' Puede moverla o quitarla según sea necesario.
            this.vista_turnos_pendientesTableAdapter2.Fill(this.hospital_san_telmoDataSet13.vista_turnos_pendientes);*/

            LoadTurnos();
            LoadPacientes();
            LoadMedicos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.ExitThread();
                Dispose();
            }
        }


        private void btnCargarMedicos_Click(object sender, EventArgs e)
        {
            cargarMedico = new IngresoMedico();
            cargarMedico.Show();
            Hide();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            finanzas = new Finanzas();
            finanzas.Show();
            Hide();
        }

        private void LoadTurnos()
        {
            string query = "SELECT * FROM vista_turnos_pendientes;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewTurnos.DataSource = dataTable;
                dataGridViewTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void LoadPacientes()
        {
            string query = "SELECT * FROM vista_pacientes;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewPacientes.DataSource = dataTable;
                dataGridViewPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void LoadMedicos()
        {
            string query = "SELECT * FROM vista_medicos;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                dataAdapter = new SqlDataAdapter(query, conn);
                dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewMedicos.DataSource = dataTable;
                dataGridViewMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }
    }
}
