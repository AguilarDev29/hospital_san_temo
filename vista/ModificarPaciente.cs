using Final_TallerdeProgramacion_Aguilar_Juarez.modelo;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.vista
{
    public partial class ModificarPaciente : Form
    {
        private IngresoPaciente ingresoPaciente;

        public ModificarPaciente(IngresoPaciente ingresoPaciente)
        {
            InitializeComponent();
            this.ingresoPaciente = ingresoPaciente;
        }
        private void ModificarPaciente_Load(object sender, EventArgs e)
        {
            CargarObraSocial();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ingresoPaciente.Show();
            Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente(txtApellido.Text, txtNombre.Text,
                txtDni.Text, cbSexo.Text, txtDireccion.Text, txtLocalidad.Text,
                pFechaNac.Value, txtTelefono.Text, txtEmail.Text, IdObraSocial(cbObraSocial.Text));
            if(Modificar(paciente) > 0)
            {
                MessageBox.Show("Paciente modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                MessageBox.Show("Ingrese un DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Paciente paciente = BuscarPaciente(txtDni.Text);
            if (paciente == null) MessageBox.Show("Paciente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                txtApellido.Text = paciente.Apellido;
                txtNombre.Text = paciente.Nombre;
                cbSexo.Text = paciente.Sexo;
                txtDireccion.Text = paciente.Direccion;
                txtLocalidad.Text = paciente.Localidad;
                pFechaNac.Value = paciente.FechaNacimiento;
                txtTelefono.Text = paciente.Telefono;
                txtEmail.Text = paciente.Email;
                cbObraSocial.Text = ObraSocial(paciente.IdObraSocial);
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
                if (reader.Read()) return reader.GetInt32(0);
                else return -1;
            }
        }

        private int Modificar(Paciente paciente)
        {
            string query = "UPDATE paciente SET apellido = @apellido, nombre = @nombre, sexo = @sexo," +
                " direccion = @direccion, localidad = @localidad, fecha_nac = @fechaNacimiento, telefono = @telefono," +
                " email = @email, id_obra_social = @obraSocial WHERE dni = @dni;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                cmd.Parameters.AddWithValue("@direccion", paciente.Direccion);
                cmd.Parameters.AddWithValue("@localidad", paciente.Localidad);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@email", paciente.Email);
                cmd.Parameters.AddWithValue("@obraSocial", paciente.IdObraSocial);
                cmd.Parameters.AddWithValue("@dni", paciente.Dni);
                return cmd.ExecuteNonQuery();
            }
        }

        private Paciente BuscarPaciente(string dni)
        {
            string query = "SELECT p.apellido, p.nombre , p.sexo, p.direccion, p.localidad, p.fecha_nac," +
                " telefono, email, os.id FROM paciente p INNER JOIN obra_social os ON p.id_obra_social = os.id WHERE p.dni = @dni";

            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Paciente(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetDateTime(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetInt32(8)
                    );
                }
                return null;
            }
        }

        private void CargarObraSocial()
        {
            string query = "SELECT nombre FROM obra_social;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbObraSocial.Items.Add(reader.GetString(0));
                }
            }
        }

        private string ObraSocial(int id)
        {
            string query = "SELECT nombre FROM obra_social WHERE id = @id;";
            using (SqlConnection conn = Conexion.Conectar())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) return reader.GetString(0);
                else return "";
            }
        }

    }
}
