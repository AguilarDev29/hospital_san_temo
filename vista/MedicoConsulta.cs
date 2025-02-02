using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class MedicoConsulta : Form
    {
        private string dniMedico;
        private HistoriaClinica historiaClinica;
        public MedicoConsulta(string dniMedico)
        {
            InitializeComponent();
            this.dniMedico = dniMedico;
        }

        private void btnHistoriaClinica_Click(object sender, EventArgs e)
        {
            historiaClinica = new HistoriaClinica(txtDni.Text);
            historiaClinica.Show();
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

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT CONCAT(apellido, ', ', nombre) FROM paciente  WHERE dni = @dni;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtPaciente.Text = reader.GetString(0);
                }
                reader.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDni.Clear();
            txtPaciente.Clear();
            txtDiagnostico.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(AgregarAHistoriaClinica() > 0) MessageBox.Show("Historia Clinica Agregada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int IdTurno(string dniPaciente, string dniMedico)
        {
            string query = "SELECT id FROM turno WHERE id_paciente" +
                " = (SELECT id FROM paciente WHERE dni = @dniPaciente)" +
                " AND id_medico = (SELECT id FROM medico WHERE dni = @dniMedico);";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniPaciente", dniPaciente);
                cmd.Parameters.AddWithValue("@dniMedico", dniMedico);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int IdPaciente(string dniPaciente)
        {
            string query = "SELECT id FROM paciente WHERE dni = @dniPaciente;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniPaciente", dniPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int IdMedico(string dniMedico)
        {
            string query = "SELECT id FROM medico WHERE dni = @dniMedico;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dniMedico", dniMedico);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int AgregarAHistoriaClinica()
        {
            string query = "INSERT INTO historia_clinica (id_paciente, id_medico, id_turno, diagnostico)" +
                " VALUES (@idPaciente, @idMedico, @idTurno, @diagnostico);" +
                "UPDATE turno SET atendido = 'SI' WHERE id = @idTurno;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", IdPaciente(txtDni.Text));
                cmd.Parameters.AddWithValue("@idMedico", IdMedico(dniMedico));
                cmd.Parameters.AddWithValue("@idTurno", IdTurno(txtDni.Text, dniMedico));
                cmd.Parameters.AddWithValue("@diagnostico", txtDiagnostico.Text);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
