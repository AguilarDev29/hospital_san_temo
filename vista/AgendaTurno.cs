using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using Final_TallerdeProgramacion_Aguilar_Juarez.vista;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez
{
    public partial class AgendaTurno : Form
    {
        private IngresoPaciente ingresoPaciente;
        private ModificarPaciente modificarPaciente;
        
        public AgendaTurno()
        {
            InitializeComponent();
        }
        private void IngresoPaciente_Load(object sender, EventArgs e)
        {
            CargarEspecialidad();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea salir del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.ExitThread();
                Dispose();
            }
        }

        private void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            ingresoPaciente = new IngresoPaciente(this, modificarPaciente);
            ingresoPaciente.Show(this);
            Hide();
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtDni.Text == "")
            {
                MessageBox.Show("Ingrese un DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BuscarPaciente(txtDni.Text);
            if (txtPaciente.Text == "")
            {
                var respuesta = MessageBox.Show("Paciente no encontrado\n¿Desea ingresar un nuevo paciente?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(respuesta == DialogResult.Yes)
                {
                    ingresoPaciente = new IngresoPaciente(this, modificarPaciente);
                    ingresoPaciente.Show(this);
                    Hide();
                }
            }

        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMedico();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int idPaciente = IdPaciente(txtDni.Text);
            int idMedico = IdMedico(cbMedico.Text);
            decimal total = Convert.ToDecimal(txtTotal.Text.Substring(1));
            Turno turno = new Turno(idPaciente, idMedico, pFecha.Value, cbHorario.Text, total);
            if(AgendarTurno(turno) > 0)
            {
                MessageBox.Show("Turno agendado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotal.Clear();
                cbEspecialidad.SelectedIndex = -1;
                cbMedico.SelectedIndex = -1;
                btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al agendar turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            decimal descuento = PlusMedico(cbMedico.Text) * DescuentoObraSocial();

            btnAgregar.Enabled = true;
            txtTotal.Text = "$" + (PlusMedico(cbMedico.Text) - descuento).ToString();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea reprogramar el turno?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if(respuesta == DialogResult.Yes)
            {
                ReagendarTurno reagendarTurno = new ReagendarTurno(IdPaciente(txtDni.Text));
                reagendarTurno.Show();
            }
            if(respuesta == DialogResult.No)
            {
                CancelarTurno cancelarTurno = new CancelarTurno(IdPaciente(txtDni.Text));
                cancelarTurno.Show();
                
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPaciente.Clear();
            txtDni.Clear();
            txtObraSocial.Clear();
            txtTotal.Clear();
            cbEspecialidad.SelectedIndex = -1;
            cbMedico.SelectedIndex = -1;
            btnAgregar.Enabled = false;
        }

        private void CargarEspecialidad()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT nombre FROM especialidad;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbEspecialidad.Items.Add(reader.GetString(0));
                }
            }
        }

        private string FiltrarMedico()
        {

            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT CONCAT('Dr. ', m.apellido, ', ', m.nombre) AS medico, m.dni " +
                               "FROM medico m " +
                               "INNER JOIN especialidad e ON e.id = m.id_especialidad " +
                               "WHERE e.nombre = @nombre;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", cbEspecialidad.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                cbMedico.Items.Clear();

                while (reader.Read())
                {
                    cbMedico.Items.Add(reader.GetString(0));
                    return reader.GetString(1);
                }
                return null;
            }
        }

        private int BuscarPaciente(string dni)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT CONCAT(p.apellido, ', ', p.nombre) AS paciente, os.nombre FROM paciente p " +
                    "INNER JOIN obra_social os ON p.id_obra_social = os.id WHERE p.dni = @dni;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtPaciente.Text = reader.GetString(0);
                    txtObraSocial.Text = reader.GetString(1);
                }
                reader.Close();
                return cmd.ExecuteNonQuery();
            }

        }

        private int AgendarTurno(Turno turno)
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "EXECUTE spAgendar_turno @id_paciente, @id_medico, @fecha_turno, @horario_turno, @total";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_paciente", turno.IdPaciente);
                cmd.Parameters.AddWithValue("@id_medico", turno.IdMedico);
                cmd.Parameters.AddWithValue("@fecha_turno", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@horario_turno", turno.HoraTurno);
                cmd.Parameters.AddWithValue("@total", turno.Total);
                return cmd.ExecuteNonQuery();
            }


        }

        private int IdPaciente(string dni)
        {
            string query = "SELECT id FROM paciente WHERE dni = @dni";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private int IdMedico(string medico)
        {
            string query = "SELECT id FROM medico WHERE CONCAT('Dr. ',apellido,', ', nombre) = @medico";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medico", medico);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private decimal PlusMedico(string medico)
        {
            string query = "SELECT plus FROM medico WHERE CONCAT('Dr. ',apellido,', ', nombre) = @medico";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medico", medico);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetDecimal(0);
                }
                else
                {
                    return -1;
                }
            }
        }

        private decimal DescuentoObraSocial()
        {
            string query = "SELECT descuento FROM obra_social WHERE nombre = @obraSocial";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@obraSocial", txtObraSocial.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetDecimal(0);
                }
                else
                {
                    return -1;
                }
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
            CargarHorariosDisponibles(pFecha.Value, IdMedico(cbMedico.Text));
        }
    }
}
