using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class IngresoPaciente : Form
    {
        private AgendaTurno agendaConsulta;
        private ModificarPaciente modificarPaciente;
        public IngresoPaciente(AgendaTurno agendaConsulta, ModificarPaciente modificarPaciente)
        {
            InitializeComponent();
            this.agendaConsulta = agendaConsulta;
            this.modificarPaciente = modificarPaciente;
            CargarObraSocial();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            agendaConsulta.Show();
            Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            cbSexo.SelectedIndex = -1;
            txtDireccion.Clear();
            txtLocalidad.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cbObraSocial.SelectedIndex = -1;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente(txtApellido.Text, txtNombre.Text, txtDni.Text,
                cbSexo.Text, txtDireccion.Text, txtLocalidad.Text, pFechaNac.Value, txtTelefono.Text,
                txtEmail.Text, IdObraSocial(cbObraSocial.Text));
            if (IngresarPaciente(paciente) > 0)
            {
                MessageBox.Show("Paciente ingresado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                MessageBox.Show("Error al ingresar paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarPaciente = new ModificarPaciente(this);
            modificarPaciente.Show();
            Hide();
        }

        private void CargarObraSocial()
        {
            using (SqlConnection conn = Conexion.Conectar())
            {
                string query = "SELECT id, nombre FROM obra_social";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbObraSocial.Items.Add(reader.GetString(1));
                }
            }
        }

        private int IdObraSocial(string obraSocial)
        {
            string query = "SELECT id FROM obra_social WHERE nombre = @obraSocial;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@obraSocial", obraSocial);
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
        private int IngresarPaciente(Paciente paciente)
        {
            string query = "INSERT INTO paciente (apellido, nombre, dni, sexo, direccion, localidad," +
                " fecha_nac, telefono, email, id_obra_social) " +
                "VALUES (@apellido, @nombre, @dni, @sexo, @direccion," +
                " @localidad, @fechaNac," +
                " @telefono, @email, @obraSocial)";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@dni", paciente.Dni);
                cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@localidad", paciente.Localidad);
                cmd.Parameters.AddWithValue("@fechaNac", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@email", paciente.Email);
                cmd.Parameters.AddWithValue("@obraSocial", paciente.IdObraSocial);
                return cmd.ExecuteNonQuery();
            }
        }

        
    }
}
