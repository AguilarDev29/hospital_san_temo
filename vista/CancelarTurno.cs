using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class CancelarTurno : Form
    {
        private int idPaciente;
        public CancelarTurno(int idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
        }

        private void Turnos(int idPaciente)
        {
            string query = "SELECT CONCAT(m.apellido, ', ', m.nombre) " +
                        "AS medico, e.nombre AS especialidad FROM turno t " +
                        "INNER JOIN paciente p ON t.id_paciente = p.id " +
                        "INNER JOIN medico m ON t.id_medico = m.id " +
                        "INNER JOIN especialidad e ON m.id_especialidad = e.id " +
                        "WHERE t.id_paciente = @idPaciente AND t.cancelado = 'NO' AND t.atendido = 'NO';";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbTurnos.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));
                }
            }
        }

        private int Cancelar(int idPaciente)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "UPDATE turno SET cancelado = 'SI' WHERE id_paciente = @id_paciente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                return cmd.ExecuteNonQuery();
            }
        }

        private void CancelarTurno_Load(object sender, EventArgs e)
        {
            Turnos(idPaciente);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(cbTurnos.Text == "")
            {
                MessageBox.Show("Seleccione un turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(Cancelar(idPaciente) > 0)
            {
                MessageBox.Show("Turno cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
