using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class ReagendarTurno : Form
    {

        private int idPaciente;

        public ReagendarTurno(int idPaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Turno turno = new Turno(IdTurno(idPaciente), pFecha.Value, cbHorario.Text);
            if (Reagendar(turno) > 0)
            {
                MessageBox.Show("Turno reagendado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ReagendarTurno_Load(object sender, EventArgs e)
        {
            CargarHorariosDisponibles(pFecha.Value, IdMedico(cbTurnos.Text));
            Turnos(idPaciente);
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
                cbTurnos.Items.Clear(); // Limpiar los elementos anteriores
                while (reader.Read())
                {
                    cbTurnos.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));
                }
            }
        }


        private int Reagendar(Turno turno)
        {
            string query = "UPDATE turno SET fecha_turno = @fechaTurno, horario_turno = @horaTurno WHERE id = @idTurno;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fechaTurno", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@horaTurno", turno.HoraTurno);
                cmd.Parameters.AddWithValue("@idTurno", turno.Id);
                return cmd.ExecuteNonQuery();
            }   
        }

        private int IdTurno(int idPaciente)
        {
            string query = "SELECT t.id FROM turno t INNER JOIN paciente p ON t.id_paciente = p.id WHERE p.id = @idPaciente AND t.cancelado = 'NO' AND t.atendido = 'NO';";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        private int IdMedico(string medico)
        {
            string query = "SELECT m.id FROM medico m INNER JOIN especialidad e" +
                " ON m.id_especialidad = e.id WHERE CONCAT(m.apellido, ', ', m.nombre, ' - ', e.nombre) = @medico;";
            
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medico", medico);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }
        private void CargarHorariosDisponibles(DateTime fecha, int idMedico)
        {
            string query = "SELECT h.horario FROM horario h " +
                "LEFT JOIN turno t ON h.horario = t.horario_turno AND t.fecha_turno = @fecha AND t.id_medico = @idMedico " +
                "WHERE t.horario_turno IS NULL;";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                cmd.Parameters.AddWithValue("@idMedico", idMedico);
                SqlDataReader reader = cmd.ExecuteReader();
                cbHorario.Items.Clear();
                while (reader.Read())
                {
                    TimeSpan horario = reader.GetTimeSpan(0);
                    cbHorario.Items.Add(horario.ToString(@"hh\:mm"));
                }
            }
        }


        private void pFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarHorariosDisponibles(pFecha.Value, IdMedico(cbTurnos.Text));
        }

        private void cbTurnos_TextChanged(object sender, EventArgs e)
        {
            CargarHorariosDisponibles(pFecha.Value, IdMedico(cbTurnos.Text));
        }

    }
}
